using AutoMapper;
using Education.Application.DTO;
using Education.Domain;

namespace Education.Application.NUnitTests.Helper
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<Curse, CurseDTO>();
        }
    }
}