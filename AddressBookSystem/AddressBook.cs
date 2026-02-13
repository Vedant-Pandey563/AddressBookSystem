using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBook
    {
        private List<Contact> contacts; // creat list

        public AddressBook() //address book constructor
        {
            contacts = new List<Contact>();
        }

        public void AddContact(Contact contact) //add conctact method
        {
            contacts.Add(contact);
        }

        public void PrintAddressBook() //print contacts from list
        {
            foreach(Contact c in contacts)
            {
                c.PrintContact();
            }
        }

        public bool EditContact(string targetName, Contact updatedContact)
        {
            foreach(Contact c in contacts)
            {
                if(c.FirstName.Equals(targetName, StringComparison.OrdinalIgnoreCase))
                {
                    c.LastName = updatedContact.LastName;
                    c.Address = updatedContact.Address;
                    c.City = updatedContact.City;
                    c.State = updatedContact.State;
                    c.ZipCode = updatedContact.ZipCode;
                    c.PhoneNumber = updatedContact.PhoneNumber;
                    c.EmailId = updatedContact.EmailId;

                    return true;
                }
            }

            return false;
        }

    }
}
