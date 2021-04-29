using SchoolsSys.BL.DTOs;
using System.Collections.Generic;

namespace SchoolsSys.BL.LookupsAggregate
{
    public interface ILookupsService
    {
        List<LookupsDTO> GetAllClasses();
        List<LookupsDTO> GetAllClassesByGradeId(int gradeId);
        List<LookupsDTO> GetAllGrades();
    }
}