using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }

        
        public Contact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNumber, string emailId)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
            PhoneNumber = phoneNumber;
            EmailId = emailId;
        }

        public void PrintContact()
        {
            Console.WriteLine(" Details: ");
            Console.WriteLine($"First Name  : {FirstName}");
            Console.WriteLine($"Last Name   : {LastName}");
            Console.WriteLine($"Address     : {Address}");
            Console.WriteLine($"City        : {City}");
            Console.WriteLine($"State       : {State}");
            Console.WriteLine($"Zip Code    : {ZipCode}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
            Console.WriteLine($"Email Id    : {EmailId}");
            Console.WriteLine();
        }

    }
}
