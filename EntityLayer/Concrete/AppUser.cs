﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
      
        

    }
}