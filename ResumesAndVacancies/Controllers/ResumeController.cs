using BLL.DTO;
using BLL.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ResumesAndVacancies.Controllers
{
    public class ResumeController : ApiController
    {
        private readonly IResumeService _resumeService;

        public ResumeController(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        // GET: api/Resume
        public List<ResumeDTO> Get()
        {
            return _resumeService.GetResumes().ToList();
        }

        // GET: api/Resume/5
        public ResumeDTO Get(int id)
        {
            return _resumeService.GetResumeByID(id);
        }

        // POST: api/Resume
        public void Post([FromBody]ResumeDTO resumeDTO)
        {
            _resumeService.AddResume(resumeDTO);
        }

        // PUT: api/Resume/5
        public void Put(int id, [FromBody]ResumeDTO resumeDTO)
        {
            _resumeService.UpdateResume(id, resumeDTO);
        }

        // DELETE: api/Resume/5
        public void Delete(int id)
        {
            _resumeService.RemoveResumeByID(id);
        }
    }
}
