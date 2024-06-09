using APBD10.DTOs;
using APBD10.Models;
using APBD10.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiController : ControllerBase
{

    private readonly IPatientService _patientService;
    private readonly IPrescriptionService _prescriptionService;

    public ApiController(IPatientService patientService, IPrescriptionService prescriptionService)
    {
        _patientService = patientService;
        _prescriptionService = prescriptionService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        var patient = _patientService.GetPatient(id);
        
        if (patient == null)
        {
            return NotFound("Nie znaleziono pacjenta!");
        }

        return Ok(patient);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] PrescDTO prescDto)
    {

        var result = _prescriptionService.AddPrescription(prescDto);
        return Ok(result);
    }
}