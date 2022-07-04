using AutoMapper;
using MohamedRefaat.Application.DTOs.Applicant;
using MohamedRefaat.Application.DTOs.Order;
using MohamedRefaat.Domain.Models.Order;
using MohamedRefaat.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohamedRefaat.Application.AutoMapper
{
    public class DTOsToDomainProfile : Profile
    {
        public DTOsToDomainProfile()
        {
            CreateMap<ProductDto, Product>();

            CreateMap<ProductOrderDto, ProductOrder>();
        }

    }
}
