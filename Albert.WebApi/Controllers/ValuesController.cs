using System.Collections.Generic;
using Albert.Common.DTO;
using Albert.Common.Interfaces;
using Albert.Common.Model;
using Microsoft.AspNetCore.Mvc;
using Yoda.Common.Interfaces;

namespace Albert.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ISimpleService _simpleService;
        private readonly IUnitOfWork _uow;

        public ValuesController(ISimpleService simpleService, IUnitOfWork uow)
        {
            _simpleService = simpleService;
            _uow = uow;
        }

        // GET api/values
        [HttpGet()]
        public IEnumerable<StudentCourseDTO> Get()
        {
            return _simpleService.GetAllAStudents();
        }

        // GET api/values/course/page
        [HttpGet("course/page/{pageIndex}")]
        public IEnumerable<Course> GetPage(int pageIndex)
        {
            var t = _uow.FindAll<Course>(null, pageIndex, 2);
            return t;
        }

        // GET api/values/course/queryspec
        [HttpGet("course/queryspec")]
        public IEnumerable<Course> GetByQuerySpec()
        {
            var t = _uow.GetQuerySpec<ICourseQuerySpec>();
            var courses = t.SuperQueryCourses();
            return courses;
        }

        // GET api/values/queryspec2
        [HttpGet("queryspec2")]
        public IEnumerable<Student> GetByQuerySpec2()
        {
            var t = _uow.GetQuerySpec<IStudentQuerySpec>();
            var ret = t.SuperQueryStudents();
            return ret;
        }

        // GET api/values/count
        [HttpGet("count")]
        public long CountAllStudents()
        {
            return _simpleService.CountAllStudents();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public StudentDTO Get(int id)
        {
            return _simpleService.GetStudent(id);
        }

        // POST api/values
        [HttpPost]
        public StudentDTO Post([FromForm] StudentDTO student)
        {
            return _simpleService.CreateStudent(student);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm]StudentDTO student)
        {
            student.StudentID = id;
            _simpleService.UpdateStudent(student);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _simpleService.DeleteStudent(id);
        }

        // DELETE api/values/AllFree
        [HttpDelete("AllFree")]
        public void DeleteFree(int id)
        {
            _simpleService.DeleteFreeStudents();
        }
    }
}
