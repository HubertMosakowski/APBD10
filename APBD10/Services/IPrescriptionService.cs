using APBD10.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace APBD10.Services;

public interface IPrescriptionService
{
    public Task<PrescDTO> AddPrescription([FromBody] PrescDTO prescDto);
}