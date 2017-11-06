using System.Collections.Generic;
using System.Linq;
using Albert.Common.DTO;
using Albert.Common.Interfaces;
using Albert.Common.Model;
using AutoMapper;
using Yoda.Common.Interfaces;

namespace Albert.Services
{
    public class SimpleService : ISimpleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SimpleService(IUnitOfWork uow, IMapper mapper) { _uow = uow; _mapper = mapper; }

        public IEnumerable<StudentCourseDTO> GetAllAStudents()
        {

            return _uow.GetQuerySpec<IStudentQuerySpec>().SuperQueryStudents()
                .Select(s => new StudentCourseDTO
                {
                    ID = s.StudentID,
                    Name = $"{s.LastName} {s.FirstMidName}",
                    Courses = s.Enrollments?.Select(e => _mapper.Map<CourseDTO>(e.Course)),
                });

            // var ret = this._uow.FindAll<Student>(
            //     student => student.LastName != null,
            //     2, 5,
            //     students => students.OrderByDescending(student => student.LastName),
            //     $"{nameof(Student.Enrollments)}.{nameof(Course)}"
            // ).Select(s => new StudentCourseDTO
            // {
            //     Id = s.Id,
            //     Name = $"{s.LastName} {s.FirstMidName}",
            //     CourseTitle = s.Enrollments?.Select(e => e.Course?.Title).Aggregate("", (a, n) => a += n + " ").Trim(),
            // });

            // return ret;
        }

        public long CountAllStudents()
        {
            var ret = this._uow.Count<Student>(
                student => student.LastName != null
            );
            return ret;
        }

        public StudentDTO GetStudent(int id)
        {
            var student = _uow.GetByKey<Student>(id);
            if (student != null) return _mapper.Map<StudentDTO>(student);
            return null;
        }

        public StudentDTO CreateStudent(StudentDTO student)
        {
            var newStudent = _mapper.Map<Student>(student);
            _uow.Add(newStudent);
            _uow.Save();
            return GetStudent(newStudent.StudentID);
        }

        public StudentDTO UpdateStudent(StudentDTO student)
        {
            var toUpdate = _mapper.Map<Student>(student);
            _uow.Update(toUpdate);
            _uow.Save();
            return GetStudent(toUpdate.StudentID);
        }

        public void DeleteStudent(object id)
        {
            _uow.DeleteByKey<Student>(id);
            _uow.Save();
        }

        public void DeleteFreeStudents()
        {
            var qs = _uow.GetQuerySpec<IStudentQuerySpec>();
            _uow.DeleteAll(qs.GetAllStudentsFree());
            _uow.Save();
        }
    }
}