using SchoolsSys.BL.Converters;
using SchoolsSys.BL.DTOs;
using SchoolsSys.BL.Models;
using SchoolsSys.BL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SchoolsSys.BL.Repository
{
    public class AttachmentsService : IAttachmentsService
    {
        private readonly SchoolsSysDBContext _ctx;
        private readonly IUnitOfWork _unitOfWork;

        public AttachmentsService()
        {
            _ctx = new SchoolsSysDBContext();
            _unitOfWork = new UnitOfWork.UnitOfWork(_ctx);
        }


        public string UploadAttachment(HttpRequest Request)
        {
            var mgr = new AttachmentsManager();
            return mgr.UploadAttachment(Request);
        }
    }
}
