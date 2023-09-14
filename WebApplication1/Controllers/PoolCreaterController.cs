using Car_pooling.Interfaces;
using Car_pooling.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_pooling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoolCreaterController : ControllerBase
    {
        private IPoolCreater _poolCreater;

        public PoolCreaterController(IPoolCreater poolCreater)
        {
            _poolCreater = poolCreater;
        }

        [HttpGet]
        public async Task<ActionResult> GetPoolCreater(int id)
        {
            IEnumerable<PoolingCreater> data = await _poolCreater.getPoolDetails(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> AddPool(PoolingCreater pool)
        {
            Task<string> data=_poolCreater.CreatePool(pool);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);    
        }

        [HttpGet("/cities")]
        public async Task<IEnumerable<PoolingCreater>> GetRidecities()
        {

            IEnumerable<PoolingCreater> cityList= await _poolCreater.GetRideStartingcities();
            return cityList;

        }

        [HttpPost("/getride")]
        public async Task<IEnumerable<PoolingCreater>> GetRide(PoolingCreater pool)
        {
            IEnumerable<PoolingCreater> poolList=await _poolCreater.GetRidesByCities(pool);
            return poolList;
        }
    }
}
