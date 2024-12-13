using API.DTOs;
using API.Entities;
using AutoMapper;
namespace API.Helpers;

public class AutoMapperProfiles : Profile{

    public AutoMapperProfiles(){
        
        CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses.Select( x => x.CourseName).ToList()));
            
        CreateMap<Course, CourseDto>();
        CreateMap<Course, CourseStudentsDto>();
        CreateMap<Student, StudentNameDto>();

    }

}