using Car_pooling.Models;

namespace Car_pooling.Interfaces
{
    public interface IPoolCreater
    {
         Task<string> CreatePool(PoolingCreater creater);
        Task<IEnumerable<PoolingCreater>> getPoolDetails(int id);

        Task<IEnumerable<PoolingCreater>> GetRideStartingcities();
        Task<IEnumerable<PoolingCreater>> GetRidesByCities(PoolingCreater pool);


    }
}
