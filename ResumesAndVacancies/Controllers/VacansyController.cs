using BLL.DTO;
using BLL.Logic;
using System.Collections.Generic;
using System.Web.Http;

namespace ResumesAndVacancies.Controllers
{
    public class VacansyController : ApiController
    {
        private readonly IVacansyService _vacansyService;

        public VacansyController(IVacansyService vacansyService)
        {
            _vacansyService = vacansyService;
        }

        // GET: api/Vacansy
        public IEnumerable<VacansyDTO> Get()
        {
            return _vacansyService.GetVacancies();
        }

        // GET: api/Vacansy/5
        public VacansyDTO Get(int id)
        {
            return _vacansyService.GetVacansyByID(id);
        }

        // POST: api/Vacansy
        public void Post([FromBody]VacansyDTO vacansyDTO)
        {
            _vacansyService.AddVacansy(vacansyDTO);
        }

        // PUT: api/Vacansy/5
        public void Put(int id, [FromBody]VacansyDTO vacansyDTO)
        {
            _vacansyService.UpdateVacansy(id, vacansyDTO);
        }

        // DELETE: api/Vacansy/5
        public void Delete(int id)
        {
            _vacansyService.RemoveVacansyByID(id);
        }
    }
}
