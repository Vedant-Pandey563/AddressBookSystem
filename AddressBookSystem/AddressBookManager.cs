namespace AddressBookSystem
{
    public class AddressBookManager
    {
        private Dictionary<string, AddressBook> books = new();
        private AddressBook current;

        public bool CreateAddressBook(string name)
        {
            if (books.ContainsKey(name))
                return false;

            books[name] = new AddressBook();
            return true;
        }

        public bool SelectAddressBook(string name)
        {
            if (!books.ContainsKey(name))
                return false;

            current = books[name];
            return true;
        }

        public AddressBook GetCurrentAddressBook() => current;
    }
}