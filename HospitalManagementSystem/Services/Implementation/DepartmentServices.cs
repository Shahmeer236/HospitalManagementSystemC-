using AutoMapper;
using HospitalManagementSystem.Dtos.Department;

using HospitalManagementSystem.Repositories.Interfaces;
using HospitalManagementSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Implementation
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentServices(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<DepartmentForListing>> GetDepartmentAsync(string? search)
        {
            var departments = await _departmentRepository.GetDepartmentsAsync(search);
            return _mapper.Map<List<DepartmentForListing>>(departments);
        }

        public async Task<Guid> AddDepartmentAsync(DepartmentForCreation departmentForCreation)
        {
            var department = _mapper.Map<Department>(departmentForCreation);
            return await _departmentRepository.AddDepartmentAsync(department);
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(Guid id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<DepartmentDto> UpdateDepartmentAsync(DepartmentForUpdation departmentForUpdation)
        {
            var department = _mapper.Map<Department>(departmentForUpdation);
            await _departmentRepository.UpdateDepartmentAsync(department);
            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<bool> DeleteDepartmentAsync(Guid id)
        {
            return await _departmentRepository.DeleteDepartmentAsync(id);
        }
    }
}
