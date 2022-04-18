using MerchantsApi.Models;

namespace MerchantsApi.Responses
{
    public class MerchantResponse
    {
        public int totalCount { get; set; }
        public int pageSize { get; set; }
        public int page { get; set; }
        public int totalPages { get; set; }
        public string sortOrder { get; set; }
        public string sortBy { get; set; }
        public List<Merchant> Merchants { get; set; }
    }
}
