using AZMM.Server.DtoModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AZMM.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        [Authorize(Roles = RoleConsts.ALL_COMPANY_ROLES)]
        [HttpGet("getCompanys")]
        public ActionResult<List<CompanyDto>> GetCompanys([FromQuery] int userId)
        {
            return Ok();
        }

        [Authorize(Roles = RoleConsts.ADMIN)]
        [HttpPost("registerCompany")]
        public ActionResult RegisterCompany([FromBody] CompanyDto companyDto)
        {
            return Ok();
        }

        [Authorize(Roles = RoleConsts.ADMIN)]
        [HttpPost("addAuthorToComany")]
        public ActionResult AddUserToCompany([FromBody] CompanyDto companyDto)
        {
            return Ok();
        }

        [Authorize(Roles = RoleConsts.ADMIN)]
        [HttpPost("updateCompany")]
        public ActionResult UpdateCompany([FromBody] CompanyDto companyDto)
        {
            return Ok();
        }

        [Authorize(Roles = RoleConsts.ADMIN)]
        [HttpDelete("deleteComany")]
        public ActionResult DeleteCompany([FromBody] CompanyDto companyDto)
        {
            return Ok();
        }
    }
}
