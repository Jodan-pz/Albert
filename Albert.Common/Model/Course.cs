using System.Collections.Generic;
using Yoda.Common.Interfaces;

namespace Albert.Common.Model
{
    public class Course
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }

}