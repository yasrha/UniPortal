using Microsoft.EntityFrameworkCore;
using UniPortal.Models;

public class UniContext : DbContext
{
    /**
     * This class acts as the primary entry point to interact with the database. 
     * It serves as a bridge between the domain/entity classes and the database.
     * 
     * EF Core is an object relational mapper (ORM) which allows us to work with databases 
     * using .NET objects, abstracting away most of the direct database-related operations.
     * 
     * Rather than creating raw SQL queries in the conrollers, which is typically bad
     * practice, we create LINQ queries which are translated to SQL using EF Core. Creating raw SQL
     * queries can decrease productivity and readability of code, and also increase the risk of 
     * SQL injection attacks.
     * 
     * The DbContext class is a central component in EF Core. It represents a session with the 
     * database and provides APIs to perform CRUD operations against the database.
     */
    public UniContext(DbContextOptions<UniContext> options)
        : base(options) { }

    // Each one of the DbSets represent a collection of all entities in the context, or that can
    // be queried from the database, of a given type.
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }

}
