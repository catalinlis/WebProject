using API.Entities;

namespace API.DTOs;

public class StudentDto{

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required int Age { get; set; }

    public string? Country { get; set; }
    public string? City { get; set; }
    public List<string> Courses  { get; set; }
}