﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class ChiefUserAdminViewModel
    {
        public int ChiefUserId { get; set; }
        public int PortfolioId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Birth { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string Skype { get; set; }
        public string Mobile { get; set; }
        public string Github { get; set; }
        public string Linkedin { get; set; }

        public PortfolioAdminViewModel PortfolioViewModel { get; set; }
    }
}