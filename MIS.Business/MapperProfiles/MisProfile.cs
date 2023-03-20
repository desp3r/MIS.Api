using AutoMapper;
using MIS.Business.Models.Employee;
using MIS.Business.Models.User;
using MIS.Data.Models;

namespace MIS.Business.MapperProfiles
{
    public class MisProfile : Profile
    {
        public MisProfile()
        {
            #region User

            CreateMap<RegisterUserRequest, RegisterUserResponse>().ReverseMap();

            CreateMap<RegisterUserRequest, User>().ReverseMap();

            #endregion

            #region Employee

            CreateMap<EmloyeeModel, Employee>().ReverseMap();

            #endregion
        }
    }
}
