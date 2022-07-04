using System;
using System.Collections.Generic;
using System.Globalization;
using ContactBook.Services;
using ContactBook;

namespace ContactBook
{
    internal class ContactBook
    {
        static void Main(String[] args ) 
        {
            
            void Menu()
            {
                Console.WriteLine("Kontakty");
                Console.WriteLine("============================================================");
                Console.WriteLine("Wybierz Operacje:");
                Console.WriteLine("1. Wyświetl listę kontaktów.");
                Console.WriteLine("2. Dodaj kontakt.");
                Console.WriteLine("3. Usuń kontakt.");
                Console.WriteLine("4. Edytuj kontakt.");
                Console.WriteLine("5. Zobacz powiadomienia.");
                Console.WriteLine("6. Wyszukaj.");
                Console.WriteLine("0. Wyjście.");
            }
            Menu();
            List<Contact> list = new List<Contact>();
            var userInput = Console.ReadLine();
            ContactServices contact = new ContactServices();
            var contactJson = new ContactJson();
            contactJson.DeserializeListToJsonFile();
            contact.Contacts = contactJson.c;
            
           
          

            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Lista kontaktow:");
                        Console.WriteLine("============================================================");
                        contact.DisplayAllContact(contact.Contacts);
                        if(contact.Contacts.Count == 0)
                            {
                                 contact.MessageError("Lista obecnie jest pusta!");
                            }
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("Dodaj:");
                        Console.WriteLine("============================================================");
                        string firstName;
                        var newContact = new Contact();
                        bool isFirstName = false;
                        while(isFirstName != true)
                        {
                            Console.WriteLine("Wprowadź imię:");
                            firstName = Console.ReadLine();
                            if (firstName.Length == 0)
                            {
                                isFirstName = false;
                                contact.MessageError("Wprowadzono niepoprawną wartość!");
                                
                            }
                            else
                            {
                                isFirstName = true;
                                newContact.firstName = firstName;
                            }
                        }

                        string lastName;
                        bool isLastName = false;
                        while (isLastName != true)
                        {
                            Console.WriteLine("Wprowadź nazwisko:");
                            lastName = Console.ReadLine();
                            if (lastName.Length == 0)
                            {
                                isLastName = false;
                                contact.MessageError("Wprowadzono niepoprawną wartość!");
                            }
                            else
                            {
                                isLastName = true;
                                newContact.lastName = lastName;
                            }
                        }


                        string email;
                        bool isEmail = false;
                        while (isEmail != true)
                        {
                            Console.WriteLine("Wprowadź email:");
                            email = Console.ReadLine();
                            if (email.Length == 0)
                            {
                                isEmail = false;
                                contact.MessageError("Wprowadzono niepoprawną wartość!");
                            }
                            else
                            {
                                isEmail = true;
                                newContact.email = email;
                            }
                        }

                        

                       
                        bool isPhoneNumber = false;
                        while (isPhoneNumber != true) 
                        {
                            Console.WriteLine("Wprowadź numer telefonu:");
                            
                            var phoneNumber = Console.ReadLine();
                            bool tmpphone = int.TryParse(phoneNumber, out int intFhoneNumber);
                            phoneNumber = intFhoneNumber.ToString();

                            if(phoneNumber.Length != 9)
                            {
                                isPhoneNumber = false;
                                contact.MessageError("Wprowadzono niepoprawną wartość!");
                            }
                            else
                            {
                                isPhoneNumber = true;
                                newContact.phoneNumber = phoneNumber;
                            }
                            
                        }
                        string s;
                        bool isBirthday = false;
                        while (isBirthday != true)
                        {
                            Console.WriteLine("Wprowadz datę urodzin:");
                            Console.WriteLine("Prawidłowy format to \"dd.MM.yyyy\"");
                            s = Console.ReadLine();
                           
                            isBirthday = DateTime.TryParseExact(s, "dd.MM.yyyy", null,DateTimeStyles.None, out DateTime vdate);

                            if (isBirthday == true)
                                newContact.birthday = vdate;
                            else
                            {
                                isBirthday = false;
                                contact.MessageError("Wprowadzono niepoprawną wartość!");
                            }
                            

                        } ;



                        contact.AddContact(newContact);
                        break;
                    case "3":
                        Console.WriteLine();
                        Console.WriteLine("Usuwanie:");
                        Console.WriteLine("============================================================");
                        Console.WriteLine("Podaj imię:");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko:");
                        lastName = Console.ReadLine();

                        contact.RemoveContact(firstName, lastName);

                        break;
                    case "4":
                        Console.WriteLine();
                        Console.WriteLine("Edycja:");
                        Console.WriteLine("============================================================");
                        Console.WriteLine("Podaj imię:");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko:");
                        lastName= Console.ReadLine();
                        Console.WriteLine();

                        contact.EditContact(firstName, lastName);
                        break;
                    case "5":
                        Console.WriteLine();
                        Console.WriteLine("Powiadomienia:");
                        Console.WriteLine("============================================================");

                        contact.DisplayNotification();

                        break;
                    case "6":
                        Console.WriteLine();
                        Console.WriteLine("Wyszukaj:");
                        Console.WriteLine("============================================================");
                        var phrase = Console.ReadLine();
                        contact.SearchContact(phrase);
                        break;
                    case "0":
                        
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Niepoprawna instrukcja!");
                        Console.ResetColor(); 
                        break;
                }
                contactJson.SerializeListToJsonFile(contact.Contacts);
                Menu();
                Console.WriteLine("Wybierz operacje:");
                userInput = Console.ReadLine();
               
            }

            
           
            
           

        }
    }
}
