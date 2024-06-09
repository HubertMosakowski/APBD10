using APBD10.Models;

namespace APBD10.Services;

public interface IPatientService
{
    public Task<Patient> GetPatient(int id);
    public void setConfig(IConfiguration configuration);
}