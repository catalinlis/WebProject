using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class BookController(DataContext context) : BaseController{

    [HttpPost("add/{course_name}")]
    public async Task<IActionResult> AddBook(Book book, string course_name){
        if(context.Courses == null) return NotFound("No such table");

        var course = await context.Courses.FirstOrDefaultAsync( x => x.CourseName == course_name);

        if( course == null ) return NotFound("No such a course found in the database");

        book.RelatedCourses.Add(course);
        context.Books.Add(book);
        await context.SaveChangesAsync();

        return Ok();
    }

}