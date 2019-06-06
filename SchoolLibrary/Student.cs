using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolLibrary
{
    public class Student
    {

        public string StudentId { get; set; }

        [Required]

        public string FirstName { get; set; }

        [Required]

        public string LastName { get; set; }

        [Required]

        public string School { get; set; }

    }
}
