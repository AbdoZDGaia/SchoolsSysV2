using SchoolsSys.BL.Converters;
using SchoolsSys.BL.DTOs;
using SchoolsSys.BL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolsSys.BL.LookupsAggregate
{
    internal class LookupsManager
    {
        private IUnitOfWork _unitOfWork;

        public LookupsManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        internal List<LookupsDTO> GetAllGrades()
        {
            try
            {
                return _unitOfWork.GradesRepo.Get().Select(g => g.ConvertToGradeDTO()).ToList();
            }
            catch (Exception ex)
            {
                //elma to be implemented
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
                throw;
            }
        }

        internal List<LookupsDTO> GetAllClasses()
        {
            try
            {
                return _unitOfWork.ClassesRepo.Get().Select(g => g.ConvertToClassDTO()).ToList();
            }
            catch (Exception ex)
            {
                //elma to be implemented
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
                throw;
            }
        }

        internal List<LookupsDTO> GetAllClassesByGradeId(int gradeId)
        {
            try
            {
                return _unitOfWork.ClassesRepo.Get(filter:c => c.GradeId == gradeId).ToList().Select(g => g.ConvertToClassDTO()).ToList();
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