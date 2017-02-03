using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData;
using Google.Apis.Drive.v3.Data;
using GoogleDriveApi.Models;
using MemoryCache;

namespace GoogleDriveApi.Controllers
{
    public class FriendsController : ODataController
    {
        public IEnumerable<FbUser> Get()
        {
            return Cache.Get("friends") as List<FbUser>;
        }
    }
}