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
        #region properties
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

        ILookupsService _lookupsService;
        ILookupsService LookupsService
        {
            get
            {
                if (_lookupsService == null)
                    _lookupsService = new LookupsService();
                return _lookupsService;
            }
        }
        #endregion

        [HttpGet]
        [Route("GetAllStudents")]
        public List<StudentDTO> GetAllStudents()
        {
            var result = StudentsService.GetAllStudents();
            return result;
        }

        [HttpGet]
        [Route("GetStudentById")]
        public StudentDTO GetStudentById(int StudentId)
        {
            var result = StudentsService.GetStudentById(StudentId);
            return result;
        }

        [HttpGet]
        [Route("GetAllGrades")]
        public List<LookupsDTO> GetAllGrades()
        {
            var result = LookupsService.GetAllGrades();
            return result;
        }

        [HttpGet]
        [Route("GetAllClasses")]
        public List<LookupsDTO> GetAllClasses()
        {
            var result = LookupsService.GetAllClasses();
            return result;
        }

        [HttpGet]
        [Route("GetClassesByGradeId")]
        public List<LookupsDTO> GetClassesByGradeId(int gradeId)
        {
            var result = LookupsService.GetAllClassesByGradeId(gradeId);
            return result;
        }
    }
}
