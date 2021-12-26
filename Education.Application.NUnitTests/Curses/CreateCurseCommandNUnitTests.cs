using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using Education.Application.NUnitTests.Helper;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Education.Application.Curses
{
    public class CreateCurseCommandNUnitTests
    {
        private CreateCurseCommand.CreateCurseCommandHandler handlerCreateCurse;
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

            handlerCreateCurse = new CreateCurseCommand.CreateCurseCommandHandler(educationDbContextFake);
        }

        [Test]
        public async Task CreateCursoCommandHandler_InputCurse_ReturnsNumber()
        {
            var request = new CreateCurseCommand.CreateCurseCommandRequest();
            request.PublishDate = DateTime.UtcNow.AddDays(7);
            request.Title = "Test Title";
            request.Description = "Test Description";
            request.Price = 99;

            var result = await handlerCreateCurse.Handle(request, new System.Threading.CancellationToken());

            Assert.That(result, Is.EqualTo(Unit.Value));
        }

    }
}