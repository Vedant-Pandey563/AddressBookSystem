
/*
main till UC11  
 */


namespace AddressBookSystem
{

    internal class Program
    {

        static Dictionary<string, AddressBook> addressBooks = new Dictionary<string, AddressBook>();// dict
        static AddressBook currentAddressBook = null;// new addressbok obj for dict



        static void CreateAddressBook() // creating new addr books in dict
        {
            Console.Write("Enter new Address Book name: ");
            string name = Console.ReadLine();

            // Check for no copy of addr book name
            if (addressBooks.ContainsKey(name))
            {
                Console.WriteLine("Address Book with this name already exists.");
                return;
            }

            addressBooks[name] = new AddressBook();
            Console.WriteLine("Address Book created successfully!");
        }



        static void SelectAddressBook() //method to slect a specfic addr book
        {
            Console.Write("Enter Address Book name to select: ");
            string name = Console.ReadLine();

            if (addressBooks.ContainsKey(name))
            {
                currentAddressBook = addressBooks[name];
                Console.WriteLine($"Address Book '{name}' selected.");
            }
            else
            {
                Console.WriteLine("Address Book not found.");
            }
        }




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

        //method to add contact
        static void AddContact()
        {
            if (currentAddressBook == null)
            {
                Console.WriteLine("Please select an Address Book first.");
                return;
            }

            Console.WriteLine("Enter Contact Details");
            Contact c = new Contact("", "", "", "", "", "", "", "");
            GetDetails(c);

            bool isAdded = currentAddressBook.AddContact(c);

            if (isAdded)
            {
                Console.WriteLine("Contact added successfully!");
            }
            else
            {
                Console.WriteLine("Duplicate contact found! Phone number or Email already exists.");
            }
        }


        // method to update target contact details
        static void UpdateContact() // passing addressbook obj to modfify contact in it
        {
            if (currentAddressBook == null)
            {
                Console.WriteLine("Please select an Address Book first.");
                return;
            }


            Console.Write("Enter First Name of Contact to Edit: ");
            string target = Console.ReadLine();

            Contact updated = new Contact(target, "", "", "", "", "", "", "");
            GetDetails(updated);

            bool isUpdated = currentAddressBook.EditContact(target, updated);

            if (isUpdated)
                Console.WriteLine("Contact updated successfully!");
            else
                Console.WriteLine("Contact not found.");
        }



        //method to delete contact 
        static void DeleteContact()
        {
            if (currentAddressBook == null)
            {
                Console.WriteLine("Please select an Address Book first.");
                return;
            }

            Console.Write("Enter First Name of Contact to Delete: ");
            string nameToDelete = Console.ReadLine();

            bool isDeleted = currentAddressBook.DeleteContact(nameToDelete);

            if (isDeleted)
            {
                Console.WriteLine("Contact deleted successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        // method to display contacts in a addr book
        static void DisplayContacts()
        {
            if (currentAddressBook == null)
            {
                Console.WriteLine("Please select an Address Book first.");
                return;
            }

            currentAddressBook.PrintAddressBook();
        }



        //menu displahy methood
        static void DisplayMenu()
        {
            Console.WriteLine("\n Address Book Menu");
            Console.WriteLine("1. Create Address Book");
            Console.WriteLine("2. Select Address Book");
            Console.WriteLine("3. Add Contact");
            Console.WriteLine("4. Edit Contact");
            Console.WriteLine("5. Delete Contact");
            Console.WriteLine("6. Display Contacts");
            Console.WriteLine("7. View Persons by City");
            Console.WriteLine("8. View Persons by State");
            Console.WriteLine("9. Count Persons by City");
            Console.WriteLine("10. Count Persons by State");
            Console.WriteLine("11. Sort Contacts by Name");
            Console.WriteLine("12. Sort Contacts by City");
            Console.WriteLine("13. Sort Contacts by State");
            Console.WriteLine("14. Sort Contacts by Zip");
            Console.WriteLine("15. Exit");

            Console.Write("Enter choice: ");
        }

        // remvoed method SearchAcrossAddressBooks to search by city or state  




        static void Main(string[] args)
        {
            Console.WriteLine("Address Book System");

            //menu with while and nested switch



            // no use anymore AddressBook addressBook = new AddressBook();

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
                        CreateAddressBook();
                        break;

                    case 2:
                        SelectAddressBook();
                        break;

                    case 3:
                        AddContact();
                        break;

                    case 4:
                        UpdateContact();
                        break;

                    case 5:
                        DeleteContact();
                        break;

                    case 6:
                        DisplayContacts();
                        break;

                    case 7:
                        if (currentAddressBook == null)
                        {
                            Console.WriteLine("Please select an Address Book first.");
                            break;
                        }

                        Console.Write("Enter City: ");
                        string city = Console.ReadLine();
                        currentAddressBook.ViewByCity(city);
                        break;

                    case 8:
                        if (currentAddressBook == null)
                        {
                            Console.WriteLine("Please select an Address Book first.");
                            break;
                        }

                        Console.Write("Enter State: ");
                        string state = Console.ReadLine();
                        currentAddressBook.ViewByState(state);
                        break;

                    case 9:
                        if (currentAddressBook == null)
                        {
                            Console.WriteLine("Please select an Address Book first.");
                            break;
                        }

                        Console.Write("Enter City: ");
                        string cityCount = Console.ReadLine();
                        int cityTotal = currentAddressBook.GetCountByCity(cityCount);
                        Console.WriteLine($"Total persons in city '{cityCount}': {cityTotal}");
                        break;

                    case 10:
                        if (currentAddressBook == null)
                        {
                            Console.WriteLine("Please select an Address Book first.");
                            break;
                        }

                        Console.Write("Enter State: ");
                        string stateCount = Console.ReadLine();
                        int stateTotal = currentAddressBook.GetCountByState(stateCount);
                        Console.WriteLine($"Total persons in state '{stateCount}': {stateTotal}");
                        break;

                    case 11:
                        if (currentAddressBook == null)
                        {
                            Console.WriteLine("Please select an Address Book first.");
                            break;
                        }

                        currentAddressBook.SortByName();
                        break;

                    case 12:
                        if (currentAddressBook == null)
                        {
                            Console.WriteLine("Select Address Book first.");
                            break;
                        }
                        currentAddressBook.SortByCity();
                        break;

                    case 13:
                        if (currentAddressBook == null)
                        {
                            Console.WriteLine("Select Address Book first.");
                            break;
                        }
                        currentAddressBook.SortByState();
                        break;

                    case 14:
                        if (currentAddressBook == null)
                        {
                            Console.WriteLine("Select Address Book first.");
                            break;
                        }
                        currentAddressBook.SortByZip();
                        break;

                    case 15:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine();


            }
        }
    }
}
