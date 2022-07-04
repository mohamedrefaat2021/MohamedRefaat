using Microsoft.AspNetCore.Mvc;
using MohamedRefaat.Application.DTOs.Applicant;
using MohamedRefaat.Application.Interfaces;
using MohamedRefaat.Application.ServiceQueryParams;

namespace MohamedRefaat.Api.Controllers
{
       [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {


        private readonly IProductService _productsSvc;

        public ProductController(IProductService productsSvc)
        {
            _productsSvc = productsSvc;
        }

      

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto createModel)
        {
            if (createModel == null)
                return BadRequest(ModelState);
            var res = await _productsSvc.AddAsync(createModel);
            if (!res.Succeeded)
                return BadRequest(res);

            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllPaggedQuery request = new GetAllPaggedQuery();
            return Ok(await _productsSvc.GetAllPagedListAsync(request, null));
        }

   
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDto model)
        {
            var res = await _productsSvc.UpdateAsync(model);
            if (!res.Succeeded)
                return BadRequest(res);
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _productsSvc.GetByIdAsync(id));
        }

        [HttpDelete("{Id}")]
        public bool Delete(int Id)
        {
            if( _productsSvc.Delete(Id))
            return true;
            else
                return false;
        }
    }
}