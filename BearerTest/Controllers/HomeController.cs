using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BearerTest.Controllers
{
    public class HomeController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("GetTokenCheck")]
        public HttpResponseMessage GetTokenCheck()
        {
            TokenCheckModel token = new TokenCheckModel();
            token.isSuccess = true;
            token.message = "İşlem başarılı";
            return Request.CreateResponse(HttpStatusCode.OK, token, Configuration.Formatters.JsonFormatter);
        }
    }
    public class TokenCheckModel
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
    }
}
