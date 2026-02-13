
/*
Ability to delete a
person using
person's name - Use Console to delete a person
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

        }

        // method to update target contact details
        static void UpdateContact(AddressBook addressBook) // passing addressbook obj to modfify contact in it
        {
            Console.WriteLine("Enter name of target contact : ");
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

        static void Main(string[] args)
        {
            Console.WriteLine("Address Book System");

            
            AddressBook addressBook = new AddressBook();
            Contact c = new Contact("", "", "", "", "", "", "", "");

            GetDetails(c);

            Console.WriteLine();
            Console.WriteLine("Created Contact Succesfully");
            Console.WriteLine();

            addressBook.AddContact(c);
       

            Console.WriteLine("Contact added successfully to Address Book.");
            addressBook.PrintAddressBook();
            Console.WriteLine();

            UpdateContact(addressBook);

            addressBook.PrintAddressBook();
            Console.WriteLine();

            DeleteContact(addressBook);
            addressBook.PrintAddressBook();
            Console.WriteLine();


        }
    }
}
