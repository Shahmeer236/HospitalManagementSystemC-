using Microsoft.EntityFrameworkCore;

public class BillRepository : IBillRepository
{
    private readonly HospitalManagementSystemDbContext _context;

    public BillRepository(HospitalManagementSystemDbContext context)
    {
        _context = context;
    }

    public async Task<Bill> GetBillByIdAsync(Guid id)
    {
        return await _context.Bills.FindAsync(id);
    }

    public async Task<List<Bill>> GetBillsAsync()
    {
        return await _context.Bills.ToListAsync();
    }

    public async Task<Guid> AddBillAsync(Bill bill)
    {
        _context.Bills.Add(bill);
        await _context.SaveChangesAsync();
        return bill.Id;
    }

    public async Task<bool> UpdateBillAsync(Bill bill)
    {
        _context.Bills.Update(bill);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteBillAsync(Guid id)
    {
        var bill = await _context.Bills.FindAsync(id);
        if (bill == null)
        {
            return false;
        }

        _context.Bills.Remove(bill);
        return await _context.SaveChangesAsync() > 0;
    }
}
