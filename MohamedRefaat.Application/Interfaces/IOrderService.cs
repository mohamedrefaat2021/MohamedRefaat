using MohamedRefaat.Application.DTOs.Order;
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
    public interface IOrderService
    {
        Task<ServiceResponse<PagedListResponse<ProductOrderDto>>> GetAllPagedListAsync(GetAllPaggedQuery request, ProductQueryCriteria filters);

        Task<ServiceResponse<ProductOrderDto>> AddAsync(ProductOrderDto dtoReq);
    }
}
