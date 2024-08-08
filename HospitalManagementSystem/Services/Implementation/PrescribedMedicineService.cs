using AutoMapper;
using HospitalManagementSystem.Dtos;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PrescribedMedicineService : IPrescribedMedicineService
{
    private readonly IPrescribedMedicineRepository _prescribedMedicineRepository;
    private readonly IMapper _mapper;

    public PrescribedMedicineService(IPrescribedMedicineRepository prescribedMedicineRepository, IMapper mapper)
    {
        _prescribedMedicineRepository = prescribedMedicineRepository;
        _mapper = mapper;
    }

    public async Task<List<PrescribedMedicineDto>> GetAllMedicinesAsync()
    {
        var prescribedMedicines = await _prescribedMedicineRepository.GetAllMedicinesAsync();
        return _mapper.Map<List<PrescribedMedicineDto>>(prescribedMedicines);
    }

    public async Task<PrescribedMedicineDto> GetMedicineByIdAsync(Guid id)
    {
        var prescribedMedicine = await _prescribedMedicineRepository.GetMedicineByIdAsync(id);
        return _mapper.Map<PrescribedMedicineDto>(prescribedMedicine);
    }

    public async Task<Guid> CreateMedicineAsync(PrescribedMedicineForCreation prescribedMedicineForCreation)
    {
        var prescribedMedicine = _mapper.Map<PrescribedMedicine>(prescribedMedicineForCreation);
        return await _prescribedMedicineRepository.AddMedicineAsync(prescribedMedicine);
    }

    public async Task<bool> UpdateMedicineAsync(PrescribedMedicineForUpdation prescribedMedicineForUpdation)
    {
        var prescribedMedicine = _mapper.Map<PrescribedMedicine>(prescribedMedicineForUpdation);
        return await _prescribedMedicineRepository.UpdateMedicineAsync(prescribedMedicine);
    }

    public async Task<bool> DeleteMedicineAsync(Guid id)
    {
        return await _prescribedMedicineRepository.DeleteMedicineAsync(id);
    }
}
