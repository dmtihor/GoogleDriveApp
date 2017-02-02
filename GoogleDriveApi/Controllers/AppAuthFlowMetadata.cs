using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;
using Microsoft.AspNet.Identity;

namespace GoogleDriveApi.Controllers
{
    public class AppAuthFlowMetadata : FlowMetadata
    {
        private static readonly IAuthorizationCodeFlow flow =
            new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "402919559397-qscb28uej788e1m266pskokhe5up735v.apps.googleusercontent.com",
                    ClientSecret = "C8yL3ol6DZcK7plyeHyJX6RZ"
                },
                Scopes = new[] { DriveService.Scope.Drive},
                DataStore = new FileDataStore("Google.Apis.Sample.MVC")
            });

        public override string GetUserId(Controller controller)
        {
            return controller.User.Identity.GetUserName();
        }

        public override IAuthorizationCodeFlow Flow
        {
            get { return flow; }
        }
    }
}