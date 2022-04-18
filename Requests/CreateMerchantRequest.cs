namespace MerchantsApi.Requests
{
    public class CreateMerchantRequest
    {
        public string merchantCode { get; set; }
        public string? displayName { get; set; }
        public string fullName { get; set; }
        public string? address { get; set; }
        public string? phoneNumber { get; set; }
        public string email { get; set; }
        public string? website { get; set; }
        public string accountNumber { get; set; }
    }
}
