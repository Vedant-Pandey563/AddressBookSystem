
/*
Main Branch
 */

namespace AddressBookSystem
{

    internal class Program
    {
        static void GetDetails(Contact c) // method to get contact details
        {
            Console.WriteLine("Please enter Contact Details");

            Console.Write("Enter First Name: ");
            c.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            c.LastName = Console.ReadLine();

            Console.Write("Enter Address: ");
            c.Address = Console.ReadLine();

            Console.Write("Enter City Name: ");
            c.City = Console.ReadLine();

            Console.Write("Enter State Name: ");
            c.State = Console.ReadLine();

            Console.Write("Enter Zip Code: ");
            c.ZipCode = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            c.PhoneNumber = Console.ReadLine();

            Console.Write("Enter Email Id: ");
            c.EmailId = Console.ReadLine();

            Console.WriteLine();

        }

        // method to update target contact details
        static void UpdateContact(AddressBook addressBook) // passing addressbook obj to modfify contact in it
        {
            Console.WriteLine("Enter First name of target contact : ");
            string target = Console.ReadLine();

            bool checkName = addressBook.inList(target);
            if (checkName)
            {
                Contact tempContact = new Contact(target, "", "", "", "", "", "", "");
                GetDetails(tempContact);

                bool isUpdated = addressBook.EditContact(target, tempContact);

                if (isUpdated)
                {
                    Console.WriteLine("\nContact updated successfully!");
                }
                else
                {
                    Console.WriteLine("\nContact not found.");
                }
            }
            else
            {
                Console.WriteLine("\nContact not found.");
            }
        }

        //method to delete contact 
        static void DeleteContact(AddressBook addressBook)
        {
            Console.Write("Enter First Name of Contact to Delete: ");
            string nameToDelete = Console.ReadLine();

            bool isDeleted = addressBook.DeleteContact(nameToDelete);

            if (isDeleted)
            {
                Console.WriteLine("Contact deleted successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\n Address Book Menu");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Display Address Book");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
        }

        static void AddContact(AddressBook addressBook)
        {
            Console.WriteLine("Enter Contact Details");
            Contact c = new Contact("", "", "", "", "", "", "", "");
            GetDetails(c);

            bool isAdded = addressBook.AddContact(c);

            if (isAdded)
            {
                Console.WriteLine("Contact added successfully!");
            }
            else
            {
                Console.WriteLine("Duplicate contact found! Phone number or Email already exists.");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Address Book System");

            //menu with while and nested switch



            AddressBook addressBook = new AddressBook();

            //switch nested in while menu

            while (true)
            {
                DisplayMenu();

                if (!int.TryParse(Console.ReadLine(), out int choice)) // checck if choice is int or not
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddContact(addressBook);
                        break;

                    case 2:
                        UpdateContact(addressBook);
                        break;

                    case 3:
                        DeleteContact(addressBook);
                        break;

                    case 4:
                        addressBook.PrintAddressBook();
                        break;

                    case 5:
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                Console.WriteLine();


            }
        }
    }
}
