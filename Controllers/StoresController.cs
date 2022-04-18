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
    public class StoresController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;

        public StoresController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        //[HttpGet("{merchantCode}/stores")]
        //public ActionResult<IEnumerable<Store>> GetStores([FromRoute] string merchantCode)
        //{

        //return _storeRepository.GetStores(merchantCode).ToList();
        //}

        [HttpGet("{merchantCode}/stores")]
        public ActionResult<StoreResponse> GetMerchants([FromRoute] string merchantCode,[FromQuery] string? storeData, int? page, int? pageSize, string? sortBy, string? sortOrder)
        {
           return _storeRepository.GetStores(merchantCode, storeData, page, pageSize, sortBy, sortOrder);
        }

        [HttpPost("{merchantCode}/stores")]
        public ActionResult CreateStore([FromRoute] string merchantCode,[FromBody] CreateStoreRequest store)
        {
            _storeRepository.CreateStore(merchantCode, store);
            
            return Ok();
        }

        [HttpGet("{merchantCode}/stores/{storeCode}")]
        public ActionResult<Store> GetStoreByStoreCode([FromRoute] string merchantCode, [FromRoute] string storeCode)
        {
            var store =_storeRepository.GetStoreByStoreCode(merchantCode, storeCode);

            return store;
        }

        [HttpPut("{merchantCode}/stores/{storeCode}")]
        public ActionResult UpdateStore([FromRoute] string merchantCode, [FromRoute] string storeCode, [FromBody] CreateStoreRequest update_store)
        {
            var update = _storeRepository.UpdateStore(merchantCode, storeCode, update_store);

            if (!update) { return NotFound(); }

            return Ok();
        }

        [HttpDelete("{merchantCode}/stores/{storeCode}")]
        public ActionResult DeleteStore([FromRoute] string merchantCode, [FromRoute] string storeCode)
        {
            _storeRepository.DeleteStore(merchantCode, storeCode);
            return Ok();
        }

    }
}
