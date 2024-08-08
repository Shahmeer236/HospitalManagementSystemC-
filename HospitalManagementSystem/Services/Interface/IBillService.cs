public interface IBillService
{
    Task<BillDto> GetBillByIdAsync(Guid id);
    Task<List<BillForListing>> GetBillsAsync();
    Task<Guid> CreateBillAsync(BillForCreation billForCreation);
    Task<bool> UpdateBillAsync(BillForUpdation billForUpdation);
    Task<bool> DeleteBillAsync(Guid id);
}
