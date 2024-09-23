namespace ContactTask
{
    class ContactRepo<T>
        where T : Contact
    {
        Dictionary<int,T> Contacts = new Dictionary<int, T>();
        public int[] AddContact(T c)
        {
            if (Contacts.ContainsKey(c.Id)) {
                return [-1,c.Id] ;
            } else {
                if (c.IsValidEmail())
                {
                    Contacts.Add(c.Id, c);
                    OnContactAdded(c);
                    return [0,c.Id];
                }
                else
                {
                    return [-2,c.Id];
                }
            }
        }
        public T DeleteContact(int id)
        {
            if(Contacts.TryGetValue(id, out T? c)){
                Contacts.Remove(id);
                OnContactDeleted(c);
                return c;
            }
            return null;
        }
        public T DeleteContact(T c)
        {
            if (Contacts.ContainsKey(c.Id))
            {
                Contacts.Remove(c.Id);
                OnContactDeleted(c);
                return c;
            }
            return null;
        }
        public IEnumerable<T> GetAll()
        {
            return Contacts.Values;
        }
        public bool ClearRepo()
        {
            Contacts.Clear();
            return true;
        }

        public event EventHandler<T>? ContactAdded;
        public event EventHandler<T>? ContactDeleted;

        public void OnContactAdded(T c)
        {
            ContactAdded?.Invoke(this, c);
        }
        public void OnContactDeleted(T c)
        {
            ContactDeleted?.Invoke(this, c);
        }
    }
}
