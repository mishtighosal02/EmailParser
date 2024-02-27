using EmailParser.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailHandler : ControllerBase
    {
        IMailRepo repoObj;
        public EmailHandler(IMailRepo _repoObj)
        {
            repoObj = _repoObj;
        }

        [HttpGet]
        public void GetMail()
        {
            repoObj.validateEmail();
        }

        [HttpPost]
        public void SendMail()
        {

        }
    }
}
