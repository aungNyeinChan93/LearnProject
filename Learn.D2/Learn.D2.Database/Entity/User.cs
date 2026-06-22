using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learn.D2.Database.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } =string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
