using Microsoft.AspNetCore.Identity;
using GameCritic.Domain.Entities;
namespace GameCritic.Domain.Auth
{
    public class User : IdentityUser<int>
    {
        public ICollection<Review> Reviews { get; set; }

        public int ReviewCount { get; set; }

        public double Score { get; set; }

        public DateTime RegisterDateTime { get; set; } = DateTime.Now;
    }
}
