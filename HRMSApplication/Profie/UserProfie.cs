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
                    dest => dest.EmployeeId,
                    opt => opt.MapFrom(src => $"{src.empl_id}")
                )

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
                    dest => dest.Rmanager_Empl_Id,
                    opt => opt.MapFrom(src => $"{src.empl_rmanager_empl_id}")
                )
                .ForMember(
                    dest => dest.Hr_Empl_Id,
                    opt => opt.MapFrom(src => $"{src.empl_hr_empl_id}")
                )
                .ForMember(
                    dest => dest.Jbgr_Id,
                    opt => opt.MapFrom(src => $"{src.empl_jbgr_id}")
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
                    dest => dest.LastUpdatedDate,
                    opt => opt.MapFrom(src => $"{src.empl_lastUpdatedDate}")
                )
                .ForMember(
                    dest => dest.LastUpdatedUser,
                    opt => opt.MapFrom(src => $"{src.empl_lastUpdatedUser}")
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
                    opt => opt.MapFrom(src => $"{src.empl_status}")
                );
        }
    }
}
