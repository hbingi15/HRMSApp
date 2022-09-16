using AutoMapper;
using HRMSApplication.Models.Entity;
using HRMSApplication.Models.Resource;

namespace HRMSApplication.Profie
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<EmployeeEntity,EmployeeResource>()
                .ForMember(
                    dest => dest.Firstname,
                    opt => opt.MapFrom(src => $"{src.empl_firstname}")
                )
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => $"{src.empl_lastname}")
                )
                .ForMember(
                    dest => dest.SurName,
                    opt => opt.MapFrom(src => $"{src.empl_surname}")
                )
                .ForMember(
                    dest => dest.EmpId,
                    opt => opt.MapFrom(src => $"{src.empl_empid}")
                )
                .ForMember(
                    dest => dest.Joiningdate,
                    opt => opt.MapFrom(src => $"{src.empl_joindate}")
                )
                .ForMember(
                    dest =>dest.DOB,
                    opt => opt.MapFrom(src => $"{src.empl_dob}")
                )
                 .ForMember(
                    dest =>dest.Designation,
                    opt => opt.MapFrom(src => $"{src.empl_designation}")
                )

                .ForMember(
                    dest => dest.OffEmail,
                    opt => opt.MapFrom(src => $"{src.empl_offemail}")
                )

                .ForMember(
                    dest => dest.PersonalEmail,
                    opt => opt.MapFrom(src => $"{src.empl_pemail}")
                )
                
                .ForMember(
                    dest => dest.Mobile,
                    opt => opt.MapFrom(src => $"{src.empl_mobile}")
                )
                .ForMember(
                    dest => dest.AlternativeEmail,
                    opt => opt.MapFrom(src => $"{src.empl_altemail}")
                )

                .ForMember(
                    dest => dest.BloodGroup,
                    opt => opt.MapFrom(src => $"{src.empl_bloodgroup}")
                )
                .ForMember(
                    dest => dest.Gender,
                    opt => opt.MapFrom(src => $"{src.empl_gender}")
                )
                .ForMember(
                    dest => dest.Address,
                    opt => opt.MapFrom(src => $"{src.empl_address}")
                )
                 .ForMember(
                    dest => dest.FatherName,
                    opt => opt.MapFrom(src => $"{src.empl_fatherName}")
                )

                .ForMember(
                    dest => dest.Employee_status,
                    opt => opt.MapFrom(src => $"{src.Employee_status}")
                );
        }
    }
}
