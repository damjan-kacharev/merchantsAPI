using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MerchantsApi.Models
{
    public class Store
    {
        //required properties cannot be nullable 
        //not required properties can be nullable (type? nameVariable)
        //storeCode is the primary key for Store
        [Key, Required]
        public string storeCode { get; set; }
        //public string merchantCode { get; set; }
        [Required]
        public string displayName { get; set; }
        public string? address { get; set; }
        public string? phoneNumber { get; set; }
        [Required]
        public string email { get; set; }

        //defining the relationship between Merchant and Store
        //[ForeignKey("merchantCode")]

        //we will use merchantCodeFk when we try to create new Store
        //next we check if there is any merchantCode == merchantCodeFK
        //if that is true, we append the new Store to the Merchant with that merchantCode...

        //we can use merchantCodeFk in StoreRequest for example to check if there is some merchantCode == merchantCodeFk       ------merchantCodeFk.equals(merchantCode)
        //public string merchantCodeFK { get; set; }

        //public string merchantCode { get; set; }
        public Merchant Merchant { get; set; }
    }
}
