using SchoolsSys.BL.DTOs;
using SchoolsSys.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SchoolsSys.BL.Repository
{
    public interface IStudentsService 
    {
        List<StudentDTO> GetAllStudents();
        List<StudentDTO> GetAllStudentsPaging(int pageIndex,int pageSize);
        StudentDTO GetStudentsById(int id);
        string UploadProfileImage(HttpRequest Request);
        List<string> UploadAttachments(HttpRequest Request);
        StudentDTO CreateStudent(StudentDTO student);
    }
}
