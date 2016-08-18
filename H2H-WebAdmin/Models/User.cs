using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2H_WebAdmin.Models
{
    public class User
    {
       public String UserId { get; set; }
        public string Phone { get; set; }
        public String adresse { get; set; }
        [Required(ErrorMessage ="Please provide Passeword",AllowEmptyStrings =false)]
        [DataType(DataType.Password)]
        public String passeword { get; set; }
       
        public string Image { get; set; }
        public string Email { get; set; }

        public String username { get; set; }
        public virtual List<RendezVous> ListRDV { get; set; }

        public User()
        { }
    }
}