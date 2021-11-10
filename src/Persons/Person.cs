using System;

namespace Persons
{
    public abstract class Person
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}

        public Person(string lastName, string firstName = "")
        {
            this.LastName = lastName;
            this.FirstName = firstName;
        }
    }
}
