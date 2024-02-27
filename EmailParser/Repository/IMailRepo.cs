using EmailParser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailParser.Repository
{
    public interface IMailRepo
    {
        JsonResult validateEmail(byte[] byteArr = null);
        Boolean checkSuccessRate();
        JsonResult parseEmail();
        Email breakEmail(byte[] byteArr);
    }
}
