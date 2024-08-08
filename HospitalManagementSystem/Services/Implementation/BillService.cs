using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BillService : IBillService
{
    private readonly IBillRepository _billRepository;
    private readonly HospitalManagementSystemDbContext _context;
    private readonly IMapper _mapper; // Inject IMapper

    public BillService(IBillRepository billRepository, HospitalManagementSystemDbContext context, IMapper mapper)
    {
        _billRepository = billRepository;
        _context = context;
        _mapper = mapper; // Initialize IMapper
    }

    public async Task<BillDto> GetBillByIdAsync(Guid id)
    {
        var bill = await _billRepository.GetBillByIdAsync(id);
        return _mapper.Map<BillDto>(bill); // Use _mapper for mapping
    }

    public async Task<List<BillForListing>> GetBillsAsync()
    {
        var bills = await _billRepository.GetBillsAsync();
        return _mapper.Map<List<BillForListing>>(bills); // Use _mapper for mapping
    }

    public async Task<Guid> CreateBillAsync(BillForCreation billForCreation)
    {
        if (billForCreation.AdmissionId == null)
        {
            throw new ArgumentException("AdmissionId is required.");
        }

        var admission = await _context.Admissions.FindAsync(billForCreation.AdmissionId.Value);
        if (admission == null)
        {
            throw new ArgumentException("Invalid Admission ID");
        }

        var labTestReport = await _context.LabTestReports
            .FirstOrDefaultAsync(x => x.PatientId == admission.PatientId && x.Id == billForCreation.LabTestReportId);

        var room = await _context.Rooms.FindAsync(admission.RoomId);

        var days = (DateTime.Today - admission.AdmissionDate).Days;
        var roomCharges = room?.Charges ?? 0;
        var labTestCharges = labTestReport?.Charges ?? 0;
        var doctorCharges = 2000; // Fixed doctor charges

        var totalAmount = (roomCharges * days) + labTestCharges + doctorCharges;

        var bill = new Bill
        {
            AdmissionId = billForCreation.AdmissionId,
            LabTestReportId = billForCreation.LabTestReportId,
            TotalAmount = totalAmount,
            DateOfIssue = DateTime.Today
        };

        return await _billRepository.AddBillAsync(bill);
    }

    public async Task<bool> UpdateBillAsync(BillForUpdation billForUpdation)
    {
        var bill = await _billRepository.GetBillByIdAsync(billForUpdation.Id);
        if (bill == null)
        {
            return false;
        }

        bill.TotalAmount = billForUpdation.TotalAmount;
        return await _billRepository.UpdateBillAsync(bill);
    }

    public async Task<bool> DeleteBillAsync(Guid id)
    {
        return await _billRepository.DeleteBillAsync(id);
    }
}
