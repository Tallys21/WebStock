using WebStock.Models;

namespace WebStock.Data
{
    public class SeedingService
    {
        private readonly WebStockContext _context;
        public SeedingService(WebStockContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (_context.EntryType.Any() || _context.ExitType.Any() || _context.AdjustmentReason.Any())
            {
                return;
            }

            EntryType et1 = new EntryType { Name = "Purchase" };
            EntryType et2 = new EntryType { Name = "Return" };
            EntryType et3 = new EntryType { Name = "Adjustment" };

            ExitType ext1 = new ExitType { Name = "Sale" };
            ExitType ext2 = new ExitType { Name = "Transfer" };
            ExitType ext3 = new ExitType { Name = "Adjustment" };

            AdjustmentReason ar1 = new AdjustmentReason { Reason = "Lost" };
            AdjustmentReason ar2 = new AdjustmentReason { Reason = "Damage" };
            AdjustmentReason ar3 = new AdjustmentReason { Reason = "Manual Adjustment" };
            AdjustmentReason ar4 = new AdjustmentReason { Reason = "Inventory Correction" };

            _context.EntryType.AddRangeAsync(et1, et2, et3);
            _context.ExitType.AddRangeAsync(ext1, ext2, ext3);
            _context.AdjustmentReason.AddRangeAsync(ar1, ar2, ar3, ar4);

            await _context.SaveChangesAsync();

        }
    }
}
