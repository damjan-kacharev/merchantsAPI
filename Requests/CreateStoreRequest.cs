namespace MerchantsApi.Requests
{
    public class CreateStoreRequest
    {
        public string storeCode { get; set; }
        public string displayName { get; set; }
        public string? address { get; set; }
        public string? phoneNumber { get; set; }
        public string email { get; set; }
    }
}
