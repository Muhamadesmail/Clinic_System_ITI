using Clinic_System.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Clinic_System.DAL.Entities
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; } = 0;
        public Gender Gender { get; set; } = Gender.Male;

        //public Gender? Gender { get; set; }
        public string? Image {  get; set; }
        public bool? IsDeleted { get; set; } = false;
    }
}
