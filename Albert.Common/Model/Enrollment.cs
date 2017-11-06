using System;
using Yoda.Common.Interfaces;

namespace Albert.Common.Model
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {

        public int EnrollmentID { get; set; }
        public Grade? Grade { get; set; }

        public int CourseID { get; set; }
        public int StudentID { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }

}