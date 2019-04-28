using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czar.Cms.ViewModels
{
   public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CaptchaCode { get; set; }
        public string Ip { get; set; }
        public string ReturnUrl { get; set; }
    }
}
