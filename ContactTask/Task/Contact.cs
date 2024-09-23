namespace ContactTask
{
    class Contact
    {
        protected static int Counter;
        protected int id;
        protected string name;
        protected string email;
        protected string phone;
        protected string address;

        public Contact(string name, string email, string phone, string address)
        {
            this.id = ++Contact.Counter;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.address = address;
        }
        
        public int Id { get => id; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set { email = value; } }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public override string ToString() => $"Id: {id} , Name: {name} , Email: {email} , Phone: {phone} , Address: {address}";

        
    }
}
