using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using MemoryCache;

namespace GoogleDriveApi.Controllers
{
    [RequireHttps]
    [Authorize]
    public class HomeController : AsyncController
    {
        public async Task<ActionResult> IndexAsync(CancellationToken cancellationToken)
        {
            var result = await new AuthorizationCodeMvcApp(this, new AppAuthFlowMetadata()).
                AuthorizeAsync(cancellationToken);

            if (result.Credential == null) return new RedirectResult(result.RedirectUri);

            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = result.Credential,
                ApplicationName = "ASP.NET MVC Sample"
            });
            var list = service.Files.List().Execute();
                
            Cache.Store("files", list);

            return View(list);
        }
    }
}
