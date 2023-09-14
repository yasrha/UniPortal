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


    }
}
