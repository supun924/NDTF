using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Users.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string ServiceNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string MobileNumber { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string RoleName { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
