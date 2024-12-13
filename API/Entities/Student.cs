
using System.Text.Json.Serialization;

namespace API.Entities;

public class Student{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required int Age { get; set; }
    public Address? Address { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();
    public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}