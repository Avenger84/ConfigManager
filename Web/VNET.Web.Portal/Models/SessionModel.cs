using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Web.Portal.Models
{
    public class SessionModel
    {
        public string Token { get; set; }
        public PortalUser PortalUser { get; set; }

        [Required(ErrorMessage = "Kullancı adı alanını doldurunuz.")]
        [MinLength(5, ErrorMessage = "Kullanıcı adı 5 karakterden az olamaz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre alanını doldurunuz.")]
        [MinLength(3, ErrorMessage = "Şifre 3 karakterden az olamaz.")]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
        public bool? IsAuthenticated { get; set; }
    }
}