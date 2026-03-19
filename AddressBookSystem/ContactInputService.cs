namespace AddressBookSystem
{
    public static class ContactInputService
    {
        public static Contact ReadContact()
        {
            Console.Write("First Name: ");
            string first = Console.ReadLine();

            Console.Write("Last Name: ");
            string last = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("State: ");
            string state = Console.ReadLine();

            Console.Write("Zip: ");
            string zip = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            return new Contact(first, last, address, city, state, zip, phone, email);
        }
    }
}