using AutoMapper;
using HospitalManagementSystem.Dtos.Doctor;
using HospitalManagementSystem.Repositories.Interfaces;
using HospitalManagementSystem.Services.Interface;
using System;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Implementation
{
    public class DoctorServices : IDoctorServices
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorServices(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddDoctorAsync(DoctorForCreation doctorForCreation)
        {
            var doctor = _mapper.Map<Doctor>(doctorForCreation);
            return await _doctorRepository.AddDoctorAsync(doctor);
        }

        public async Task<DoctorDto> GetDoctorByIdAsync(Guid id)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task UpdateDoctorAsync(DoctorForUpdation doctorForUpdation)
        {
            var doctor = _mapper.Map<Doctor>(doctorForUpdation);
            await _doctorRepository.UpdateDoctorAsync(doctor);
        }

        public async Task<bool> DeleteDoctorAsync(Guid id)
        {
            return await _doctorRepository.DeleteDoctorAsync(id);
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsAsync(string? search)
        {
            var doctors = await _doctorRepository.GetDoctorsAsync(search);
            return _mapper.Map<IEnumerable<DoctorDto>>(doctors);
        }
    }
}
