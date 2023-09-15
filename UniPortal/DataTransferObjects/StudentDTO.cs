using System.ComponentModel.DataAnnotations;

namespace UniPortal.DataTransferObjects
{
    public class StudentDTO
    {
        [Required]
        public int StudentID { get; set; }
        [Required]
        public string PasswordHash {  get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime DateOfBirth {  get; set; }
    }
}
