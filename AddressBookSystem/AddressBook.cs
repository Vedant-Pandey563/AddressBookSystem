using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBook
    {
        private List<Contact> contacts; // creat list

        //dicts of city and state
        private Dictionary<string, List<Contact>> cityDictionary;
        private Dictionary<string, List<Contact>> stateDictionary;

        public AddressBook() //address book constructor
        {
            contacts = new List<Contact>();
            cityDictionary = new Dictionary<string, List<Contact>>();
            stateDictionary = new Dictionary<string, List<Contact>>();
        }

        public bool AddContact(Contact contact) //add conctact method
        {
            if (contacts.Contains(contact)) // conatains uses equals which is overriden
            {
                return false;
            }

            contacts.Add(contact);
            //update city dict
            if (!cityDictionary.ContainsKey(contact.City))
            {
                cityDictionary[contact.City] = new List<Contact>();
            }
            cityDictionary[contact.City].Add(contact);
            //update state dict 
            if (!stateDictionary.ContainsKey(contact.State))
            {
                stateDictionary[contact.State] = new List<Contact>();
            }
            stateDictionary[contact.State].Add(contact);
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

        //method to print contacts by cities
        public void ViewByCity(string city)
        {
            if (cityDictionary.ContainsKey(city))
            {
                foreach (Contact c in cityDictionary[city])
                {
                    c.PrintContact();
                }
            }
            else
            {
                Console.WriteLine("No contacts found in this city.");
            }
        }

        //same for states 
        public void ViewByState(string state)
        {
            if (stateDictionary.ContainsKey(state))
            {
                foreach (Contact c in stateDictionary[state])
                {
                    c.PrintContact();
                }
            }
            else
            {
                Console.WriteLine("No contacts found in this state.");
            }
        }


        // inlist method removed , but how it is there in uc8,9 but not in uc7 
        //should recheck
        public bool EditContact(string targetName, Contact updatedContact)
        {
            foreach (Contact c in contacts)
            {
                if (c.FirstName.Equals(targetName, StringComparison.OrdinalIgnoreCase))
                {


                    //remove old dict entries for city,state 
                    cityDictionary[c.City].Remove(c);
                    stateDictionary[c.State].Remove(c);

                    //now update
                    c.LastName = updatedContact.LastName;
                    c.Address = updatedContact.Address;
                    c.City = updatedContact.City;
                    c.State = updatedContact.State;
                    c.ZipCode = updatedContact.ZipCode;
                    c.PhoneNumber = updatedContact.PhoneNumber;
                    c.EmailId = updatedContact.EmailId;

                    //now add updated back to dicts 
                    if (!cityDictionary.ContainsKey(c.City))
                        cityDictionary[c.City] = new List<Contact>();
                    cityDictionary[c.City].Add(c);

                    if (!stateDictionary.ContainsKey(c.State))
                        stateDictionary[c.State] = new List<Contact>();
                    stateDictionary[c.State].Add(c);

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
                    Contact c = contacts[i];
                    cityDictionary[c.City].Remove(c);
                    stateDictionary[c.State].Remove(c);
                    contacts.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        // city searcher method
        public List<Contact> SearchByCity(string city)
        {
            List<Contact> result = new List<Contact>();

            foreach (Contact c in contacts)
            {
                if (c.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(c);
                }
            }

            return result;
        }

        //state searcher method 
        public List<Contact> SearchByState(string state)
        {
            List<Contact> result = new List<Contact>();

            foreach (Contact c in contacts)
            {
                if (c.State.Equals(state, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(c);
                }
            }

            return result;
        }

        //count of city 
        public int GetCountByCity(string city)
        {
            if (cityDictionary.ContainsKey(city))
                return cityDictionary[city].Count;

            return 0;
        }

        //count of state 
        public int GetCountByState(string state)
        {
            if (stateDictionary.ContainsKey(state))
                return stateDictionary[state].Count;

            return 0;
        }


    }
}
