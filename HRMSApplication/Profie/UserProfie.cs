namespace HRMSApplication.Profie
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => $"{src.FirstName}")
                )
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => $"{src.LastName}")
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => $"{src.Email}")
                )
                .ForMember(
                    dest => Convert.ToDateTime(dest.DateOfBirth),
                    opt => opt.MapFrom(src => $"{src.DateOfBirth}")
                )
                .ForMember(
                    dest => dest.Phone,
                    opt => opt.MapFrom(src => $"{src.Phone}")
                )
                .ForMember(
                    dest => dest.Country,
                    opt => opt.MapFrom(src => $"{src.Country}")
                )
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => 1)
                );
        }
    }
}
