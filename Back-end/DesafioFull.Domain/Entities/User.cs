using System.Collections.Generic;

namespace DesafioFull.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public virtual List<DebtSecurity> DebtSecuritys { get; set; }
    }
}
