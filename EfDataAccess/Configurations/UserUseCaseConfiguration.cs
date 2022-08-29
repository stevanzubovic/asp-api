using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDataAccess.Configurations
{
    public class UserUseCaseConfiguration : IEntityTypeConfiguration<UserUseCase>
    {
        public void Configure(EntityTypeBuilder<UserUseCase> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.UseCaseId).IsRequired();
            builder.Property(x => x.Id).IsRequired();
        }
    }
}
