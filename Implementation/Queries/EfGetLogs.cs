using Application.DTOs;
using Application.Queries;
using EfDataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries
{
    public class EfGetLogs : IGetLogsQuery
    {
        private readonly LibraryContext libraryContext;

        public EfGetLogs(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public int Id => 20;

        public string Name => "Search logs";

        public IEnumerable<LogDTO> Execute(LogSearchDTO searchParams)
        {
            var logs = libraryContext.Logs.AsQueryable();

            if(searchParams.UseCaseId != null)
            {
                logs = logs.Where(l => l.UseCaseId == searchParams.UseCaseId);
            }
            if(!string.IsNullOrEmpty(searchParams.UseCaseName))
            {
                logs = logs.Where(l => l.UseCase.Contains(searchParams.UseCaseName));
            }
            if(searchParams.CreatedAfter != null)
            {
                logs = logs.Where(l => l.CreatedAt > searchParams.CreatedAfter);
            }
            if(searchParams.ActorId != null)
            {
                logs = logs.Where(l => l.ActorId == searchParams.ActorId);
            }

            logs = logs.OrderByDescending(l => l.CreatedAt);

            return logs.Select(l => new LogDTO
            {
                ActorId = l.ActorId,
                UseCaseId = l.UseCaseId,
                UseCaseName = l.UseCase,
                Created = l.CreatedAt,
                Data = l.Data
            }).ToList();

            throw new NotImplementedException();
        }
    }
}
