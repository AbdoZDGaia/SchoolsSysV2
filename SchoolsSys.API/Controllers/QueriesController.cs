using SchoolsSys.BL.Converters;
using SchoolsSys.BL.DTOs;
using SchoolsSys.BL.LookupsAggregate;
using SchoolsSys.BL.Models;
using SchoolsSys.BL.Repository;
using SchoolsSys.BL.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace SchoolsSys.API.Controllers
{
    [RoutePrefix("api/Queries")]
    public class QueriesController : ApiController
    {
        IStudentsService _studentsService;

        IStudentsService StudentsService
        {
            get
            {
                if (_studentsService == null)
                    _studentsService = new StudentsService();
                return _studentsService;
            }
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public List<StudentDTO> GetAllStudents()
        {
            var result = StudentsService.GetAllStudents();
            return result;
        }

        [HttpGet]
        [Route("GetStudentsById")]
        public StudentDTO GetStudentsById(int StudentId)
        {
            var result = StudentsService.GetStudentsById(StudentId);
            return result;
        }

        [HttpGet]
        [Route("GetAllGrades")]
        public List<LookupsDTO> GetAllGrades()
        {
            var _ctx = new SchoolsSysDBContext();
            var aggr = new LookupAggregate(_ctx);
            var result = aggr.GetAllGrades();
            return result;
        }

        [HttpGet]
        [Route("GetAllClasses")]
        public List<LookupsDTO> GetAllClasses()
        {
            var _ctx = new SchoolsSysDBContext();
            var aggr = new LookupAggregate(_ctx);
            var result = aggr.GetAllClasses();
            return result;
        }

        [HttpGet]
        [Route("GetClassesByGradeId")]
        public List<LookupsDTO> GetClassesByGradeId(int gradeId)
        {
            var _ctx = new SchoolsSysDBContext();
            var aggr = new LookupAggregate(_ctx);
            var result = aggr.GetAllClassesByGradeId(gradeId);
            return result;
        }
    }
}
