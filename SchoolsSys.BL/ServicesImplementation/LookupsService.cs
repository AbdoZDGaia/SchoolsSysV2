using SchoolsSys.BL.DTOs;
using SchoolsSys.BL.Models;
using SchoolsSys.BL.UnitOfWork;
using System.Collections.Generic;

namespace SchoolsSys.BL.LookupsAggregate
{
    public class LookupsService : ILookupsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LookupsService()
        {
            _unitOfWork = new UnitOfWork.UnitOfWork(new SchoolsSysDBContext());
        }

        public List<LookupsDTO> GetAllGrades()
        {
            var mgr = new LookupsManager(_unitOfWork);
            var result = mgr.GetAllGrades();
            return result;
        }

        public List<LookupsDTO> GetAllClasses()
        {
            var mgr = new LookupsManager(_unitOfWork);
            var result = mgr.GetAllClasses();
            return result;
        }

        public List<LookupsDTO> GetAllClassesByGradeId(int gradeId)
        {
            var mgr = new LookupsManager(_unitOfWork);
            var result = mgr.GetAllClassesByGradeId(gradeId);
            return result;
        }
    }
}
