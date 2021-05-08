using SchoolsSys.BL.DTOs;
using SchoolsSys.BL.Models;
using SchoolsSys.BL.UnitOfWork;
using System.Collections.Generic;
using System.Web;

namespace SchoolsSys.BL.Repository
{
    public class StudentsService : IStudentsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentsService()
        {
            _unitOfWork = new UnitOfWork.UnitOfWork(new SchoolsSysDBContext());
        }

        public string UploadProfileImage(HttpRequest Request)
        {
            var mgr = new StudentsManager();
            var result = mgr.UploadProfileImage(Request);
            return result;
        }

        public List<string> UploadAttachments(HttpRequest Request)
        {
            var mgr = new StudentsManager();
            var result = mgr.UploadAttachments(Request);
            return result;
        }

        public List<StudentDTO> GetAllStudents()
        {
            var mgr = new StudentsManager(_unitOfWork);
            var result = mgr.GetAllStudents();
            return result;
        }

        public StudentDTO GetStudentById(int studentId)
        {
            var mgr = new StudentsManager(_unitOfWork);
            var result = mgr.GetStudentsById(studentId);
            return result;
        }

        public List<StudentDTO> GetAllStudentsPaging(int pageIndex, int pageSize)
        {
            var mgr = new StudentsManager(_unitOfWork);
            var result = mgr.GetAllStudentsPaging(pageIndex, pageSize);
            return result;

        }

        public StudentDTO CreateStudent(StudentDTO student)
        {
            var mgr = new StudentsManager(_unitOfWork);
            return mgr.CreateStudent(student);
        }
    }
}
