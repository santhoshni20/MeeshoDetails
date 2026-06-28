using Microsoft.AspNetCore.Http;

namespace MeeshoDetails.DTOs
{
    public class updateProductDTO
    {
        public int productId { get; set; }
        public string skuId { get; set; }
        public IFormFile productPhoto { get; set; }
        public int stock { get; set; }
        public string dateOfUpload { get; set; }
        public string courierName { get; set; }
        public string dateOfPickup { get; set; }
        public decimal investedAmount { get; set; }
        public decimal creditedAmount { get; set; }
        public string paymentStatus { get; set; }
        public string dateOfPayment { get; set; }
        public string arrived { get; set; }
    }
}
