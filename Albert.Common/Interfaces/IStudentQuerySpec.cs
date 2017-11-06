using System.Collections.Generic;
using Albert.Common.Model;
using Yoda.Common.Interfaces;

namespace Albert.Common.Interfaces
{
    public interface IStudentQuerySpec : IQuerySpec
    {
        IEnumerable<Student> SuperQueryStudents();
        IEnumerable<Student> GetAllStudentsFree();
    }
}