using MerchantsApi.Database;
using MerchantsApi.Models;
using MerchantsApi.Requests;
using MerchantsApi.Responses;

namespace MerchantsApi.Repository
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly MerchantDbContext _merchantDbContext;

        public MerchantRepository(MerchantDbContext merchantDbContext)
        {
            _merchantDbContext = merchantDbContext;
        }

        public MerchantResponse GetMerchants(string? merchantData, int? page, int? pageSize, string? sortBy, string? sortOrder)
        {
            var defaultMerchantData = "";
            var defaultPageSize = 10f;
            var defaultSortOrder = "asc";
            var defaultPage = 1;
            var defaultSortBy = "";

            if(page != null) { defaultPage = (int)page; }
            if(pageSize != null) { defaultPageSize = (int)pageSize; }

            var merchants = _merchantDbContext.Merchants.ToList();
            var pageCount = Math.Ceiling(merchants.Count / defaultPageSize);

            if (merchantData != null && merchants.Count>0)
            {
                merchants = merchants.Where(x => x.fullName == merchantData).ToList();
                pageCount = Math.Ceiling(merchants.Count / defaultPageSize);
            }

            var merchantsPaged = merchants.Skip((defaultPage - 1) * (int)defaultPageSize).Take((int)defaultPageSize).ToList();

            //if(pageSize == null) { merchantsPaged = merchantsPaged.OrderByDescending(x => x.)}
            if(pageSize == null) { merchantsPaged = merchants; }

            MerchantResponse merchantResponse = new MerchantResponse
            {
                totalCount = merchants.Count,
                pageSize = (int)defaultPageSize,
                Merchants = merchantsPaged,
                totalPages = (int)pageCount,
                page = defaultPage,
                sortBy = defaultSortBy,
                sortOrder = defaultSortOrder,

            };

            return merchantResponse;
        }

        public void CreateMerchant(CreateMerchantRequest create_merchant)
        {
            var merchant = new Merchant();

            merchant.merchantCode = create_merchant.merchantCode;
            merchant.displayName = create_merchant.displayName;
            merchant.fullName = create_merchant.fullName;
            merchant.address = create_merchant.address;
            merchant.phoneNumber = create_merchant.phoneNumber;
            merchant.email = create_merchant.email;
            merchant.website = create_merchant.website;
            merchant.accountNumber = create_merchant.accountNumber;

            _merchantDbContext.Merchants.Add(merchant);
            _merchantDbContext.SaveChanges();

            //throw new NotImplementedException();
        }

        public void DeleteMerchant(string merchantCode)
        {
            var merchantFromDb = _merchantDbContext.Merchants.Where(x => x.merchantCode.Equals(merchantCode)).FirstOrDefault();
            //var merchantFromDb = _merchantDbContext.Merchants.Where(x => x.displayName.Equals(merchantCode)).FirstOrDefault();

            _merchantDbContext.Merchants.Remove(merchantFromDb);
            _merchantDbContext.SaveChanges();
            
            //throw new NotImplementedException();
        }

        public Merchant GetMerchantByMerchantCode(string merchantCode)
        {
            var merchant = _merchantDbContext.Merchants.Where(x => x.merchantCode.Equals(merchantCode)).FirstOrDefault();
            return merchant;
            

            //throw new NotImplementedException();
        }

        
        //public IEnumerable<Merchant> GetMerchants()
        //{
        //  return _merchantDbContext.Merchants.ToList();

        //throw new NotImplementedException();
        //}

        public bool UpdateMerchant(string merchantCode, CreateMerchantRequest create_merchant)
        {
            var merchantFromDb = _merchantDbContext.Merchants.Where(x => x.merchantCode.Equals(merchantCode)).FirstOrDefault();
            
            if (merchantFromDb == null) { return false; }

            //check if the merchantCode from the body is same with the merchantCode of the path
            if (!merchantFromDb.merchantCode.Equals(create_merchant.merchantCode)) { return false; }

            //updating the data
            merchantFromDb.displayName = create_merchant.displayName;
            merchantFromDb.fullName = create_merchant.fullName;
            merchantFromDb.address = create_merchant.address;
            merchantFromDb.phoneNumber = create_merchant.phoneNumber;
            merchantFromDb.email = create_merchant.email;
            merchantFromDb.website = create_merchant.website;
            merchantFromDb.accountNumber = create_merchant.accountNumber;

            _merchantDbContext.SaveChanges();

            return true;
            //throw new NotImplementedException();
        }
    }
}
