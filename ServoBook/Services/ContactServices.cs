using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using ContactBook.Services;

namespace ContactBook.Services 
{
    class ContactServices    
    {
        public List<Contact> Contacts { get; set; } = new List<Contact>();


        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        private void DisplayContactDetails(Contact contact)
        {
            Console.WriteLine($" Imię i nazwisko: {contact.firstName} { contact.lastName}");
            Console.WriteLine($" Numer telefonu: {contact.phoneNumber}");
            Console.WriteLine($" E-mail: {contact.email}");
            Console.WriteLine($" Data urodzenia: {contact.birthday}");
            Console.WriteLine("------------------------------------------------------------");
            
            // Console.WriteLine($"Conttact: { contact.firstName} { contact.lastName} {contact.phoneNumber} {contact.email} {contact.birthday.Day}./{contact.birthday.Month}.{contact.birthday.Year}");
        }
        private void ContactNotFound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nie znaleziono kontaktu.");
            Console.ResetColor();
        }
        public void SearchContact(string searchPhrase)
        {
             List<Contact> C  = new List<Contact>();

             if(searchPhrase == null)
             {
                Console.WriteLine("Nie podano wartości");
             }
             else
             {
                for (int i = 0; i < Contacts.Count; i++)
                {
                    Contact contact = Contacts[i];
                    if (contact.firstName.Contains(searchPhrase) || contact.lastName.Contains(searchPhrase) || contact.phoneNumber.Contains(searchPhrase) || contact.email.Contains(searchPhrase) || contact.birthday.ToString().Contains(searchPhrase))
                        C.Add(Contacts[i]);
                } 
            }
            foreach (var contact in C)
            {
               DisplayContactDetails(contact);
            }


        }

        public void DisplayAllContact(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                DisplayContactDetails(contact);
            }
        }

       

        public void RemoveContact(string firstName, string lastName)
        {
            if (firstName == null || lastName == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nie podano wszystkich wartości!");
                Console.ResetColor();
            }
            else
            {
                for (int i = 0; i < Contacts.Count; i++)
                {
                    Contact contact = Contacts[i];
                    if (contact.firstName == firstName && contact.lastName == lastName)
                        Contacts.Remove(contact);
                }
            }


        }
        public void EditContact(string firstName, string lastName)
        {
            string tmpFirstname;
            string tmpLastname;
            string tmpPhoneNumber;
            string tmpEmail;
            DateTime tmpBirthday = DateTime.Today;
            DateTime tmpBirthday2 = DateTime.Today;

            
            if (firstName.Equals("") || lastName.Equals(""))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nie podano wszystkich wartości!");
                Console.ResetColor();
            }
            else
            {
                for (int i = 0; i < Contacts.Count; i++)
                {
                    Contact contact = Contacts[i];
                    if (contact.firstName == firstName && contact.lastName == lastName)
                    {
                        Console.WriteLine("Wprowadź nowe imię:");
                        tmpFirstname = Console.ReadLine();
                        Console.WriteLine("Wprowadź nowe nazwisko:");
                        tmpLastname = Console.ReadLine();
                        Console.WriteLine("Wprowadź nowy e-mail:");
                        tmpEmail = Console.ReadLine();
                        Console.WriteLine("Wprowadź nowy numer telefonu:");
                        tmpPhoneNumber = Console.ReadLine();
                        Console.WriteLine("Wprowadź nową datę urodzin:");
                        tmpBirthday2 = contact.birthday;
                        try
                        {
                            tmpBirthday = DateTime.Parse(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            tmpBirthday = contact.birthday;
                            contact.birthday = tmpBirthday;
                            
                        }
 

                        if (tmpFirstname.Length == 0) tmpFirstname = contact.firstName;
                        if (tmpLastname.Length == 0) tmpLastname = contact.lastName;
                        if (tmpEmail.Length == 0) tmpEmail = contact.email;
                        if (tmpPhoneNumber.Length == 0) tmpPhoneNumber = contact.phoneNumber;
                        if (tmpBirthday ==  null) tmpBirthday = tmpBirthday2;

                        Contacts.Remove(contact);
                       
                        Contact contact1 = new Contact();
                        contact1.firstName = tmpFirstname;
                        contact1.lastName = tmpLastname;
                        contact1.email = tmpEmail;
                        contact1.phoneNumber = tmpPhoneNumber;
                        contact1.birthday = tmpBirthday;

                        AddContact(contact1);
                        
                    }
                   



                }
            }

        }
        public void DisplayNotification()
        {
            DateTime dateTime = DateTime.Today;
            DateTime dateTimePlusOne = dateTime.AddDays(1);
            DateTime dateTimePlusTwo = dateTime.AddDays(2);
            DateTime dateTimePlusThree = dateTime.AddDays(3);
            DateTime dateTimePlusFour = dateTime.AddDays(4);
            DateTime dateTimePlusFive = dateTime.AddDays(5);
            DateTime dateTimePlusSix = dateTime.AddDays(6);
            DateTime dateTimePlusSeven = dateTime.AddDays(7);

            List<Contact> tmpContacts = new List<Contact>();
            for (int i = 0; i < Contacts.Count; i++)
            {
                var contact = Contacts[i];
                if((contact.birthday.Day == dateTimePlusOne.Day && contact.birthday.Month == dateTimePlusOne.Month)||(contact.birthday.Day == dateTimePlusTwo.Day && contact.birthday.Month == dateTimePlusTwo.Month)||(contact.birthday.Day == dateTimePlusThree.Day && contact.birthday.Month == dateTimePlusThree.Month)||(contact.birthday.Day == dateTimePlusFour.Day && contact.birthday.Month == dateTimePlusFour.Month)||(contact.birthday.Day == dateTimePlusFive.Day && contact.birthday.Month == dateTimePlusFive.Month)||(contact.birthday.Day == dateTimePlusSix.Day && contact.birthday.Month == dateTimePlusSix.Month)||(contact.birthday.Day == dateTimePlusSeven.Day && contact.birthday.Month == dateTimePlusSeven.Month)||(contact.birthday.Day == dateTime.Day && contact.birthday.Month == dateTime.Month))
                    tmpContacts.Add(contact);
            }
            if (tmpContacts == null)
            {
                ContactNotFound();
            }
            else
            {
                DisplayAllContact(tmpContacts);
            }

            

        }
        
       
       
    }
}
