using BLL.DTO;
using DAL.Models;
using System.Collections.Generic;

namespace BLL.Logic
{
    public interface IVacansyService
    {
        ICollection<VacansyDTO> GetVacancies();

        VacansyDTO GetVacansyByID(int id);

        void AddVacansy(VacansyDTO vacansyDto);

        void UpdateVacansy(int id, VacansyDTO vacansyDto);

        void RemoveVacansyByID(int id);
    }
}
