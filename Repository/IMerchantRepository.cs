using MerchantsApi.Models;
using MerchantsApi.Requests;
using MerchantsApi.Responses;

namespace MerchantsApi.Repository
{
    public interface IMerchantRepository
    {
        public MerchantResponse GetMerchants(string? merchantData, int? page, int? pageSize, string? sortBy, string? sortOrder);

        //public IEnumerable<Merchant> GetMerchants();
        public Merchant GetMerchantByMerchantCode(string merchantCode);
        public void CreateMerchant(CreateMerchantRequest merchant);
        public bool UpdateMerchant(string merchantCode, CreateMerchantRequest merchant);
        public void DeleteMerchant(string merchantCode);
    }
}
