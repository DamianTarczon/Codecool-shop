using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Codecool.CodecoolShop.Models
{
    public class ProfileView
    {
        public IdentityUser User { get; set; }
        public List<Order> Order { get; set; }
    }
}
