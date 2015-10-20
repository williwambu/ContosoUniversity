using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ContosoUniversity.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(50,MinimumLength = 1,ErrorMessage = "First Name Cannot be longer than 50 characters.")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public string FullName 
        {
            get { return LastName + ", " + FirstMidName; } 
        }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}