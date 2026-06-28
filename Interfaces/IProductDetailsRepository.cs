using System.Collections.Generic;
using System.Threading.Tasks;
using MeeshoDetails.DTOs;

namespace MeeshoDetails.Interfaces
{
    public interface IProductDetailsRepository
    {
        Task<List<productDTO>> getProducts();
        Task<productDTO> addProduct(saveProductDTO dto);
        Task<bool> updateProduct(productDTO dto);
        Task<bool> editProduct(updateProductDTO dto);
        Task<bool> deleteProduct(int productId);
        Task<dashboardStatsDTO> getDashboardStats();
    }
}
