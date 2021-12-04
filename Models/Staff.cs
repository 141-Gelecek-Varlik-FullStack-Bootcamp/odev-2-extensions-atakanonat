using System;

namespace Models
{
    public class Staff : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public bool IsAdmin { get; set; }
    }
}