using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using Education.Application.NUnitTests.Helper;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Education.Application.Curses
{
    public class GetCurseByIdQueryNUnitTests
    {
        private GetCurseByIdQuery.GetCurseByIdQueryHandler handlerGetCurse;
        private Guid curseIdTest;

        [SetUp]
        public void Setup()
        {
            curseIdTest = new Guid("54ad1381-64f2-42d2-bdd5-5bbc3faa04f5");
            var fixture = new Fixture();
            var curseRecords = fixture.CreateMany<Curse>().ToList();

            curseRecords.Add(fixture.Build<Curse>()
            .With(t => t.CurseId, curseIdTest)
            .Create());

            var options = new DbContextOptionsBuilder<EducationDbContext>()
                .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
                .Options;

            var educationDbContextFake = new EducationDbContext(options);
            educationDbContextFake.Curses.AddRange(curseRecords);

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            }
            );

            var mapper = mapConfig.CreateMapper();

            handlerGetCurse = new GetCurseByIdQuery.GetCurseByIdQueryHandler(educationDbContextFake, mapper);
        }

        [Test]
        public async Task GetCursoByIdQueryHandler_InputCurseId_ReturnsNotNull()
        {
            var request = new GetCurseByIdQuery.GetCurseByIdQueryRequest();
            request.Id = curseIdTest;

            var result = await handlerGetCurse.Handle(request, new System.Threading.CancellationToken());

            Assert.IsNotNull(result);
        }

    }
}