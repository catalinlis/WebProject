using System.Text.Json.Serialization;

namespace API.Entities;

public class Course{
    public int Id { get; set; }
    public required string CourseName { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
    public List<StudentCourse> StudentCourses {get; set;} = new List<StudentCourse>();
    public List<Book> Books { get; set; } = new List<Book>();
    public List<BookCourse> BooksCourses { get; set; } = new List<BookCourse>();
}