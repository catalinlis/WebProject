using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class StudentController(DataContext data, IMapper mapper) : BaseController{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents(){
        int pageSize = 2;
        int page = 2;

        var students = data.Students.Include(x => x.Address).Include(x => x.Courses).AsQueryable();

        var query = await students.OrderBy(x => x.Age)
                        .Skip((page-1)*pageSize)
                        .Take(pageSize).ToListAsync();

        var studentDtos = mapper.Map<List<StudentDto>>(query);

        return Ok(studentDtos);
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddStudent(Student student){
        if(data.Students == null) return NotFound("No such table!");

        if (student == null)
        {
            return BadRequest("Invalid request body.");
        }

        if (student.Address == null)
        {
            return BadRequest("Address must not be null.");
        }


        data.Students.Add(student);
        await data.SaveChangesAsync();

        return Ok(student);
    }

    [HttpPost("{student}/course/{courseId}")]
    public async Task<IActionResult> AddStudent(int student, int courseId){
        var studentRecord = await data.Students.Include(x => x.Courses)
                        .SingleOrDefaultAsync( x => x.Id == student);

        var course = await data.Courses.FindAsync(courseId);

        studentRecord.Courses.Add(course);
        await data.SaveChangesAsync();

        return Ok();
        //return CreatedAtAction("GetActor", new {id = studentRecord.Id}, studentRecord);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetStudent(int id){
        if(data.Students == null) return NotFound("There is no such a table");

        var student = await data.Students.Include(x => x.Address).Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == id);

        if(student == null) return NotFound("No such student");

        var studentDto = mapper.Map<StudentDto>(student);

        return Ok(studentDto);
    }
}