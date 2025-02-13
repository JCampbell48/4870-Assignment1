using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models;
    public class User

    {   [Key]  
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]  
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Role { get; set; }
        
        public bool IsApproved { get; set; } = false;
    }
