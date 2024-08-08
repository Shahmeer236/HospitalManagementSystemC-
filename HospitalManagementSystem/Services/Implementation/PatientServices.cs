using AutoMapper;
using HospitalManagementSystem.Dtos.Patient;
using HospitalManagementSystem.Repositories.Interfaces;
using HospitalManagementSystem.Services.Interface;

namespace HospitalManagementSystem.Services.Implementation
{
    public class PatientServices : IPatientServices
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientServices(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<List<PatientDto>> GetPatientAsync(string? search)
        {
            var patients = await _patientRepository.GetPatientAsync(search);
            return _mapper.Map<List<PatientDto>>(patients);
        }

        public async Task<Guid> AddPatientAsync(PatientForCreation patientForCreation)
        {
            return await _patientRepository.AddPatientAsync(patientForCreation);
        }

        public async Task<PatientDto> GetPatientByIdAsync(Guid id)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(id);
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<bool> UpdatePatientAsync(PatientForUpdation patientForUpdation)
        {
            return await _patientRepository.UpdatePatientAsync(patientForUpdation);
        }

        public async Task<bool> DeletePatientById(Guid id)
        {
            return await _patientRepository.DeletePatientAsync(id);
        }

        public async Task<PatientDto> GetPatientByEmailAsync(string email)
        {
            return await _patientRepository.GetPatientByEmailAsync(email);
        }

        public async Task<PatientDto> GetPatientByNameAsync(string firstName)
        {
            var patient = await _patientRepository.GetPatientByNameAsync(firstName);
            return _mapper.Map<PatientDto>(patient);
        }
    }
}
