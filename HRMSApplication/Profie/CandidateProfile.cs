using AutoMapper;
using HRMSApplication.Models.Entity;
using HRMSApplication.Models.Resource;

namespace HRMSApplication.Profie
{
    public class CandidateProfile :Profile
    {
        public CandidateProfile()
        {
            CreateMap<CandidatesEntity, CandidateResource>()
                .ForMember(
                    dest => dest.Candidate_FirstName,
                    opt => opt.MapFrom(src => $"{src.cand_firstname}")
                )
                .ForMember(
                    dest => dest.Candidate_Middlename,
                    opt => opt.MapFrom(src => $"{src.cand_middlename}")
                )
                .ForMember(
                    dest => dest.Candidate_Lastname,
                    opt => opt.MapFrom(src => $"{src.cand_lastname}")
                )
                .ForMember(
                    dest => dest.Candidate_Rdate,
                    opt => opt.MapFrom(src => $"{src.cand_rdate}")
                )
                .ForMember(
                    dest => dest.Candidate_Gender,
                    opt => opt.MapFrom(src => $"{src.cand_gender}")
                )
                .ForMember(
                    dest => dest.Candidate_Dob,
                    opt => opt.MapFrom(src => $"{src.cand_dob}")
                )
                .ForMember(
                    dest => dest.Candidate_Email,
                    opt => opt.MapFrom(src => $"{src.cand_email}")
                )
                .ForMember(
                    dest => dest.Candidate_Mobile,
                    opt => opt.MapFrom(src => $"{src.cand_mobile}")
                )

                .ForMember(
                    dest => dest.Candidate_Address,
                    opt => opt.MapFrom(src => $"{src.cand_address}")
                )
                 .ForMember(
                    dest => dest.Candidate_Status,
                    opt => opt.MapFrom(src => $"{src.cand_status}")
                
                );
        }



        }
    }
