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
    public interface IAttachmentsService
    {
        string UploadAttachment(HttpRequest Request);
    }
}
