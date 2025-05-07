using AutoMapper;
using lmsBackend.Dtos.AdminDtos;
using lmsBackend.Dtos.LobDtos;
using lmsBackend.Dtos.RoleDtos;
using lmsBackend.Dtos.SmeDtos;
using lmsBackend.Dtos.User;
using lmsBackend.Models;

namespace lmsBackend.AutomapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User mappings
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserResponseDto>()
                .ForMember(dest => dest.LobName, opt => opt.MapFrom(src => src.Lob.LobName))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));

            // Admin mappings
            CreateMap<CreateAdminDto, Admin>();
            CreateMap<Admin, AdminResponseDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.User.Phone));

            // SME mappings
            CreateMap<CreateSmeDto, Sme>();
            CreateMap<Sme, SmeResponseDto>();

            // LOB mappings
            CreateMap<CreateLobDto, Lob>();
            CreateMap<Lob, LobResponseDto>();

            // Role mappings
            CreateMap<CreateRoleDto, Role>();
            CreateMap<Role, RoleResponseDto>();
        }
    }
}
