using AutoMapper;
using Newtonsoft.Json.Linq;
using Scanner.API.Common.Extensions;
using Scanner.API.Model.Domains;

namespace Scanner.API.BusinessLogic.Mappers {
    public class UserMapper : Profile {
        public UserMapper() {
            CreateMap<JToken, User>()
                .ForMember(s => s.Id, o => o.MapFrom(a => a.GetJobjectValue<string>("id").ToIntSafe()))
                .ForMember(s => s.EmployeeId, o => o.MapFrom(a => a.GetJobjectValue<string>("employeeId")))
                .ForMember(s => s.FirstName, o => o.MapFrom(a => a.GetJobjectValue<string>("firstName")))
                .ForMember(s => s.LastName, o => o.MapFrom(a => a.GetJobjectValue<string>("lastName")))
                .ForMember(s => s.Username, o => o.MapFrom(a => a.GetJobjectValue<string>("userName")))
                .ForMember(s => s.Password, o => o.MapFrom(a => a.GetJobjectValue<string>("passWord")))
                .ForMember(s => s.IsUser, o => o.MapFrom(a => a.GetJobjectValue<string>("isUser").ToNullableValue<bool>()));
        }
    }
}
