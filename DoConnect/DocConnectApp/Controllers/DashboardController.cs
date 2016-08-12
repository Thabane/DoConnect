using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;

namespace DocConnectApp.Controllers
{
    /// <summary>
    /// Class BuildStateController. This controller excutes the API calls from our Server Side Programming. 
    /// </summary>
    public class DashboardController : ApiController
    {
        /// <summary>
        /// Gets the current builds.
        /// </summary>        
        /// <returns>List of BuildInfo.</returns>
        [HttpGet]
        public HttpResponseMessage GetBuildState()
        {
            return null;
        }

        /// <summary>
        /// Gets the build state by ID.
        /// </summary>        
        /// <param name="buildDef">The build definition identifier.</param>
        /// <returns>BuildInfo.</returns>
        [HttpGet]
        [Route("api/BuildState/GetBuildStateById/{buildDef}")]
        public HttpResponseMessage GetBuildStateById(int buildDef)
        {
            return null;
        }
    }
}