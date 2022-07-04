using AutoMapper;
using MohamedRefaat.Application.DTOs.Applicant;
using MohamedRefaat.Domain.Models.Product;
using MohamedRefaat.Domain.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MohamedRefaat.Domain.Models.Order;
using MohamedRefaat.Application.DTOs.Order;

namespace MohamedRefaat.Application.AutoMapper
{
    public class DomainToDTOsProfile : Profile
    {
        public DomainToDTOsProfile()
        {


            CreateMap<Product, ProductDto>();

            CreateMap<ProductOrder, ProductOrderDto>()
         .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));

            CreateMap(typeof(PagedListResponse<>), typeof(PagedListResponse<>));
        }

    }
}
