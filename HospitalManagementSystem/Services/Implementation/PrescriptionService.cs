using AutoMapper;
using HospitalManagementSystem.Dtos;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PrescriptionService : IPrescriptionService
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IMapper _mapper;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository, IMapper mapper)
    {
        _prescriptionRepository = prescriptionRepository;
        _mapper = mapper;
    }

    public async Task<List<PrescriptionDto>> GetAllPrescriptionsAsync()
    {
        var prescriptions = await _prescriptionRepository.GetAllPrescriptionsAsync();
        return _mapper.Map<List<PrescriptionDto>>(prescriptions);
    }

    public async Task<PrescriptionDto> GetPrescriptionByIdAsync(Guid id)
    {
        var prescription = await _prescriptionRepository.GetPrescriptionByIdAsync(id);
        return _mapper.Map<PrescriptionDto>(prescription);
    }

    public async Task<Guid> CreatePrescriptionAsync(PrescriptionForCreation prescriptionForCreation)
    {
        var prescription = _mapper.Map<Prescription>(prescriptionForCreation);
        return await _prescriptionRepository.AddPrescriptionAsync(prescription);
    }

    public async Task<bool> UpdatePrescriptionAsync(PrescriptionForUpdation prescriptionForUpdation)
    {
        var prescription = _mapper.Map<Prescription>(prescriptionForUpdation);
        return await _prescriptionRepository.UpdatePrescriptionAsync(prescription);
    }

    public async Task<bool> DeletePrescriptionAsync(Guid id)
    {
        return await _prescriptionRepository.DeletePrescriptionAsync(id);
    }
}
