using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace userAuthentication.Models
{
    public class Account
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}