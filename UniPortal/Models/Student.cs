using System.ComponentModel.DataAnnotations;

namespace UniPortal.Models
{
    /**
     * Student Model.
     * 
     * Students can login, and can enroll / drop courses, and view a list of all the courses they are enrolled in.
     * 
     * StudentID - Unique id number each student will get, they use this to login
     * Password - ...
     * FullName - ...
     * DateOfBirth - ...
     * 
     * StudentCourses - A list of all the courses the student is enrolled in
     *                - Everytime a student enrolls in a course, we create a new StudentCourse model, containing 
     *                  the StudentID of the student, and the CourseID of the course.
     * 
     */
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string PasswordHash { get; set; }  // Store hashed password
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
