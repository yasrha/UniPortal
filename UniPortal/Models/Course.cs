using System.ComponentModel.DataAnnotations;

namespace UniPortal.Models
{
    /**
     * Course model
     * 
     * CourseID - Unique to every course
     * Subject - Examples: CSE, ISE, PHY, BIO...
     * ClassNumber - Examples: 123, 220, 132, 416...
     * 
     */
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Sub { get; set; }
        public int ClassNumber { get; set; }
    }
}
