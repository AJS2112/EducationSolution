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
    [TestFixture]
    public class GetCurseQueryNUnitTests
    {
        private GetCurseQuery.GetCurseQueryHandler handlerAllCurses;
        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            var curseRecords = fixture.CreateMany<Curse>().ToList();

            curseRecords.Add(fixture.Build<Curse>()
            .With(t => t.CurseId, Guid.Empty)
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

            handlerAllCurses = new GetCurseQuery.GetCurseQueryHandler(educationDbContextFake, mapper);
        }

        [Test]
        public async Task GetCursoQueryHandler_CurseQuery_ReturnsTrue()
        {
            var request = new GetCurseQuery.GetCurseQueryRequest();
            var result = await handlerAllCurses.Handle(request, new System.Threading.CancellationToken());

            Assert.IsNotNull(result);
        }
    }
}