
using System.Collections.Generic;

namespace Albert.Common.DTO
{
    public class StudentCourseDTO

    {
        public long ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<CourseDTO> Courses { get; set; }
    }

}