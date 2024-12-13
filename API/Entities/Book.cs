using API.Entities;

public class Book{
    public int Id { get; set; }
    public string BookName { get; set; }
    public int Year { get; set; }
    public List<Course> RelatedCourses { get; set; } = new List<Course>();
    public List<BookCourse> BooksCourses { get; set; } = new List<BookCourse>();
}