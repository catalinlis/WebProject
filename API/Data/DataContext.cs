using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options){

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder builder){
        builder.Entity<Student>().HasOne(x => x.Address)
                        .WithOne(x => x.Student)
                        .HasForeignKey<Address>(x => x.StudentId)
                        .IsRequired();

        builder.Entity<Student>().HasMany(x => x.Courses)
                        .WithMany(x => x.Students)
                        .UsingEntity<StudentCourse>(
                            x => x.HasOne(c => c.Course)
                                    .WithMany(s => s.StudentCourses)
                                    .HasForeignKey( k => k.CourseId),
                            x => x.HasOne( s => s.Student)
                                    .WithMany( s=> s.StudentCourses)
                                    .HasForeignKey( k => k.StudentId));

        //builder.Entity<Student>().OwnsOne(x => x.Contact);

        builder.Entity<Book>().HasMany(x => x.RelatedCourses)
                        .WithMany(x => x.Books)
                        .UsingEntity<BookCourse>(
                                x => x.HasOne( c => c.Course)
                                        .WithMany( c => c.BooksCourses)
                                        .HasForeignKey( c => c.CourseId),
                                x => x.HasOne( c => c.Book)
                                        .WithMany( c=> c.BooksCourses)
                                        .HasForeignKey( c=> c.BookId)
                        );

    }
}