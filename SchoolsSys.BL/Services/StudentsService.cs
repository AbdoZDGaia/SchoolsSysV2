using SchoolsSys.BL.Converters;
using SchoolsSys.BL.DTOs;
using SchoolsSys.BL.Models;
using SchoolsSys.BL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace SchoolsSys.BL.Repository
{
    public class StudentsService : IStudentsService
    {
        private readonly SchoolsSysDBContext _ctx;
        private readonly IUnitOfWork _unitOfWork;

        public StudentsService()
        {
            _ctx = new SchoolsSysDBContext();
            _unitOfWork = new UnitOfWork.UnitOfWork(_ctx);
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

        public StudentDTO GetStudentsById(int studentId)
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
