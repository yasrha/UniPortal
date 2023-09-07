using System.ComponentModel.DataAnnotations;

namespace UniPortal.Models
{
    /**
     * StudentCourse Model (JunctionTable).
     * This model serves as the junction between Student and Course.
     * 
     * In this application, students are able to enroll in multiple courses, and courses can have 
     * multiple students enrolled in them. In relational databases, this is called a many-to-many 
     * relationship, multiple records in one table are associated with multiple records in another 
     * table. The relationship between Student and Course cannot be represented with only 2 tables.
     * 
     * To represent a many-to-many relationship, we use a third table, often called a junction table. 
     * This table breaks down the many-to-many relationship into two one-to-many relationships.
     * 
     * Junction tables allow for efficient queries. For example, if we wnat to find all the courses a 
     * student is enrolled in, you look up all the entries in the StudentCourse table for that student's 
     * ID and retrieve the associated courses. Or, if we want to find all the students enrolled in a 
     * specific course, you do the reverse: look up all entries in the StudentCourse table for that 
     * course's ID and retrieve the associated students.
     * 
     * The StudentID and CourseID establish the relationship (i.e., which student is enrolled in which 
     * course), while the Student and Course navigation properties provide an easy way to traverse the 
     * relationship in your code without having to make additional explicit database queries.
     * 
     * Exampele of the StudentCourse table:
     * 
     * StudentCourseID | StudentID | StudentName | CourseID | CourseName
     * ----------------|-----------|-------------|----------|-----------
     *        1	       |     1	   | Alice Smith |     1	|  MAT 101
     *        2	       |     1	   | Alice Smith |     3	|  PHY 303
     *        3	       |     2	   | Bob Johnson |     2	|  EGL 202
     *        4	       |     2	   | Bob Johnson |     3	|  PHY 303
     *        5	       |     3	   | John Brown	 |     1	|  MAT 101
     *        
     * NOTE: In the real database, the StudentName and CourseName columns would not be part of the StudentCourse 
     * table. They are added here only for clarity.
     */
    public class StudentCourse
    {
        [Key]
        // The primary key of the StudentCourse model. Every time a student enrolls in a course a new
        // record is created.
        public int StudentCourseID { get; set; }

        // Foreign key to the Student table. This refers to the ID of the student enrolling in a course.
        // This property creates a link between an enrollment record and a specific student.
        public int StudentID { get; set; }

        // Navigation property related to the Student entity. This property allows you to navigate from
        // a StudentCourse entity directly to the associated Student entity. Instead of using the StudentID
        // to manually fetch the student, you can use this property to get the student entity directly.
        public Student Student { get; set; }

        // Foreign key to the Course table. This refers to the ID of the course a student is enrolling in.
        // This property creates a link between an enrollment record and a specific student.
        public int CourseID { get; set; }

        // Navigation property related to the Course entity. This allows you to navigate from a StudentCourse
        // entity directly to the associated course entity.
        public Course Course { get; set; }
    }
}
