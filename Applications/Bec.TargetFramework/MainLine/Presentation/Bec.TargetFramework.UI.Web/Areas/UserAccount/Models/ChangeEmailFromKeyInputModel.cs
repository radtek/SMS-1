﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Models
{
    public class ChangeEmailFromKeyInputModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput]
        public string Key { get; set; }
    }
}