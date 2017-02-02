using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.OData;
using System.Web.Mvc;
using FizzWare.NBuilder;
using Google.Apis.Drive.v3.Data;
using GoogleDriveApi.Models;
using MemoryCache;

namespace GoogleDriveApi.Controllers
{
    [RequireHttps]
    [Authorize]
    public class FilesController : ODataController
    {
        public IEnumerable<FileInf> Get()
        {
            var list = Cache.Get("files") as FileList;

            var source = new List<FileInf>();
            if (list != null)
            {
                source = list.Files.Select(file => new FileInf()
                {Id = file.Id, Name = file.Name}).ToList();
            }

            return source;
        }
    }
}