using System;
using System.Collections.Generic;

namespace Interns.Presentation.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }

        public string PasswordSalt { get; set; }
        
        public DateTime? CreateDate { get; set; }

        public string Phone { get; set; }

        public string University { get; set; }

        //public virtual AddressDto Address { get; set; }

        //public virtual RoleDto Role { get; set; }

        public int? RoleId { get; set; }

        //public IEnumerable<AdvertiseDto> Advertises { get; set; }
    }
}