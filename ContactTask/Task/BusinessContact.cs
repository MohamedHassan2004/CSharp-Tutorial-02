using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace ContactTask
{
    class BusinessContact : Contact
    {
        static int Counter = 2000;
        string jobTitle;
        string company;
        public BusinessContact(string name, string email, string phone, string address,string jobTitle,string company) : base(name, email, phone, address)
        {
            id = ++BusinessContact.Counter;
            this.jobTitle = jobTitle;
            this.company = company;
        }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        public string Company { get => company; set => company = value; }
        public override string ToString() => $"{base.ToString()} , Job Title: {jobTitle} , Company: {company} ";
    }
}
