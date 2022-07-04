using Microsoft.AspNetCore.Mvc;
using MohamedRefaat.Application.DTOs.Applicant;
using MohamedRefaat.Application.DTOs.Order;
using MohamedRefaat.Application.Interfaces;
using MohamedRefaat.Application.ServiceQueryParams;

namespace MohamedRefaat.Api.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class  OrderController : ControllerBase
    {


        private readonly IOrderService _ordersSvc;

        public OrderController(IOrderService ordersSvc)
        {
            _ordersSvc = ordersSvc;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllPaggedQuery request = new GetAllPaggedQuery();
            return Ok(await _ordersSvc.GetAllPagedListAsync(request,null));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductOrderDto createModel)
        {
            createModel.OrderId = 2;  // Test 
            if (createModel == null)
                return BadRequest(ModelState);
            var res = await _ordersSvc.AddAsync(createModel);
            if (!res.Succeeded)
                return BadRequest(res);

            return Ok(res);
        }


    }
}