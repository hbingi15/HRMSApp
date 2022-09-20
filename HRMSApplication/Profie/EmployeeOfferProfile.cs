using AutoMapper;
using HRMSApplication.Models.Entity;
using HRMSApplication.Models.Resource;

namespace HRMSApplication.Profie
{
    public class EmployeeOfferProfile : Profile
    {
        public EmployeeOfferProfile()
        {
            CreateMap<ECEntity, EmployeeOfferResource>()
                .ForMember(
                    dest => dest.Eofr_Ref_Id,
                    opt => opt.MapFrom(src => $"{src.eofr_ref_id}")
                )
                .ForMember(
                    dest => dest.Eofr_Cand_Id,
                    opt => opt.MapFrom(src => $"{src.eofr_cand_id}")
                )
                .ForMember(
                    dest => dest.Eofr_Offerdat,
                    opt => opt.MapFrom(src => $"{src.eofr_offerdat}")
                )
                .ForMember(
                    dest => dest.Eofr_Offeredjob,
                    opt => opt.MapFrom(src => $"{src.eofr_offeredjob}")
                )
                .ForMember(
                    dest => dest.Eofr_Reportingdate,
                    opt => opt.MapFrom(src => $"{src.eofr_reportingdate}")
                )
                
                 .ForMember(
                    dest => dest.Eofr_Status,
                    opt => opt.MapFrom(src => $"{src.eofr_status}")

                );
        }
    }
}
