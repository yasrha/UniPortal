using System.ComponentModel.DataAnnotations;

namespace UniPortal.Models
{
    /**
     * Admin Model.
     * 
     * There will only be a single admin in this application.
     * The admin will be able to add/remove students and courses, view all courses, and view all students.
     */
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string PasswordHash { get; set; }  // Store hashed password
    }
}
