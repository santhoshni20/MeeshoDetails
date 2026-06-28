using Microsoft.AspNetCore.Http;
using System;

namespace MeeshoDetails.DTOs
{
    public class saveProductDTO
    {
        public IFormFile? productPhoto { get; set; }
        public string skuId { get; set; } = string.Empty;
        public int stock { get; set; } = 1;
        public DateTime? dateOfUpload { get; set; }
        public decimal investedAmount { get; set; }
    }
}
