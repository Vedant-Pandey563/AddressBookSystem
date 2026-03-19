namespace AddressBookSystem
{
    internal class Program
    {
        static AddressBookManager manager = new AddressBookManager();

        static void Main(string[] args)
        {
            Console.WriteLine("Address Book System");

            while (true)
            {
                DisplayMenu();

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CreateAddressBook();
                        break;

                    case 2:
                        SelectAddressBook();
                        break;

                    case 3:
                        AddContact();
                        break;

                    case 4:
                        EditContact();
                        break;

                    case 5:
                        DeleteContact();
                        break;

                    case 6:
                        DisplayContacts();
                        break;

                    case 7:
                        ViewByCity();
                        break;

                    case 8:
                        ViewByState();
                        break;

                    case 9:
                        CountByCity();
                        break;

                    case 10:
                        CountByState();
                        break;

                    case 11:
                        SortByName();
                        break;

                    case 12:
                        SortByCity();
                        break;

                    case 13:
                        SortByState();
                        break;

                    case 14:
                        SortByZip();
                        break;

                    case 15:
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // menu

        static void DisplayMenu()
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Create Address Book");
            Console.WriteLine("2. Select Address Book");
            Console.WriteLine("3. Add Contact");
            Console.WriteLine("4. Edit Contact");
            Console.WriteLine("5. Delete Contact");
            Console.WriteLine("6. Display Contacts");
            Console.WriteLine("7. View by City");
            Console.WriteLine("8. View by State");
            Console.WriteLine("9. Count by City");
            Console.WriteLine("10. Count by State");
            Console.WriteLine("11. Sort by Name");
            Console.WriteLine("12. Sort by City");
            Console.WriteLine("13. Sort by State");
            Console.WriteLine("14. Sort by Zip");
            Console.WriteLine("15. Exit");
        }

        // helper func

        static AddressBook GetCurrent()
        {
            var book = manager.GetCurrentAddressBook();
            if (book == null)
                Console.WriteLine("Select Address Book first.");
            return book;
        }

        // operations 

        static void CreateAddressBook()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine(manager.CreateAddressBook(name)
                ? "Created."
                : "Already exists.");
        }

        static void SelectAddressBook()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine(manager.SelectAddressBook(name)
                ? "Selected."
                : "Not found.");
        }

        static void AddContact()
        {
            var book = GetCurrent();
            if (book == null) return;

            Contact c = ContactInputService.ReadContact();

            Console.WriteLine(book.AddContact(c)
                ? "Added."
                : "Duplicate contact.");
        }

        static void EditContact()
        {
            var book = GetCurrent();
            if (book == null) return;

            Console.Write("Enter First Name: ");
            string name = Console.ReadLine();

            Contact updated = ContactInputService.ReadContact();

            Console.WriteLine(book.EditContact(name, updated)
                ? "Updated."
                : "Not found.");
        }

        static void DeleteContact()
        {
            var book = GetCurrent();
            if (book == null) return;

            Console.Write("Enter First Name: ");
            string name = Console.ReadLine();

            Console.WriteLine(book.DeleteContact(name)
                ? "Deleted."
                : "Not found.");
        }

        static void DisplayContacts()
        {
            var book = GetCurrent();
            if (book == null) return;

            foreach (var c in book.GetAllContacts())
                Console.WriteLine(c);
        }

        static void ViewByCity()
        {
            var book = GetCurrent();
            if (book == null) return;

            Console.Write("City: ");
            string city = Console.ReadLine();

            foreach (var c in book.GetByCity(city))
                Console.WriteLine(c);
        }

        static void ViewByState()
        {
            var book = GetCurrent();
            if (book == null) return;

            Console.Write("State: ");
            string state = Console.ReadLine();

            foreach (var c in book.GetByState(state))
                Console.WriteLine(c);
        }

        static void CountByCity()
        {
            var book = GetCurrent();
            if (book == null) return;

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.WriteLine(book.GetCountByCity(city));
        }

        static void CountByState()
        {
            var book = GetCurrent();
            if (book == null) return;

            Console.Write("State: ");
            string state = Console.ReadLine();

            Console.WriteLine(book.GetCountByState(state));
        }

        static void SortByName()
        {
            var book = GetCurrent();
            if (book == null) return;

            foreach (var c in book.GetSortedByName())
                Console.WriteLine(c);
        }

        static void SortByCity()
        {
            var book = GetCurrent();
            if (book == null) return;

            foreach (var c in book.GetSortedByCity())
                Console.WriteLine(c);
        }

        static void SortByState()
        {
            var book = GetCurrent();
            if (book == null) return;

            foreach (var c in book.GetSortedByState())
                Console.WriteLine(c);
        }

        static void SortByZip()
        {
            var book = GetCurrent();
            if (book == null) return;

            foreach (var c in book.GetSortedByZip())
                Console.WriteLine(c);
        }
    }
}