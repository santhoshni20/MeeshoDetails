using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CampaignManagement.Helpers.DbContexts;
using MeeshoDetails.Entities;
using MeeshoDetails.DTOs;
using MeeshoDetails.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace MeeshoDetails.Repositories
{
    public class ProductDetailsRepository : IProductDetailsRepository
    {
        private readonly CampaignDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductDetailsRepository(CampaignDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<List<productDTO>> getProducts()
        {
            var products = await _context.products
                .OrderBy(p => p.productId)
                .Select(p => new productDTO
                {
                    productId = p.productId,
                    skuId = p.skuId,
                    productPhoto = p.productPhoto,
                    stock = p.stock,
                    dateOfUpload = p.dateOfUpload.HasValue ? p.dateOfUpload.Value.ToString("yyyy-MM-dd") : null,
                    courierName = p.courierName,
                    dateOfPickup = p.dateOfPickup.HasValue ? p.dateOfPickup.Value.ToString("yyyy-MM-dd") : null,
                    investedAmount = p.investedAmount,
                    creditedAmount = p.creditedAmount,
                    profitAmount = p.profitAmount,
                    paymentStatus = p.paymentStatus,
                    dateOfPayment = p.dateOfPayment.HasValue ? p.dateOfPayment.Value.ToString("yyyy-MM-dd") : null,
                    arrived = p.arrived
                })
                .ToListAsync();

            return products;
        }

        public async Task<productDTO> addProduct(saveProductDTO dto)
        {
            string? photoPath = null;
            if (dto.productPhoto != null && dto.productPhoto.Length > 0)
            {
                string uploadFolder = Path.Combine(_env.WebRootPath, "Uploads");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + dto.productPhoto.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.productPhoto.CopyToAsync(fileStream);
                }
                photoPath = "/Uploads/" + uniqueFileName;
            }

            var product = new Product
            {
                skuId = dto.skuId,
                productPhoto = photoPath,
                stock = dto.stock,
                dateOfUpload = dto.dateOfUpload,
                investedAmount = dto.investedAmount,
                profitAmount = -dto.investedAmount
            };

            _context.products.Add(product);
            await _context.SaveChangesAsync();

            return new productDTO
            {
                productId = product.productId,
                skuId = product.skuId,
                productPhoto = product.productPhoto,
                stock = product.stock,
                dateOfUpload = product.dateOfUpload.HasValue ? product.dateOfUpload.Value.ToString("yyyy-MM-dd") : null,
                courierName = product.courierName,
                dateOfPickup = product.dateOfPickup.HasValue ? product.dateOfPickup.Value.ToString("yyyy-MM-dd") : null,
                investedAmount = product.investedAmount,
                creditedAmount = product.creditedAmount,
                profitAmount = product.profitAmount,
                paymentStatus = product.paymentStatus,
                dateOfPayment = product.dateOfPayment.HasValue ? product.dateOfPayment.Value.ToString("yyyy-MM-dd") : null,
                arrived = product.arrived
            };
        }

        public async Task<bool> updateProduct(productDTO dto)
        {
            var product = await _context.products.FirstOrDefaultAsync(p => p.productId == dto.productId);
            if (product == null) return false;

            product.skuId = dto.skuId;
            product.stock = dto.stock;
            product.dateOfUpload = string.IsNullOrEmpty(dto.dateOfUpload) ? null : DateTime.Parse(dto.dateOfUpload);
            product.courierName = dto.courierName;
            product.dateOfPickup = string.IsNullOrEmpty(dto.dateOfPickup) ? null : DateTime.Parse(dto.dateOfPickup);
            product.investedAmount = dto.investedAmount;
            product.creditedAmount = dto.creditedAmount;
            product.profitAmount = dto.creditedAmount - dto.investedAmount;
            product.paymentStatus = dto.paymentStatus;
            product.dateOfPayment = string.IsNullOrEmpty(dto.dateOfPayment) ? null : DateTime.Parse(dto.dateOfPayment);
            product.arrived = dto.arrived;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteProduct(int productId)
        {
            var product = await _context.products.FirstOrDefaultAsync(p => p.productId == productId);
            if (product == null) return false;

            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
