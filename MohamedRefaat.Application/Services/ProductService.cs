using AutoMapper;
using LinqKit;
using MohamedRefaat.Application.DTOs.Applicant;
using MohamedRefaat.Application.Interfaces;
using MohamedRefaat.Application.ServiceQueryParams;
using MohamedRefaat.Domain.Helper;
using MohamedRefaat.Domain.IRepository;
using MohamedRefaat.Domain.Models.Product;
using MohamedRefaat.Domain.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohamedRefaat.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork<Product> _unitOfWork;       
        private readonly IMapper _mapper;
        
        public ProductService(IUnitOfWork<Product> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;           
            _mapper = mapper;
        }

        public async Task<ServiceResponse<PagedListResponse<ProductDto>>> GetAllPagedListAsync(GetAllPaggedQuery request, ProductQueryCriteria filters)
        {
            var data = await _unitOfWork.Repository.GetAllPagedListAsync(BuildProductSearchCriteria(filters), request.PageNumber, request.PageSize);
            var mappedData = _mapper.Map<PagedListResponse<ProductDto>>(data);
            return ServiceResponse<PagedListResponse<ProductDto>>.Success(mappedData);
        }

      
        public async Task<ServiceResponse<ProductDto>> AddAsync(ProductDto dtoReq)
        {
            var EntityForAdd = _mapper.Map<Product>(dtoReq);
            await _unitOfWork.Repository.AddAsync(EntityForAdd);
            if (await _unitOfWork.CommitAsync())
            {
                var mappedResponse = _mapper.Map<ProductDto>(EntityForAdd);
                return ServiceResponse<ProductDto>.Created(mappedResponse, $"Product Created Successfully with Id {EntityForAdd.Id}");
            }
            else
                return ServiceResponse<ProductDto>.Fail();
        }
        

        public async Task<ServiceResponse<bool>> UpdateAsync(ProductDto dtoReq)
        {
            if (dtoReq.Id <= 0)
                return ServiceResponse<bool>.Fail("Invalid Product  Id");

            var entity = await _unitOfWork.Repository.GetAsync(dtoReq.Id);

            if (entity == null)
                return ServiceResponse<bool>.NotFound("No Product matchs the requested id");

            var model = _mapper.Map(dtoReq, entity);
            _unitOfWork.Repository.Update(model);

            if (await _unitOfWork.CommitAsync())
                return ServiceResponse<bool>.Updated("Product Updated Successfully ");
            else
                return ServiceResponse<bool>.Fail();
        }

        public async Task<ServiceResponse<ProductDto>> GetByIdAsync(int id)
        {
            if (id <= 0)
                return ServiceResponse<ProductDto>.Fail("Invalid Product Id");

            var data = await _unitOfWork.Repository.GetFirstOrDefaultAsync(s => s.Id == id);
            if (data == null)
                return ServiceResponse<ProductDto>.NoResults();

            var MappedData = _mapper.Map<ProductDto>(data);
            return ServiceResponse<ProductDto>.Success(MappedData);
        }
        public bool Delete(int Id)
        {
            _unitOfWork.Repository.RemoveAsync(Id);
            return _unitOfWork.Commit();

        }



        #region Private Helper Method
        private ExpressionStarter<Product> BuildProductSearchCriteria(ProductQueryCriteria criteria)
        {
            var predicate = PredicateBuilder.New<Product>(true);
            if (criteria == null)
                return predicate;
            if (!string.IsNullOrEmpty(criteria.ProductName))
            {
                predicate.Or(s => s.ProductName.ToLower().Contains(criteria.ProductName.ToLower()));
                
            }

       
            return predicate;
        }

        #endregion


    }
}
