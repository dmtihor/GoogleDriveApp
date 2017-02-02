using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using GoogleDriveApi.Models;

namespace GoogleDriveApi
{
    public class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes(); 

            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<FileInf>("Files");
            config.MapODataServiceRoute("ODataRoute", "api", builder.GetEdmModel());
        }
    }
}