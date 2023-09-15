using System.ComponentModel.DataAnnotations;

namespace UniPortal.DataTransferObjects
{
    public class CourseDTO
    {
        [Required]
        public int CourseID { get; set; }
        [Required]
        public string Sub { get; set; }
        [Required]
        public int ClassNumber { get; set; }
    }

}
