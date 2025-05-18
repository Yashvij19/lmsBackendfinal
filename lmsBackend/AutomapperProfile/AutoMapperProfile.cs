using AutoMapper;
using lmsBackend.Dtos.AdminDtos;
using lmsBackend.Dtos.CategoriesDtos;
using lmsBackend.Dtos.CourseDtos;
using lmsBackend.Dtos.LobDtos;
using lmsBackend.Dtos.ModuleDtos;
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

            // Categories mapping 
            CreateMap<CreatCategoriesDtos, Categories>().ReverseMap();
            CreateMap<Categories, CategoriesResponseDtos>().ReverseMap();

            // Course mappings
            CreateMap<CreateCourseDto, Courses>()
            .ForMember(dest => dest.category_id, opt => opt.MapFrom(src => src.category_id));
            CreateMap<Courses, ResponseCourseDtos>();

            CreateMap<CreateModuleDtos, Module>()
    .ForMember(dest => dest.videopath, opt => opt.Ignore()) // Will be manually assigned
    .ForMember(dest => dest.documentpath, opt => opt.Ignore()); // Will be manually assigned

            CreateMap<Module, ResponseModuleDtos>()
    .ForMember(dest => dest.module_id, opt => opt.MapFrom(src => src.module_id))
    .ForMember(dest => dest.modulename, opt => opt.MapFrom(src => src.modulename))
    .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.description))
    .ForMember(dest => dest.duration, opt => opt.MapFrom(src => src.duration));
        }

    }
}
