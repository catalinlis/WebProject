using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class CourseController(DataContext context, IMapper mapper) : BaseController{

    [HttpPost("add")]
    public async Task<ActionResult> AddCourse(Course course){
        
        if(context.Courses == null) return NotFound("No such table");

        context.Courses.Add(course);
        await context.SaveChangesAsync();

        return Ok(course);
    }

    [HttpGet("{course_name}")]
    public async Task<ActionResult> GetCourse(string course_name){
        if(context.Courses == null) return NotFound("No such table");

        var course = await context.Courses.Include( x => x.Students).FirstOrDefaultAsync(x => x.CourseName == course_name);

        if(course == null) return NotFound("There is no such a course");

        var courseDto = mapper.Map<CourseStudentsDto>(course);

        return Ok(courseDto);
    }

}