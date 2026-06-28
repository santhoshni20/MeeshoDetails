using Microsoft.EntityFrameworkCore;

namespace CampaignManagement.Helpers.DbContexts
{
    public class CampaignDbContext : DbContext
    {
        public CampaignDbContext(DbContextOptions<CampaignDbContext> options) : base(options)
        {
        }
    }
}
