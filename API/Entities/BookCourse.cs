namespace API.Entities;

public class BookCourse{
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
}