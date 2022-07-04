using AutoMapper;
using LinqKit;
using MohamedRefaat.Application.DTOs.Order;
using MohamedRefaat.Application.Interfaces;
using MohamedRefaat.Application.ServiceQueryParams;
using MohamedRefaat.Domain.Helper;
using MohamedRefaat.Domain.IRepository;
using MohamedRefaat.Domain.Models.Order;
using MohamedRefaat.Domain.Models.Paging;
using MohamedRefaat.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohamedRefaat.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork<ProductOrder> _unitOfWork;        
        private readonly IMapper _mapper;
        private string Includes = $"{nameof(ProductOrder.Product)}";
        public OrderService(IUnitOfWork<ProductOrder> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<PagedListResponse<ProductOrderDto>>> GetAllPagedListAsync(GetAllPaggedQuery request, ProductQueryCriteria filters)
        {
            var data = await _unitOfWork.Repository.GetAllPagedListAsync(BuildOrderSearchCriteria(filters), request.PageNumber, request.PageSize, Includes); ;
            var mappedData = _mapper.Map<PagedListResponse<ProductOrderDto>>(data);
            return ServiceResponse<PagedListResponse<ProductOrderDto>>.Success(mappedData);
        }

        public async Task<ServiceResponse<ProductOrderDto>> AddAsync(ProductOrderDto dtoReq)
        {
            var EntityForAdd = _mapper.Map<ProductOrder>(dtoReq);
            await _unitOfWork.Repository.AddAsync(EntityForAdd);
            if (await _unitOfWork.CommitAsync())
            {
                var mappedResponse = _mapper.Map<ProductOrderDto>(EntityForAdd);
                return ServiceResponse<ProductOrderDto>.Created(mappedResponse, $"Product Order Created Successfully with Id {EntityForAdd.Id}");
            }
            else
                return ServiceResponse<ProductOrderDto>.Fail();
        }

        #region Private Helper Method
        private ExpressionStarter<ProductOrder> BuildOrderSearchCriteria(ProductQueryCriteria criteria)
        {
            var predicate = PredicateBuilder.New<ProductOrder>(true);
            if (criteria == null)
                return predicate;
            if (!string.IsNullOrEmpty(criteria.ProductName))
            {
                predicate.Or(s => s.Product.ProductName.ToLower().Contains(criteria.ProductName.ToLower()));

            }


            return predicate;
        }

        #endregion



    }
}
