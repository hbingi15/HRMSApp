using AutoMapper;
using HRMSApplication.Models;
using HRMSApplication.Models.Resource;

namespace HRMSApplication.Profie
{
    public class InductionProfile :Profile
    {
        public InductionProfile()
        {
            CreateMap<InductionEntity, InductionResource>()
                .ForMember(
                    dest => dest.Indction_ID,
                    opt => opt.MapFrom(src => $"{src.indc_id}")
                )
                .ForMember(
                    dest => dest.Induction_Emof_ID,
                    opt => opt.MapFrom(src => $"{src.indc_emof_id}")
                )
                .ForMember(
                    dest => dest.Induction_Date,
                    opt => opt.MapFrom(src => $"{src.indc_date}")
                )
                .ForMember(
                    dest => dest.Induction_Processed_Ausr_ID,
                    opt => opt.MapFrom(src => $"{src.indc_processed_ausr_id}")
                )
                .ForMember(
                    dest => dest.Induction_Status,
                    opt => opt.MapFrom(src => $"{src.indc_status}")
                );
        }
    }
}
