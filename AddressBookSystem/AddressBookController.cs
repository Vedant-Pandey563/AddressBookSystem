using System;

namespace AddressBookSystem
{
    public class AddressBookController
    {
        private AddressBookManager manager;

        public AddressBookController(AddressBookManager manager)
        {
            this.manager = manager;
        }

        private AddressBook GetCurrent()
        {
            var book = manager.GetCurrentAddressBook();
            if (book == null)
                Console.WriteLine("Select Address Book first.");
            return book;
        }

        // operations 

        public void CreateAddressBook()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine(manager.CreateAddressBook(name)
                ? "Created."
                : "Already exists.");
        }

        public void SelectAddressBook()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine(manager.SelectAddressBook(name)
                ? "Selected."
                : "Not found.");
        }

        public void AddContact()
        {
            var book = GetCurrent();
            if (book == null) return;

            Contact c = ContactInputService.ReadContact();

            Console.WriteLine(book.AddContact(c)
                ? "Added."
                : "Duplicate contact.");
        }

        public void EditContact()
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

        public void DeleteContact()
        {
            var book = GetCurrent();
            if (book == null) return;

            Console.Write("Enter First Name: ");
            string name = Console.ReadLine();

            Console.WriteLine(book.DeleteContact(name)
                ? "Deleted."
                : "Not found.");
        }

        public void DisplayContacts()
        {
            var book = GetCurrent();
            if (book == null) return;

            foreach (var c in book.GetAllContacts())
                Console.WriteLine(c);
        }

        public void ViewByCity()
        {
            var book = GetCurrent();
            if (book == null) return;

            Console.Write("City: ");
            string city = Console.ReadLine();

            foreach (var c in book.GetByCity(city))
                Console.WriteLine(c);
        }

        public void ViewByState()
        {
            var book = GetCurrent();
            if (book == null) return;

            Console.Write("State: ");
            string state = Console.ReadLine();

            foreach (var c in book.GetByState(state))
                Console.WriteLine(c);
        }

        public void CountByCity()
        {
            var book = GetCurrent();
            if (book == null) return;

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.WriteLine(book.GetCountByCity(city));
        }

        public void CountByState()
        {
            var book = GetCurrent();
            if (book == null) return;

            Console.Write("State: ");
            string state = Console.ReadLine();

            Console.WriteLine(book.GetCountByState(state));
        }

        public void SortByName()
        {
            var book = GetCurrent();
            if (book == null) return;

            foreach (var c in book.GetSortedByName())
                Console.WriteLine(c);
        }

        public void SortByCity()
        {
            var book = GetCurrent();
            if (book == null) return;

            foreach (var c in book.GetSortedByCity())
                Console.WriteLine(c);
        }

        public void SortByState()
        {
            var book = GetCurrent();
            if (book == null) return;

            foreach (var c in book.GetSortedByState())
                Console.WriteLine(c);
        }

        public void SortByZip()
        {
            var book = GetCurrent();
            if (book == null) return;

            foreach (var c in book.GetSortedByZip())
                Console.WriteLine(c);
        }

        public void SaveToFile()
        {
            var book = GetCurrent();
            if (book == null) return;

            Console.Write("Enter file path: ");
            string path = Console.ReadLine();

            FileService.WriteToFile(book, path);
        }

        public void LoadFromFile()
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();

            AddressBook loaded = FileService.ReadFromFile(path);

            Console.Write("Enter name for this Address Book: ");
            string name = Console.ReadLine();

            if (manager.CreateAddressBook(name))
            {
                manager.SelectAddressBook(name);

                foreach (var c in loaded.GetAllContacts())
                {
                    manager.GetCurrentAddressBook().AddContact(c);
                }

                Console.WriteLine("Loaded successfully.");
            }
            else
            {
                Console.WriteLine("Address Book already exists.");
            }
        }

        public void SaveToCsv()
        {
            var book = GetCurrent();
            if (book == null) return;

            Console.Write("Enter CSV file path: ");
            string path = Console.ReadLine();

            CsvFileService.WriteToCsv(book, path);
        }

        public void LoadFromCsv()
        {
            Console.Write("Enter CSV file path: ");
            string path = Console.ReadLine();

            AddressBook loaded = CsvFileService.ReadFromCsv(path);

            Console.Write("Enter name for Address Book: ");
            string name = Console.ReadLine();

            if (manager.CreateAddressBook(name))
            {
                manager.SelectAddressBook(name);

                foreach (var c in loaded.GetAllContacts())
                {
                    manager.GetCurrentAddressBook().AddContact(c);
                }

                Console.WriteLine("CSV loaded successfully.");
            }
            else
            {
                Console.WriteLine("Address Book already exists.");
            }
        }
    }
}