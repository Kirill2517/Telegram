using HhLib.Resume.guider;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Telegram.Api.Share.Guides
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuiderController : ControllerBase
    {
        [HttpGet]
        [Route("resume/getresume/{id:int}")]
        public async Task<IActionResult> GetResumeById(int id)
        {
            GuidResumeManager resumeManager = new();
            return Ok(await resumeManager.GetResumeById(id));
        }
    }
}
