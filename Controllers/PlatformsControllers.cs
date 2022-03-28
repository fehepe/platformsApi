using Microsoft.AspNetCore.Mvc;
using RedisApi.Data;
using RedisApi.Models;

namespace RedisApi.Controllers
{
    [Route("api/platforms")]
    [ApiController]
    public class PlatformsControllers : ControllerBase
    {
        private readonly IPlatformRepo _repo;

        public PlatformsControllers(IPlatformRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<Platform> GetPlatformById(string id)
        {
            var platform = _repo.GetPlatformById(id);

            if(platform!= null)
                return Ok(platform);

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Platform> CreatePlatform(Platform p)
        {
            _repo.CreatePlatform(p);

            return CreatedAtRoute(nameof(GetPlatformById),new{Id = p.Id},p);
        }

         [HttpGet]
        public ActionResult<IEnumerable<Platform>> GetPlatforms()
        {
            return Ok(_repo.GetAllPlatforms());
        }
    }
}