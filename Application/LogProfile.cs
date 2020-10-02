using Application.Create;
using AutoMapper;
using Entities;

namespace Application
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<Question, CreatedQuestionDto>();
        }
    }
}
