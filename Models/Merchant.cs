using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchantsApi.Models
{
    public class Merchant
    {
        //required properties cannot be nullable 
        //not required properties can be nullable (type? nameVariable)
        //we must type [Key] because if the name is not Id, we must define PrimaryKey for the MerchantDataBase
        [Key,Required]
        public string merchantCode {get; set;}
        public string? displayName {get; set;}
        [Required]
        public string fullName { get; set;}
        public string? address {get; set;}
        public string? phoneNumber {get; set;}
        [Required]
        public string email {get; set;}
        public string? website {get; set;}
        [Required]
        public string accountNumber { get; set;}


        //defining the connection between Merchant and Store    
        public IEnumerable<Store> Stores { get; set; } = new List<Store>();


       
    }
}
