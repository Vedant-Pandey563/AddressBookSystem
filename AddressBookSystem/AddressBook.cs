namespace AddressBookSystem
{
    public class AddressBook
    {
        private List<Contact> contacts = new();
        private Dictionary<string, List<Contact>> cityDict = new();
        private Dictionary<string, List<Contact>> stateDict = new();

        public bool AddContact(Contact c)
        {
            if (contacts.Contains(c)) return false;

            contacts.Add(c);

            if (!cityDict.ContainsKey(c.City))
                cityDict[c.City] = new List<Contact>();
            cityDict[c.City].Add(c);

            if (!stateDict.ContainsKey(c.State))
                stateDict[c.State] = new List<Contact>();
            stateDict[c.State].Add(c);

            return true;
        }

        public bool EditContact(string name, Contact updated)
        {
            var c = contacts.FirstOrDefault(x =>
                x.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (c == null) return false;

            cityDict[c.City].Remove(c);
            stateDict[c.State].Remove(c);

            c.LastName = updated.LastName;
            c.Address = updated.Address;
            c.City = updated.City;
            c.State = updated.State;
            c.ZipCode = updated.ZipCode;
            c.PhoneNumber = updated.PhoneNumber;
            c.EmailId = updated.EmailId;

            AddContact(c);
            return true;
        }

        public bool DeleteContact(string name)
        {
            var c = contacts.FirstOrDefault(x =>
                x.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (c == null) return false;

            contacts.Remove(c);
            cityDict[c.City].Remove(c);
            stateDict[c.State].Remove(c);

            return true;
        }

        public List<Contact> GetAllContacts() => contacts;

        public List<Contact> GetByCity(string city) =>
            cityDict.ContainsKey(city) ? cityDict[city] : new();

        public List<Contact> GetByState(string state) =>
            stateDict.ContainsKey(state) ? stateDict[state] : new();

        public int GetCountByCity(string city) =>
            cityDict.ContainsKey(city) ? cityDict[city].Count : 0;

        public int GetCountByState(string state) =>
            stateDict.ContainsKey(state) ? stateDict[state].Count : 0;

        public List<Contact> GetSortedByName() =>
            contacts.OrderBy(c => c.FirstName).ToList();

        public List<Contact> GetSortedByCity() =>
            contacts.OrderBy(c => c.City).ToList();

        public List<Contact> GetSortedByState() =>
            contacts.OrderBy(c => c.State).ToList();

        public List<Contact> GetSortedByZip() =>
            contacts.OrderBy(c => c.ZipCode).ToList();
    }
}