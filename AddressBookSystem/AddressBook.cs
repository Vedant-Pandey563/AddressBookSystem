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

        public bool AddContact(Contact contact) //add conctact method
        {
            if (contacts.Contains(contact)) // conatains uses equals which is overriden
            {
                return false;
            }

            contacts.Add(contact);
            return true;

        }

        public void PrintAddressBook() //print contacts from list
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Address Book is Empty");
                return;
            }
            int i = 1;
            foreach (Contact c in contacts)
            {
                Console.Write("Contact No. " + i);
                c.PrintContact();
                i++;
            }
        }

        public bool inList(string targetName)
        {
            foreach(Contact c in contacts)
            {
                if(c.FirstName == targetName)
                {
                    return true;
                }
            }

            return false;
        }
        public bool EditContact(string targetName, Contact updatedContact)
        {
            foreach (Contact c in contacts)
            {
                if (c.FirstName.Equals(targetName, StringComparison.OrdinalIgnoreCase))
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

        public bool DeleteContact(string targetName)
        {
            for (int i = 0; i < contacts.Count; i++)//foreach loop gives synatx error
            {
                if (contacts[i].FirstName.Equals(targetName, StringComparison.OrdinalIgnoreCase))
                {
                    contacts.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }



    }
}
