using System;
using System.Collections.Generic;
using System.Text;

namespace Task_02
{
    class PhoneBook<TKey, TValue>
    {
        private Dictionary<TKey, TValue> phoneBook;

        public PhoneBook()
        {
            phoneBook = new Dictionary<TKey, TValue>();
        }

        public void AddEntry(TKey key, TValue value)
        {
            if (!phoneBook.ContainsKey(key))
            {
                phoneBook.Add(key, value);
                Console.WriteLine($"Record added: {key} - {value}");
            }
            else
            {
                Console.WriteLine($"An entry with the key {key} already exists in the phone book.");
            }
        }

        public void UpdateName(TKey oldKey, TKey newKey)
        {
            if (phoneBook.ContainsKey(oldKey))
            {
                TValue value = phoneBook[oldKey];
                phoneBook.Remove(oldKey);
                phoneBook.Add(newKey, value);

                Console.WriteLine($"Name updated from {oldKey} to {newKey}");
            }
            else
            {
                Console.WriteLine($"The entry with the key {oldKey} (name) was not found in the phone book.");
            }
        }

        public void UpdateNumber(TKey key, TValue newValue)
        {
            if (phoneBook.ContainsKey(key))
            {
                phoneBook[key] = newValue;
                Console.WriteLine($"Phone number updated for {key}: {newValue}");
            }
            else
            {
                Console.WriteLine($"The entry with the key {key} was not found in the phone book.");
            }
        }

        public TValue FindEntry(TKey key)
        {
            if (phoneBook.ContainsKey(key))
            {
                return phoneBook[key];
            }
            else
            {
                Console.WriteLine($"The entry with the key {key} was not found in the phone book.");
                return default(TValue);
            }
        }

        public void RemoveEntry(TKey key)
        {
            if (phoneBook.ContainsKey(key))
            {
                phoneBook.Remove(key);
                Console.WriteLine($"The entry with the key {key} has been deleted from the phone book.");
            }
            else
            {
                Console.WriteLine($"The entry with the key {key} was not found in the phone book.");
            }
        }

        public void PrintEntries()
        {
            Console.WriteLine("Phone book:");

            foreach (var entry in phoneBook)
            {
                Console.WriteLine($"{entry.Key} - {entry.Value}");
            }
        }
    }

}
