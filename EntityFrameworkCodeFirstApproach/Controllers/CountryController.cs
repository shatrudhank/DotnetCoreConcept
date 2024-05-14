using EntityFrameworkCodeFirstApproach.EntityDbContext;
using EntityFrameworkCodeFirstApproach.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCodeFirstApproach.Controllers
{
   
    [ApiController]
    public class CountryController : ControllerBase
    {
        private MasterDbContext _dbContext;
        public CountryController(MasterDbContext masterDbContext)
        {
            _dbContext= masterDbContext;
        }

        [Route("api/country/getCountryList")]
        public IActionResult GetCountyList()
        {
            List<Country> countryList = _dbContext.Country.ToList();
            return Ok(countryList);
        }
    }
}
