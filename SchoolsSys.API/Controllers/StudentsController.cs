using SchoolsSys.BL.Converters;
using SchoolsSys.BL.DTOs;
using SchoolsSys.BL.Repository;
using SchoolsSys.BL.UnitOfWork;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace SchoolSys.API.Controllers
{
    [RoutePrefix("api/Students")]
    public class StudentsController : ApiController
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


        [HttpPost]
        [Route("CreateStudent")]
        public StudentDTO CreateStudent(StudentDTO student)
        {
            if (student == null || student.StudentId > 0)
            {
                return new StudentDTO();
            }
            return StudentsService.CreateStudent(student);
        }

        [HttpPost]
        [Route("Upload")]
        public string Upload()
        {
            var result = StudentsService.UploadProfileImage(HttpContext.Current.Request);

            switch (result)
            {
                case "Failed":
                    return "";
                default:
                    return result;
            }
        }

        [HttpPost]
        [Route("UploadFiles")]
        public List<string> UploadFiles()
        {
            var result = StudentsService.UploadAttachments(HttpContext.Current.Request);
            return result;
        }
    }
}
