using AutoMapper;
using HRMSApplication.Models.Entity;
using HRMSApplication.Models.Resource;

namespace HRMSApplication.Profie
{
    public class EOCandidateProfile : Profile
    {
        public EOCandidateProfile()
        {
            CreateMap<EOCandidateEntity, EOCandidateReource>()
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
                    )
                 .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => $"{src.cand_firstname}")
                )
                .ForMember(
                    dest => dest.MiddleName,
                    opt => opt.MapFrom(src => $"{src.cand_middlename}")
                )
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => $"{src.cand_lastname}")
                )
                .ForMember(
                    dest => dest.Rdate,
                    opt => opt.MapFrom(src => $"{src.cand_rdate}")
                )
                .ForMember(
                    dest => dest.Gender,
                    opt => opt.MapFrom(src => $"{src.cand_gender}")
                )
                .ForMember(
                    dest => dest.Dob,
                    opt => opt.MapFrom(src => $"{src.cand_dob}")
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => $"{src.cand_email}")
                )
                .ForMember(
                    dest => dest.Mobile,
                    opt => opt.MapFrom(src => $"{src.cand_mobile}")
                )

                .ForMember(
                    dest => dest.Address,
                    opt => opt.MapFrom(src => $"{src.cand_address}")
                )
                 .ForMember(
                    dest => dest.Candidate_Status,
                    opt => opt.MapFrom(src => $"{src.cand_status}")

                );
        }


        }
    }
