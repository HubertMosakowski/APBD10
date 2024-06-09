﻿using APBD10.DTOs;
using APBD10.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD10.Services;

public class PrescriptionService: IPrescriptionService
{
    public async Task<PrescDTO> AddPrescription([FromBody] PrescDTO prescDto)
    {
        var dbContext = new DbContext();

        var patient = await dbContext.Patients.FindAsync(prescDto.patient.IdPatient);
        if (patient == null)
        {
            patient = new Patient()
            {
                IdPatient = prescDto.patient.IdPatient,
                Birthdate = prescDto.patient.Birthdate,
                FirstName = prescDto.patient.FirstName,
                LastName = prescDto.patient.LastName,
                Prescriptions = prescDto.patient.Prescriptions
            };
            await dbContext.Patients.AddAsync(patient);
        }
        
        if (prescDto.DueDate < prescDto.Date)
        {
            throw new Exception("Daty są źle wprowadzone");
        }

        if (dbContext.Medicaments.Count() > 10)
        {
            throw new Exception("Za dużo leków");
        }
        
        if (await dbContext.Medicaments.FindAsync(prescDto.meds.Any()) == null)
        {
            throw new Exception("Lek nie istnieje");
        }
        
        var prescription = new Prescription()
        {
            IdPrescription = prescDto.IdPrescription,
            Date = prescDto.Date,
            DueDate = prescDto.DueDate,
            IdDoctor = prescDto.doctor.IdDoctor,
            IdPatient = prescDto.patient.IdPatient
        };
        await dbContext.AddAsync(prescription);
        await dbContext.SaveChangesAsync();

        foreach (var med in prescDto.meds)
        {
            var prescriptionMedicament = new PrescriptionMedicament()
            {
                IdMedicament = med.IdMedicament,
                IdPrescription = prescDto.IdPrescription
            };
            await dbContext.PrescriptionMedicaments.AddAsync(prescriptionMedicament);
        }
        await dbContext.SaveChangesAsync();
        return prescDto;
    }
}