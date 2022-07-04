

using MohamedRefaat.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using MohamedRefaat.Domain.Models.Product;
using MohamedRefaat.Application.DTOs.Applicant;
using MohamedRefaat.Application.DTOs.Order;

namespace UnitTest
{
    public class OrderControllerTest
    {
        private readonly OrderController _controller;
        private readonly IOrderService _service;

        public OrderControllerTest()
        {
            _service = new OrderService();
            _controller = new OrderController((MohamedRefaat.Application.Interfaces.IOrderService)_service);
        }

        [Fact]
        public async Task<IActionResult> Get()
        {
            // Act
            var okResult = await _controller.Get();

            // Assert
            return Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void add()
        {
            // Arrange
            var nameMissingItem = new ProductOrderDto()
            {
                OrderId = 1,
                ProductId = 1,
                Price = 200,
                Quantity = 100,
                
            };
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = _controller.Post(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

    }
}
