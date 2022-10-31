using System;
using System.Transactions;
using Academy.Domain.Tests.Builders;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Tests.Integration
{
    public class RealDatabaseFixture : IDisposable
    {
        public AcademyContext Context;
        private readonly TransactionScope _scope;

        public RealDatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<AcademyContext>()
                .UseSqlServer("Data Source=.;Initial Catalog=MTDDAcademy;Integrated Security=True").Options;
            Context = new AcademyContext(options);

            _scope = new TransactionScope();

            var builder = new CourseTestBuilder();
            var asp = builder
                .WithName("ASP.NET Core")
                .WithTuition(750)
                .WithInstructor("Ehsan")
                .Build();
            var sql = builder
                .WithName("SQL")
                .WithTuition(550)
                .WithInstructor("Ali")
                .Build();
            var csharp = builder
                .WithName("C#")
                .WithTuition(700)
                .WithInstructor("Amir")
                .Build();

            Context.Add(asp);
            Context.Add(sql);
            Context.Add(csharp);
            Context.SaveChanges();
        }

        public void Dispose()
        {
            _scope.Dispose();
            Context.Database.ExecuteSqlRaw("truncate table [TddAcademy].[dbo].[Courses]");
            Context.SaveChanges();
            Context.Dispose();

        }
    }
}


