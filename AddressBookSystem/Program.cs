

/*
UC13
Ability to Read or Write
the Address Book with
Persons Contact into a
File using File IO
 */


namespace AddressBookSystem


{
    internal class Program
    {
        static AddressBookManager manager = new AddressBookManager();
        static AddressBookController controller = new AddressBookController(manager);

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
                    case 1: controller.CreateAddressBook(); break;
                    case 2: controller.SelectAddressBook(); break;
                    case 3: controller.AddContact(); break;
                    case 4: controller.EditContact(); break;
                    case 5: controller.DeleteContact(); break;
                    case 6: controller.DisplayContacts(); break;
                    case 7: controller.ViewByCity(); break;
                    case 8: controller.ViewByState(); break;
                    case 9: controller.CountByCity(); break;
                    case 10: controller.CountByState(); break;
                    case 11: controller.SortByName(); break;
                    case 12: controller.SortByCity(); break;
                    case 13: controller.SortByState(); break;
                    case 14: controller.SortByZip(); break;
                    case 15: controller.SaveToFile(); break;
                    case 16: controller.LoadFromFile(); break;
                    case 17: return;
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
            Console.WriteLine("15. Save to File");
            Console.WriteLine("16. Load from File");
            Console.WriteLine("17. Exit");
        }

        // helper func

        static AddressBook GetCurrent()
        {
            var book = manager.GetCurrentAddressBook();
            if (book == null)
                Console.WriteLine("Select Address Book first.");
            return book;
        }
    }
}