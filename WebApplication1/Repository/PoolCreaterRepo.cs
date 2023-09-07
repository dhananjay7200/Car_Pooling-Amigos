using Car_pooling.Interfaces;
using Car_pooling.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace Car_pooling.Repository
{
    public class PoolCreaterRepo : IPoolCreater
    {
        private CarPoolingContext _context;
     

        public PoolCreaterRepo(CarPoolingContext context)
        {
            this._context = context;
        }
        public async Task<string> CreatePool(PoolingCreater creater)
        {
            if (creater == null)
            {
                return "fail to add pool";

            }
            try
            {
                    await _context.PoolingCreaters.AddAsync(creater);
                    _context.SaveChangesAsync();
              
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("error in reg" + ex.Message);
            }
            
            return "ok";
        }

        public async Task<IEnumerable<PoolingCreater>> getPoolDetails(int id)
        {
        List<PoolingCreater> poolList= await _context.PoolingCreaters.Where(x=>x.PoolCreaterIdFk== id).ToListAsync();
            return poolList;

        }


        public async Task<IEnumerable<PoolingCreater>> GetRideStartingcities()
        {
            List<PoolingCreater> citiesList = await _context.PoolingCreaters.ToListAsync();
            return citiesList;
        }


        public async Task<IEnumerable<PoolingCreater>> GetRidesByCities(PoolingCreater pool)
        {
            List<PoolingCreater> poolList=await _context.PoolingCreaters.Where(x=>x.StartingDestination==pool.StartingDestination && x.EndingDestination==pool.EndingDestination && x.PoolDate==pool.PoolDate).ToListAsync();
            return poolList;
        }
    }
}
