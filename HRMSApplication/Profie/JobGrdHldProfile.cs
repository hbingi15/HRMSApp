using AutoMapper;
using HRMSApplication.Models.Entity;
using HRMSApplication.Models.Resource;

namespace HRMSApplication.Profie
{
    public class JobGrdHldProfile : Profile
    {
        public JobGrdHldProfile()
        {
            CreateMap<JobGrdHldEntity,JobGrdHldResource>()
                .ForMember(
                    dest => dest.Job_Grade_Id,
                    opt => opt.MapFrom(src => $"{src.jbgr_id}")
                )
                 .ForMember(
                    dest => dest.Job_Total_NOH,
                    opt => opt.MapFrom(src => $"{src.jbgr_totalnoh}")

                );
        }
    }
}
