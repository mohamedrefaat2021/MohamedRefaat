

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

namespace UnitTest
{
    public class ProductControllerTest
    {
        private readonly ProductController _controller;
        private readonly IProductService _service;

        public ProductControllerTest()
        {
            _service = new ProductService();
            _controller = new ProductController((MohamedRefaat.Application.Interfaces.IProductService)_service);
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
            var nameMissingItem = new ProductDto()
            {
                ProductName = "Apple",
                SupplierName = "Ahmed",
                Quantity = "200",
                Description = "Desc",
                Notes = "Fresh"
            };
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = _controller.Post(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }



        [Fact]
        public void Remove()
        {
            // Arrange
            var existingId = 1;

            // Act
            var okResponse = _controller.Delete(existingId);

            // Assert
            Assert.Equal(2, _service.GetAllItems().Count());
        }
    }
}
