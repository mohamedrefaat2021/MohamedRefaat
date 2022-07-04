using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MohamedRefaat.Application.DTOs.Applicant;
using MohamedRefaat.Application.Interfaces;
using MohamedRefaat.Application.ServiceQueryParams;

namespace MohamedRefaat.Api.Controllers
{
    [Route("api/v{version:apiVersion}/Applicant")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {

        private readonly IApplicantService _ApplicantsSvc;

        public ApplicantController(IApplicantService ApplicantsSvc)
        {
            _ApplicantsSvc = ApplicantsSvc;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _ApplicantsSvc.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicantDto createModel)
        {
            if (createModel == null)
                return BadRequest(ModelState);
            var res = await _ApplicantsSvc.AddAsync(createModel);
            if (!res.Succeeded)
                return BadRequest(res);

            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApplicant([FromQuery] GetAllPaggedQuery request)
        {
            return Ok(await _ApplicantsSvc.GetAllPagedListAsync(request, null));
        }
       
        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] GetAllPaggedQuery request, [FromQuery] ApplicantQueryCriteria filters)
        {
            return Ok(await _ApplicantsSvc.GetAllPagedListAsync(request, filters));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ApplicantDto model)
        {
            var res = await _ApplicantsSvc.UpdateAsync(model);
            if (!res.Succeeded)
                return BadRequest(res);
            return Ok(res);
        }
    }
}
