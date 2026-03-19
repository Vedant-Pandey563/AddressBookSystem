using System;
using System.Collections.Generic;
using System.IO;

namespace AddressBookSystem
{
    public static class FileService
    {
        // WRITE 
        public static void WriteToFile(AddressBook addressBook, string filePath)
        {
            try
            {
                List<string> lines = new List<string>();

                foreach (var c in addressBook.GetAllContacts())
                {
                    string line = $"{c.FirstName},{c.LastName},{c.Address},{c.City},{c.State},{c.ZipCode},{c.PhoneNumber},{c.EmailId}";
                    lines.Add(line);
                }

                File.WriteAllLines(filePath, lines);

                Console.WriteLine("Address Book saved to file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing file: " + ex.Message);
            }
        }

        // READ 
        public static AddressBook ReadFromFile(string filePath)
        {
            AddressBook addressBook = new AddressBook();

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found.");
                    return addressBook;
                }

                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length != 8)
                        continue; // skip lines

                    Contact c = new Contact(
                        parts[0], // FirstName
                        parts[1], // LastName
                        parts[2], // Address
                        parts[3], // City
                        parts[4], // State
                        parts[5], // Zip
                        parts[6], // Phone
                        parts[7]  // Email
                    );

                    addressBook.AddContact(c); 
                }

                Console.WriteLine("Address Book loaded from file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }

            return addressBook;
        }
    }
}