using SchoolsSys.BL.UnitOfWork;
using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace SchoolsSys.BL.Repository
{
    internal class AttachmentsManager
    {
        private IUnitOfWork _unitOfWork;

        public AttachmentsManager()
        {
        }

        public AttachmentsManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        internal string UploadAttachment(HttpRequest request)
        {
            try
            {
                var file = request.Files[0];
                var folderName = ConfigurationManager.AppSettings["AttachmentsUploads"];
                var pathToSave = Path.Combine(HttpContext.Current.Server.MapPath("~/"), folderName);

                if (!Directory.Exists(pathToSave))
                    Directory.CreateDirectory(pathToSave);

                if (file.ContentLength > 0)
                {
                    var fileName = file.FileName.Trim('"');
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
    }
}