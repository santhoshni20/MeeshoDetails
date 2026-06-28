using Microsoft.EntityFrameworkCore;
using MeeshoDetails.Entities;

namespace CampaignManagement.Helpers.DbContexts
{
    public class CampaignDbContext : DbContext
    {
        public CampaignDbContext(DbContextOptions<CampaignDbContext> options) : base(options)
        {
        }

        public DbSet<Product> products { get; set; }
    }
}
