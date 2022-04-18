using MerchantsApi.Models;
using MerchantsApi.Requests;
using MerchantsApi.Responses;

namespace MerchantsApi.Repository
{
    public interface IStoreRepository
    {
        //public IEnumerable<Store> GetStores(string merchantCode);
        public StoreResponse GetStores(string merchantCode, string? storeData, int? page, int? pageSize, string? sortBy, string? sortOrder);
        public void CreateStore(string merchantCode,CreateStoreRequest store);
        public Store GetStoreByStoreCode(string merchantCode,string storeCode);
        public bool UpdateStore(string merchantCode, string storeCode, CreateStoreRequest store);
        public void DeleteStore(string merchantCode, string storeCode);
    }
}
