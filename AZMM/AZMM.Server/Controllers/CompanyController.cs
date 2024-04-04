using AZMM.Server.DtoModel;
using Microsoft.AspNetCore.Mvc;

namespace AZMM.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        [HttpGet("getCompanys")]
        public ActionResult<List<CompanyDto>> GetCompanys([FromQuery] int userId)
        {
            return Ok();
        }

        [HttpPost("registerCompany")]
        public ActionResult RegisterCompany([FromBody] CompanyDto companyDto)
        {
            return Ok();
        }

        [HttpPost("addAuthorToComany")]
        public ActionResult AddUserToCompany([FromBody] CompanyDto companyDto)
        {
            return Ok();
        }

        [HttpPost("updateCompany")]
        public ActionResult UpdateCompany([FromBody] CompanyDto companyDto)
        {
            return Ok();
        }

        [HttpDelete("addAuthorToComany")]
        public ActionResult DeleteCompany([FromBody] CompanyDto companyDto)
        {
            return Ok();
        }
    }
}
