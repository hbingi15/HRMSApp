using AutoMapper;
using HRMSApplication.Models.Entity;
using HRMSApplication.Models.Resource;

namespace HRMSApplication.Profie
{
    public class CandidateProfile  : Profile
    {
        public CandidateProfile()
        {
            CreateMap<CandidatesEntity, CandidateResource>()
                .ForMember(
                    dest => dest.ID,
                    opt => opt.MapFrom(src => src.cand_id)
                )
                .ForMember(
                    dest => dest.Cand_FirstName,
                    opt => opt.MapFrom(src => $"{src.cand_firstname}")
                )
                .ForMember(
                    dest => dest.Cand_MiddleName,
                    opt => opt.MapFrom(src => $"{src.cand_middlename}")
                )
                .ForMember(
                    dest => dest.Cand_LastName,
                    opt => opt.MapFrom(src => $"{src.cand_lastname}")
                )
                .ForMember(
                    dest => dest.Cand_Rdate,
                    opt => opt.MapFrom(src => $"{src.cand_rdate}")
                )
                .ForMember(
                    dest => dest.Cand_Gender,
                    opt => opt.MapFrom(src => $"{src.cand_gender}")
                )
                .ForMember(
                    dest => dest.Cand_Dob,
                    opt => opt.MapFrom(src => $"{src.cand_dob}")
                )
                .ForMember(
                    dest => dest.Cand_Email,
                    opt => opt.MapFrom(src => $"{src.cand_email}")
                )
                .ForMember(
                    dest => dest.Cand_Mobile,
                    opt => opt.MapFrom(src => $"{src.cand_mobile}")
                )

                .ForMember(
                    dest => dest.Cand_Address,
                    opt => opt.MapFrom(src => $"{src.cand_address}")
                )
                 .ForMember(
                    dest => dest.Candidate_Status,
                    opt => opt.MapFrom(src => $"{src.cand_status}")
                
                );
        }



    }
}
