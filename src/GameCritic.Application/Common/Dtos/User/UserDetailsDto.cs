using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCritic.Application.Common.Dtos.User
{
    public class UserDetailsDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDateTime { get; set; }

        public int ReviewCount { get; set; }

        public double Score { get; set; }
    }
}
