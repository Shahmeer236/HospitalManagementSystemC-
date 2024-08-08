public interface IBillRepository
{
    Task<Bill> GetBillByIdAsync(Guid id);
    Task<List<Bill>> GetBillsAsync();
    Task<Guid> AddBillAsync(Bill bill);
    Task<bool> UpdateBillAsync(Bill bill);
    Task<bool> DeleteBillAsync(Guid id);
}
