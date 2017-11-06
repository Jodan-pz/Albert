using System.Collections.Generic;
using System.Linq;
using Albert.Common.Interfaces;
using Albert.Common.Model;
using Yoda.EntityFramework;

namespace Albert.DataLayer
{
    public class CourseQuerySpec : EFBaseQuerySpec<SchoolContext>, ICourseQuerySpec
    {
        public CourseQuerySpec() : base() { }
        public CourseQuerySpec(SchoolContext context) : base(context) { }

        public IEnumerable<Course> SuperQueryCourses()
        {
            var ret = Context.Courses;
            return ret.ToList();
        }

    }
}