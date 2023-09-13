﻿using System.ComponentModel.DataAnnotations;

namespace UniPortal.DataTransferObjects
{
    public class CourseDTO
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public int ClassNumber { get; set; }
    }

}