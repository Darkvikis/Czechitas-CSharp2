using System;

namespace ContactManager
{
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Phone: {PhoneNumber}, Email: {Email}";
        }
    }
}
