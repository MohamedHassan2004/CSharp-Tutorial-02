using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    #region Person cls
    class Person
    {
        private string name;
        private int age;
        private List<string> friends;
        private HashSet<int> friendsHashCodes;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("The name cannot be null or empty", nameof(value));
                name = value;
            }
        }

        public int Age
        {
            get => age;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("The age cannot be negative", nameof(value));
                age = value;
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            friends = new List<string>();
            friendsHashCodes = new HashSet<int>();
        }

        public void DisplayInfo() => Console.WriteLine($"Name: {Name}\nAge: {Age}");

        /// <include file='demo.xml' path='docs/members[@name="demo"]/MakeFriendsWith/*'/>
        public void MakeFriendsWith(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person), "The person cannot be null");
            }

            if (friendsHashCodes.Contains(person.GetHashCode()))
            {
                Console.WriteLine($"{Name} is already friends with {person.Name}");
                return;
            }

            Console.WriteLine($"{Name} is making friends with {person.Name}");
            friends.Add(person.Name);
            friendsHashCodes.Add(person.GetHashCode());

            person.friends.Add(Name);
            person.friendsHashCodes.Add(this.GetHashCode());
        }

        public string FriendsNames() => $"{Name} Friends: {{{string.Join(", ", friends)}}}";
    }
    #endregion

    #region DateTimeExtension
    public static class DateTimeExtensions
    {
        public static int DaysUntilEndOfYear(this DateTime dateTime)
        {
            DateTime endOfYear = new DateTime(dateTime.Year, 12, 31);
            return (endOfYear - dateTime).Days;
        }
    }
    #endregion

    internal class Program
    {
        static void Line() => Console.WriteLine(new string('=', 60));
        static void Main(string[] args)
        {
            #region Person
            Person person1 = new Person("Ali", 18);
            Person person2 = new Person("Ahmed", 22);
            Person person3 = new Person("Mazen", 30);

            person1.MakeFriendsWith(person2);
            person1.MakeFriendsWith(person3);
            person1.MakeFriendsWith(person2);

            Console.WriteLine(person1.FriendsNames());
            Console.WriteLine(person2.FriendsNames());
            Console.WriteLine(person3.FriendsNames());
            #endregion
            Line();
            #region DateTime
            DateTimeOffset dateTimeUtc = DateTimeOffset.UtcNow;
            Console.WriteLine($"dateTimeUtc : {dateTimeUtc}");
            TimeSpan ts = new TimeSpan(3, 0, 0, 0);
            dateTimeUtc = dateTimeUtc.Add(ts);
            Console.WriteLine($"dateTimeUtc + 3days : {dateTimeUtc}");

            // extension method example
            DateTime dt = DateTime.Now;
            Console.WriteLine($"days until end of year : {dt.DaysUntilEndOfYear()}");

            #endregion        
            Line();



        }
    }
}
