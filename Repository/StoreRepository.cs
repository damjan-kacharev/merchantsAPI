using MerchantsApi.Database;
using MerchantsApi.Models;
using MerchantsApi.Requests;
using MerchantsApi.Responses;

namespace MerchantsApi.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly MerchantDbContext _merchantDbContext;

        public StoreRepository(MerchantDbContext merchantDbContext)
        {
            _merchantDbContext = merchantDbContext;
        }

        public void CreateStore(string merchantCode, CreateStoreRequest create_store)
        {
            var merchantFromDb = _merchantDbContext.Merchants.Where(x => x.merchantCode.Equals(merchantCode)).FirstOrDefault();

            var store = new Store();

            store.storeCode = create_store.storeCode;
            store.displayName = create_store.displayName;
            store.address = create_store.address;
            store.phoneNumber = create_store.phoneNumber;
            store.email = create_store.email;
            store.Merchant = merchantFromDb;

            //merchantFromDb.Stores.ToList().Add(store);
            //merchantFromDb.Stores.Append(store);
            

            _merchantDbContext.Stores.Add(store);
            _merchantDbContext.SaveChanges();

            //throw new NotImplementedException();
        }

        public void DeleteStore(string merchantCode, string storeCode)
        {

            var storeFromDb = _merchantDbContext.Stores.Where(x => x.Merchant.merchantCode.Equals(merchantCode)).Where(x => x.storeCode.Equals(storeCode)).FirstOrDefault();

            _merchantDbContext.Stores.Remove(storeFromDb);
            _merchantDbContext.SaveChanges();       

            //throw new NotImplementedException();
        }

        public Store GetStoreByStoreCode(string merchantCode, string storeCode)
        {
            var storeFromDb = _merchantDbContext.Stores.Where(x => x.Merchant.merchantCode.Equals(merchantCode)).Where(x => x.storeCode.Equals(storeCode)).FirstOrDefault();
            return storeFromDb; 

            //throw new NotImplementedException();
        }

        //public IEnumerable<Store> GetStores(string merchantCode)
        //{
            //var storesFromDb = _merchantDbContext.Stores.Where(x => x.Merchant.merchantCode.Equals(merchantCode)).ToList();
           // return storesFromDb;
        //}

        public StoreResponse GetStores(string merchantCode, string? storeData, int? page, int? pageSize, string? sortBy, string? sortOrder)
        {
            var defaultStoresData = "";
            var defaultPageSize = 10f;
            var defaultSortOrder = "asc";
            var defaultPage = 1;
            var defaultSortBy = "";

            if (page != null) { defaultPage = (int)page; }
            if (pageSize != null) { defaultPageSize = (int)pageSize; }

            var stores = _merchantDbContext.Stores.Where(x => x.Merchant.merchantCode.Equals(merchantCode)).ToList();
            var pageCount = Math.Ceiling(stores.Count / defaultPageSize);

            if (storeData != null && stores.Count > 0)
            {
                stores = stores.Where(x => x.displayName == storeData).ToList();
                pageCount = Math.Ceiling(stores.Count / defaultPageSize);
            }

            var storesPaged = stores.Skip((defaultPage - 1) * (int)defaultPageSize).Take((int)defaultPageSize).ToList();
            
            //if there is no value for pageSize
            if (pageSize == null) { storesPaged = stores; }

            StoreResponse storeResponse = new StoreResponse
            {
                totalCount = stores.Count,
                pageSize = (int)defaultPageSize,
                Stores = storesPaged,
                totalPages = (int)pageCount,
                page = defaultPage,
                sortBy = defaultSortBy,
                sortOrder = defaultSortOrder,

            };

            return storeResponse;
        }

        public bool UpdateStore(string merchantCode, string storeCode, CreateStoreRequest update_store)
        {
            var storeFromDb = _merchantDbContext.Stores.Where(x => x.Merchant.merchantCode.Equals(merchantCode)).Where(x => x.storeCode.Equals(storeCode)).FirstOrDefault();

            if (storeFromDb == null) { return false; }

            //check if the merchantCode from the body is same with the merchantCode of the path
            if (!storeFromDb.storeCode.Equals(update_store.storeCode)) { return false; }

            //updating the data
            storeFromDb.displayName = update_store.displayName;
            storeFromDb.storeCode = update_store.storeCode;
            storeFromDb.address = update_store.address;
            storeFromDb.phoneNumber = update_store.phoneNumber;
            storeFromDb.email = update_store.email;
            
            _merchantDbContext.SaveChanges();

            return true;
            //throw new NotImplementedException();
        }
        
    }
}
