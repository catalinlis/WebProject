using API.Entities;

namespace API.DTOs;

public class CourseStudentsDto{
    public string CourseName { get; set; }
    public List<StudentNameDto> Students { get; set; }
}