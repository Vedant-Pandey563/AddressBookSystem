using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;

namespace AddressBookSystem
{
    public static class CsvFileService
    {
        // write to csv
        public static void WriteToCsv(AddressBook addressBook, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    var contacts = addressBook.GetAllContacts();
                    csv.WriteRecords(contacts);
                }

                Console.WriteLine("Saved to CSV successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing CSV: " + ex.Message);
            }
        }

        // read csv 
        public static AddressBook ReadFromCsv(string filePath)
        {
            AddressBook addressBook = new AddressBook();

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found.");
                    return addressBook;
                }

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Contact>();

                    foreach (var c in records)
                    {
                        addressBook.AddContact(c); // IMPORTANT
                    }
                }

                Console.WriteLine("Loaded from CSV successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading CSV: " + ex.Message);
            }

            return addressBook;
        }
    }
}