using System;
using System.Collections.Generic;
using System.IO;

namespace ContactManager
{
    class Program
    {
        static List<Contact> contacts = new List<Contact>();
        static string defaultFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ContactManager");
        static string defaultFilePath = Path.Combine(defaultFolderPath, "contacts.xml");

        static void Main(string[] args)
        {
            // Ensure the default folder exists
            if (!Directory.Exists(defaultFolderPath))
            {
                Directory.CreateDirectory(defaultFolderPath);
            }

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("_____________________________");
                Console.WriteLine("Contact Manager");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View Contacts");
                Console.WriteLine("3. Export Contacts to XML");
                Console.WriteLine("4. Import Contacts from XML");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();


                Console.WriteLine();
                Console.WriteLine();
                switch (option)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        ViewContacts();
                        break;
                    case "3":
                        ExportContacts();
                        break;
                    case "4":
                        ImportContacts();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void AddContact()
        {
            Contact contact = new Contact();
            Console.Write("Enter name: ");
            contact.Name = Console.ReadLine();
            Console.Write("Enter phone number: ");
            contact.PhoneNumber = Console.ReadLine();
            Console.Write("Enter email: ");
            contact.Email = Console.ReadLine();
            contacts.Add(contact);
        }

        static void ViewContacts()
        {
            if (contacts.Count > 0)
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact);
                }
            }
            else
            {
                Console.WriteLine("No contacts");
            }
        }

        static void ExportContacts()
        {
            Console.Write($"Enter the file path to export (default: {defaultFilePath}): ");
            string filePath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = defaultFilePath;
            }
            XmlHelper.ExportToXml(contacts, filePath);
            Console.WriteLine($"Contacts exported successfully to {filePath}.");
        }

        static void ImportContacts()
        {
            Console.Write($"Enter the file path to import (default: {defaultFilePath}): ");
            string filePath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = defaultFilePath;
            }
            contacts.AddRange(XmlHelper.ImportFromXml(filePath));
            Console.WriteLine($"Contacts imported successfully from {filePath}.");
        }
    }
}
