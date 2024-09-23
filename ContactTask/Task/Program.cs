namespace ContactTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            void EnsureAdd(int[] v)
            {
                if (v[0] == -2) Console.WriteLine($"Invalid Email (Contact #{v[1]})");
                else if (v[0] == -1) Console.WriteLine($"Contact #{v[1]} is already exist");
            }
            // create instances
            ContactRepo<Contact> ContactRepo = new ContactRepo<Contact>();
            ContactRepo<BusinessContact> BusinessContactRepo = new ContactRepo<BusinessContact>();

            Contact C1 = new Contact("Mohamed", "mo7amedhassan@gmail.com", "01123","ard el lewa");
            Contact C2 = new Contact("Ahmed", "a7med55@gmail.com", "0152406", "mataria");
            Contact C3 = new Contact("Hossam", "7ossam48@gmai.com", "50", "giza");
            Contact C4 = new Contact("Marawan", "marawan69@gmail.com", "055", "imbaba");

            BusinessContact BC1 = new BusinessContact("Mazen", "mazen@gmail.com", "01145", "giza","SWE","Google");
            BusinessContact BC2 = new BusinessContact("Ali", "ali@gmail.com", "0110223", "KSA", "SWE", "MS");

            // methods OnContactAdded
            void OnContactAdded(object sender,Contact c) 
                => Console.WriteLine($"Contact has been added => ({c.Id} , {c.Name})");

            // method OnContactUpdated
            void OnContactUpdated(object sender, Contact c)
                => Console.WriteLine($"Contact has been updated => ({c.Id} , {c.Name})");

            // method OnContactDeleted
            void OnContactDeleted(object sender, Contact c)
                => Console.WriteLine($"Contact #{c.Id} has been deleted");

            // subscribe to the events
            ContactRepo.ContactAdded += OnContactAdded;
            BusinessContactRepo.ContactAdded += OnContactAdded;
            ContactRepo.ContactDeleted += OnContactDeleted;
            BusinessContactRepo.ContactDeleted += OnContactDeleted;


            // add contacts 
            EnsureAdd(ContactRepo.AddContact(C1));
            EnsureAdd(ContactRepo.AddContact(C2));
            EnsureAdd(ContactRepo.AddContact(C3));
            EnsureAdd(ContactRepo.AddContact(C4));
            EnsureAdd(ContactRepo.AddContact(C4));

            // add business contacts
            EnsureAdd(BusinessContactRepo.AddContact(BC1));
            EnsureAdd(BusinessContactRepo.AddContact(BC2));

            ContactRepo.DeleteContact(C2);

            // view contacts
            Console.WriteLine(string.Join("\n",ContactRepo.GetAll()));
            Console.WriteLine(string.Join("\n",BusinessContactRepo.GetAll()));

        }
    }
}
