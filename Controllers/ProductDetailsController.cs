using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeeshoDetails.DTOs;
using MeeshoDetails.Interfaces;

namespace MeeshoDetails.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly IProductDetailsRepository _productRepository;

        public ProductDetailsController(IProductDetailsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Action to render the main ProductDetails.cshtml page
        public IActionResult productDetails()
        {
            return View("~/Views/Product Details/ProductDetails.cshtml");
        }

        // API Endpoint to get all products in JSON format
        [HttpGet]
        public async Task<IActionResult> getProductsList()
        {
            try
            {
                var data = await _productRepository.getProducts();
                var response = new apiResponseDTO
                {
                    statusCode = 200,
                    message = "Products retrieved successfully",
                    data = data
                };
                return Json(response);
            }
            catch (Exception ex)
            {
                var response = new apiResponseDTO
                {
                    statusCode = 500,
                    message = "Failed to retrieve products",
                    errorDetails = ex.Message
                };
                return Json(response);
            }
        }

        // API Endpoint to save a new product
        [HttpPost]
        public async Task<IActionResult> saveNewProduct([FromForm] saveProductDTO dto)
        {
            try
            {
                if (string.IsNullOrEmpty(dto.skuId))
                {
                    return Json(new apiResponseDTO
                    {
                        statusCode = 400,
                        message = "SKU ID is required"
                    });
                }

                var data = await _productRepository.addProduct(dto);
                var response = new apiResponseDTO
                {
                    statusCode = 200,
                    message = "Product saved successfully",
                    data = data
                };
                return Json(response);
            }
            catch (Exception ex)
            {
                var response = new apiResponseDTO
                {
                    statusCode = 500,
                    message = "Failed to save product",
                    errorDetails = ex.Message
                };
                return Json(response);
            }
        }

        // API Endpoint to update an existing product
        [HttpPost]
        public async Task<IActionResult> updateProductDetails([FromBody] productDTO dto)
        {
            try
            {
                var success = await _productRepository.updateProduct(dto);
                if (success)
                {
                    return Json(new apiResponseDTO
                    {
                        statusCode = 200,
                        message = "Product updated successfully"
                    });
                }
                else
                {
                    return Json(new apiResponseDTO
                    {
                        statusCode = 404,
                        message = "Product not found"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new apiResponseDTO
                {
                    statusCode = 500,
                    message = "Failed to update product",
                    errorDetails = ex.Message
                });
            }
        }

        // API Endpoint to delete a product
        [HttpPost]
        public async Task<IActionResult> deleteProductItem(int productId)
        {
            try
            {
                var success = await _productRepository.deleteProduct(productId);
                if (success)
                {
                    return Json(new apiResponseDTO
                    {
                        statusCode = 200,
                        message = "Product deleted successfully"
                    });
                }
                else
                {
                    return Json(new apiResponseDTO
                    {
                        statusCode = 404,
                        message = "Product not found"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new apiResponseDTO
                {
                    statusCode = 500,
                    message = "Failed to delete product",
                    errorDetails = ex.Message
                });
            }
        }
    }
}
