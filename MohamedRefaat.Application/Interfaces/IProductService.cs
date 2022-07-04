using MohamedRefaat.Application.DTOs.Applicant;
using MohamedRefaat.Application.ServiceQueryParams;
using MohamedRefaat.Domain.Helper;
using MohamedRefaat.Domain.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohamedRefaat.Application.Interfaces
{
    public interface IProductService
    {

        Task<ServiceResponse<PagedListResponse<ProductDto>>> GetAllPagedListAsync(GetAllPaggedQuery request, ProductQueryCriteria filters);
        Task<ServiceResponse<ProductDto>> AddAsync(ProductDto dtoReq);
        Task<ServiceResponse<bool>> UpdateAsync(ProductDto dtoReq);

        Task<ServiceResponse<ProductDto>> GetByIdAsync(int id);
        bool Delete(int Id);
    }
}
