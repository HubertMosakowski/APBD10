using APBD10.Models;
using APBD10.Services;
using Microsoft.EntityFrameworkCore;
using DbContext = APBD10.DbContext;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IPatientService, PatientService>();
        builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
        
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.Run();
    }
}