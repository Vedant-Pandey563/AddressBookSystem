
/*
 * Ability to create a Contacts in Address
Book with first and last names, address,
city, state, zip, phone number and
email…
 */

namespace AddressBookSystem
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book System");

            

            Console.WriteLine("Please enter Contact Details");

            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter Address: ");
            string address = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter City Name: ");
            string city = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter State Name: ");
            string state = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter Zip Code: ");
            string zipCode = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine(); 

            Console.WriteLine("Enter Email Id: ");
            string emailId = Console.ReadLine();
            Console.WriteLine();

            Contact c = new Contact(firstName, lastName, address, city, state, zipCode, phoneNumber, emailId);
            Console.WriteLine();
            Console.WriteLine("Created Contact Succesfully");
            Console.WriteLine();

            c.PrintContact();


        }
    }
}
