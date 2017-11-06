using System.Collections.Generic;
using System.Linq;
using Albert.Common.Interfaces;
using Albert.Common.Model;
using Microsoft.EntityFrameworkCore;
using Yoda.EntityFramework;

namespace Albert.DataLayer
{
    public class StudentQuerySpec : EFBaseQuerySpec<SchoolContext>, IStudentQuerySpec
    {
        public StudentQuerySpec() : base() { }
        public StudentQuerySpec(SchoolContext context) : base(context) { }

        public IEnumerable<Student> GetAllStudentsFree()
        {
            var ret = from s in Context.Students
                      where !s.Enrollments.Any()
                      select s;
            return ret.ToList();
        }

        public IEnumerable<Student> SuperQueryStudents()
        {
            var ret = Context.Students.Include(s => s.Enrollments).ThenInclude(e => e.Course);
            return ret.ToList();
        }
    }
}