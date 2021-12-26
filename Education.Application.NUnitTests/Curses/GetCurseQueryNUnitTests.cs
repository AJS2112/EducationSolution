using System;
using System.Linq;
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
        public void GetCursoQueryHandler_CurseQuery_ReturnsTrue()
        {
            // 1. Emulate context that represents EF instance

            // 2. Emulate Mapping Profile

            // 3. Instantiate GetCurseQuery.GetCurseQueryHandler object
            // GetCursoQueryHandler(_mapping, _context)

        }
    }
}