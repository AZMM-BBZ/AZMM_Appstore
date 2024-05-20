using AZMM.Server.DtoModel;
using AZMM.Server.Services.Interfaces;
using Froghopper.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.IO;
using System.Net;
using System.Net.Http.Headers;

namespace AZMM.Server.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("[controller]")]
    public class AppController : ControllerBase
    {
        private readonly IAppService _appService;

        public AppController(IAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("downloadApp")]
        public HttpResponseMessage DownloadApp()
        {
            MemoryStream responseStream = new MemoryStream();
            //Stream fileStream = System.IO.File.Open("downloadFilePath", FileMode.Open);
            var fileStream = _appService.GetAppFile(1);

            fileStream.CopyTo(responseStream);
            fileStream.Close();
            responseStream.Position = 0;


            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;

            //Write the memory stream to HttpResponseMessage content
            response.Content = new StreamContent(responseStream);
            string contentDisposition = string.Concat("attachment; filename=", "fileName");
            response.Content.Headers.ContentDisposition =
                          ContentDispositionHeaderValue.Parse(contentDisposition);
            return response;
        }

        [HttpGet("getAppsOfUser")]
        public ActionResult<List<AppDto>> GetAppOfCurrentUser()
        {
            return Ok();
        }

        [HttpGet("getAppWithCategory")]
        public ActionResult<List<AppDto>> GetAppWithCategory([FromQuery] Category category)
        {
            return Ok();
        }

        [HttpPost("purchaseApp")]
        public ActionResult PurchaseApp([FromBody] AppDto appDto)
        {
            return Ok(true);
        }

        [Authorize(Roles = RoleConsts.ELEVATED_COMPANY_USERS)]
        [HttpPost("uploadApp")]
        public ActionResult UploadApp([FromBody] AppDto appDto)
        {
            return Ok(true);
        }

        [Authorize(Roles = RoleConsts.ELEVATED_COMPANY_USERS)]
        [HttpDelete("deleteApp")]
        public ActionResult DeleteApp([FromBody] AppDto appDto)
        {
            return Ok(true);
        }

        [Authorize(Roles = RoleConsts.ELEVATED_COMPANY_USERS)]
        [HttpDelete("updateApp")]
        public ActionResult UpdateDeleteApp([FromBody] AppDto appDto)
        {
            return Ok(true);
        }
    }
}
