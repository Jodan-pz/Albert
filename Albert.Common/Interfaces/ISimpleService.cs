using System.Collections.Generic;
using Albert.Common.DTO;

namespace Albert.Common.Interfaces
{
    public interface ISimpleService
    {
        IEnumerable<StudentCourseDTO> GetAllAStudents();
        long CountAllStudents();
        StudentDTO GetStudent(int id);
        StudentDTO CreateStudent(StudentDTO student);
        StudentDTO UpdateStudent(StudentDTO student);
        void DeleteStudent(object id);
        void DeleteFreeStudents();
    }

}