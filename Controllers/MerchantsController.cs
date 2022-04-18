using MerchantsApi.Models;
using MerchantsApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MerchantsApi.Requests;
using MerchantsApi.Responses;

namespace MerchantsApi.Controllers
{
    [Route("api/merchants")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        private readonly IMerchantRepository _merchantRepository;
        
        public MerchantsController(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        [HttpGet]
        public ActionResult<MerchantResponse> GetMerchants([FromQuery] string? merchantData, int? page, int? pageSize, string? sortBy, string? sortOrder)
        {
            return _merchantRepository.GetMerchants(merchantData, page, pageSize, sortBy, sortOrder);
        }

        [HttpPost]
        public ActionResult CreateMerchant([FromBody] CreateMerchantRequest merchant)
        {
            _merchantRepository.CreateMerchant(merchant);
            return Ok(); 
        }

        //variable that is in the path, ex. merchants/1
        //if it was just ("merchantCode") that would be merchants/merchantCode path
        [HttpGet("{merchantCode}")]
        public ActionResult<Merchant> GetMerchantByMerchantCode([FromRoute] string merchantCode)
        {
            var merchant = _merchantRepository.GetMerchantByMerchantCode(merchantCode);
            
            if(merchant == null) { return NotFound(); }

            return Ok(merchant); 
        }

        //we use put because with it we send whole object, patch is used for some parameters
        [HttpPut("{merchantCode}")]
        public ActionResult UpdateMerchant([FromRoute] string merchantCode,[FromBody] CreateMerchantRequest merchant)
        {
            var update = _merchantRepository.UpdateMerchant(merchantCode, merchant);

            if(!update) { return NotFound(); }
            return Ok();
        }

        //[HttpGet]
        //public ActionResult GetFilteredMerchants([FromQuery] all needed parameters)

        [HttpDelete("{merchantCode}")]
        public ActionResult DeleteMerchant([FromRoute] string merchantCode)
        {
            _merchantRepository.DeleteMerchant(merchantCode);
            return Ok();
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Merchant>> GetMerchants()
        //{

            //return _merchantRepository.GetMerchants().ToList();
        //}

        
    }
}
