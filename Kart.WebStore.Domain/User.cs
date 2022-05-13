
namespace Kart.WebStore.Domain
{
    public class User
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }

    }

    public class Signin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

