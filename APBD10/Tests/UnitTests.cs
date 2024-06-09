using APBD10.Controllers;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;


namespace APBD10.Tests;

[TestClass]
[TestSubject(typeof(ApiController))]
public class UnitTests
{
    private DbContextOptions<DbContext> _dbContextOptions;
    
    [TestInitialize]
    public void TestInitialize()
    {
        _dbContextOptions = new DbContextOptionsBuilder<DbContext>()
            //.UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    }
    
    [TestMethod]
    public async Task AddPrescription_WhenCalled_AddsPrescriptionCorrectly()
    {
        
    }
}