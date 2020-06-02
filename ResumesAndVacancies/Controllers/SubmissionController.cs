using BLL.DTO;
using BLL.Logic;
using DAL.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ResumesAndVacancies.Controllers
{
    public class SubmissionController : ApiController
    {
        private readonly IResumeService _resumeService;

        public SubmissionController(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        // GET: api/Submission
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Submission/5
        public IEnumerable<Vacansy> Get(int id)
        {
            return _resumeService.GetResumesVacancies(id);
        }

        // POST: api/Submission
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Submission/5
        public void Put(int id, [FromBody]VacansyDTO vacansyDTO)
        {
            _resumeService.AddVacansyToResume(id, vacansyDTO);
        }

        // DELETE: api/Submission/5
        public void Delete(int id)
        {
        }
    }
}
