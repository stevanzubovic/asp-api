using Application;
using Domain;
using EfDataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Logging
{
    public class SQLLogger : IUseCaseLogger
    {
        private readonly LibraryContext libraryContext;

        public SQLLogger(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            var log = new Log();

            log.ActorId = actor.Id;
            log.UseCase = useCase.Name;
            log.UseCaseId = useCase.Id;
            log.Data = JsonConvert.SerializeObject(useCaseData); //TO DO serialize properly

            libraryContext.Logs.Add(log);
            libraryContext.SaveChanges();
        }
    }
}
