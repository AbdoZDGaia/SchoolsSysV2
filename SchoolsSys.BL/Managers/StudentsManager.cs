using SchoolsSys.BL.Converters;
using SchoolsSys.BL.DTOs;
using SchoolsSys.BL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace SchoolsSys.BL.Repository
{
    internal class StudentsManager
    {
        private IUnitOfWork uoW;

        public StudentsManager(IUnitOfWork _uoW)
        {
            uoW = _uoW;
        }

        public StudentsManager()
        {
        }

        internal string UploadProfileImage(HttpRequest request)
        {
            try
            {
                var file = request.Files[0];
                var folderName = ConfigurationManager.AppSettings["Temp"];
                var pathToSave = Path.Combine(HttpContext.Current.Server.MapPath("~/"), folderName);

                if (!Directory.Exists(pathToSave))
                    Directory.CreateDirectory(pathToSave);

                if (file.ContentLength > 0)
                {
                    var fileName = Guid.NewGuid() + file.FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    file.SaveAs(fullPath);

                    return dbPath;
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception ex)
            {
                //elma to be implemented
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
                throw;
            }
        }

        internal StudentDTO GetStudentsById(int studentId)
        {
            try
            {
                var result = uoW.StudentsRepo.GetByID(studentId).ConvertToStudentDTO();
                return result;
            }
            catch (Exception ex)
            {
                //elma to be implemented
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
                throw;
            }
        }

        internal StudentDTO CreateStudent(StudentDTO student)
        {
            try
            {
                var addedStudent = EntityConverters.PopulateNewStudentFromDTO(student);
                addedStudent.AddedOn = DateTime.Now;
                uoW.StudentsRepo.Add(addedStudent);
                uoW.Commit();
                return student;
            }
            catch (Exception ex)
            {
                //elma to be implemented
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
                throw;
            }
        }

        internal List<StudentDTO> GetAllStudentsPaging(int pageIndex, int pageSize)
        {
            try
            {
                var result = uoW.StudentsRepo.Get(includeProperties: "Attachments,Class,Grade",
                skip: (pageIndex - 1) * pageSize,
                take: pageSize).Select(s => s.ConvertToStudentDTO()).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
                throw;
            }
        }

        internal List<StudentDTO> GetAllStudents()
        {
            try
            {
                var result = uoW.StudentsRepo.Get(includeProperties: "Attachments,Class,Grade").Select(g => g.ConvertToStudentDTO()).ToList();
                return result;
            }
            catch (Exception ex)
            {
                //elma to be implemented
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
                throw;
            }
        }

        internal List<string> UploadAttachments(HttpRequest request)
        {
            try
            {
                var files = request.Files;
                List<string> filesAdded = new List<string>();
                var folderName = ConfigurationManager.AppSettings["Temp"];
                var pathToSave = Path.Combine(HttpContext.Current.Server.MapPath("~/"), folderName);
                var httpRequest = HttpContext.Current.Request;

                if (!Directory.Exists(pathToSave))
                    Directory.CreateDirectory(pathToSave);

                foreach (string file in files)
                {
                    var postedFile = httpRequest.Files[file];
                    if (postedFile.ContentLength > 0)
                    {
                        var fileName = Guid.NewGuid() + postedFile.FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);
                        postedFile.SaveAs(fullPath);
                        filesAdded.Add(dbPath);
                    }
                }

                return filesAdded;
            }
            catch (Exception ex)
            {
                //elma to be implemented
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
                throw;
            }
        }
    }
}