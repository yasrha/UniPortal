using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniPortal.DataTransferObjects;
using UniPortal.Models;
using UniPortal.Data;

namespace UniPortal.Controllers
{
    /**
     * 
     * Since we are using EF Core and not raw SQL queries, we don't need to worry about 
     * connection management, reading the data manually, or transforming it. It's all 
     * abstracted away by the framework, which results in cleaner, shorter, and more 
     * maintainable code.
     * 
     * Assuming this were to be used in a real setting, we must consider recieving several requests 
     * at a time, so we use async functions to improve efficiency, scalability, and concurrancy.
     */
    [ApiController]
    [Route("api/course")]
    public class CourseController : ControllerBase
    {
        private readonly UniContext _context; // The DB context 
        private readonly ILogger<CourseController> _logger; // To log any outputs

        // Default constructor
        public CourseController(UniContext context, ILogger<CourseController> logger)
        {
            _context = context;
            _logger = logger;
        }


        /**
         * HTTP GET method
         * 
         * Returns a list of all the current courses. 
         * Use a try catch block to gracefully catch and handle exceptions.
         */
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            try
            {
                // Send a request to get the courses in a list
                var courses = await _context.Courses.ToListAsync();
                return Ok(courses);
            }
            catch (DbException dbEx) // Error from DB
            {
                // Log the exception details
                _logger.LogError(dbEx, "An error occurred while querying the database.");

                // Return a generic error message to the client
                return StatusCode(500, "An error occurred while processing your request.");
            }
            catch (Exception ex)
            {
                // Log the exception details
                _logger.LogError(ex, "An unexpected error occurred.");

                // Return a generic error message to the client
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        /**
		 * HTTP GET by ID method
		 * 
		 * Returns a single course, retrieved by passing in the id of the course.
		 */
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            try
            {
                // Send request to get a course by its id
                var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == id);
                if (course == null)
                {
                    return NotFound();
                }
                return Ok(course);
            }
            catch (DbException dbEx)
            {
                // Log the exception details
                _logger.LogError(dbEx, "An error occurred while querying the database.");

                // Return a generic error message to the client
                return StatusCode(500, "An error occurred while processing your request.");
            }
            catch (Exception ex)
            {
                // Log the exception details
                _logger.LogError(ex, "An unexpected error occurred.");

                // Return a generic error message to the client
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        /**
		 * HTTP POST method
		 * 
		 * Adds a new course to the database.
		 * 
		 * Must take Sub and ClassNumber attributes. 
		 * 
		 * [FromBody] because we are going to deserialize the parameters from the request body
		 * in JSON form.
		 */
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDTO courseDto)
        {
            try
            {
                // Pre error checking
                if (courseDto == null)
                {
                    return BadRequest("Course object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                // Creating a new course object to add to the DB
                var course = new Course
                {
                    Sub = courseDto.Sub,
                    ClassNumber = courseDto.ClassNumber
                };

                await _context.Courses.AddAsync(course); // Adding the course to the DB
                await _context.SaveChangesAsync(); // Saving changes to the DB

                return CreatedAtAction(nameof(GetCourse), new { id = course.CourseID }, course);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(500, "An unexpected error occurred while processing your request.");
            }
        }

    }
}
