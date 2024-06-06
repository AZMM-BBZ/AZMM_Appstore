using AZMM.Server.DtoModel;
using AZMM.Server.Services.Interfaces;
using Froghopper.Context;
using Froghopper.Enums;
using Froghopper.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.IO;
using System.IO.Compression;
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
        public async Task<IActionResult> DownloadAppAsync([FromQuery] int aid)
        {
            string exeFilePath = _appService.GetAppFile(aid);
            string tempZipFilePath = @"C:\temp\Executable.zip";


            // Ensure the exe file exists
            if (!System.IO.File.Exists(exeFilePath))
            {
                //return NotFound("The specified executable file was not found.");
            }

            // Create a temporary directory to store the exe file for zipping
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            string tempZipDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);

            try
            {
                // Copy the exe file to the temporary directory
                string tempExeFilePath = Path.Combine(tempDirectory, Path.GetFileName(exeFilePath));
                System.IO.File.Copy(exeFilePath, tempExeFilePath);

                // Path to the zip file in the temporary directory

                // Create the zip file containing the exe file
                ZipFile.CreateFromDirectory(tempDirectory, tempZipFilePath);

                // Read the zip file into a memory stream
                var memoryStream = new MemoryStream();
                using (var fileStream = new FileStream(tempZipFilePath, FileMode.Open))
                {
                    await fileStream.CopyToAsync(memoryStream);
                }

                // Set the memory stream position to the beginning
                memoryStream.Position = 0;

                // Return the zip file as a FileStreamResult
                return File(memoryStream, "application/zip", "Executable.zip");
            }
            finally
            {
                // Clean up the temporary directory
                Directory.Delete(tempDirectory, true);
                System.IO.File.Delete(tempZipFilePath);
            }
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
