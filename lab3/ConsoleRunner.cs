using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using iantonov.ContactService;
using iantonov.ContactService.Serializers;

namespace iantonov
{
    internal class ConsoleRunner
    {
        //private IContactService contactService = new SQLiteContactService("contacts.db");
        private IContactService contactService = new MemoryContactService();
        public static void Main()
        {
            ConsoleRunner runner = new ConsoleRunner();
            runner.Run();
        }
        private void Run()
        {
            Console.WriteLine("Enter the number of action and press [Enter]. Then follow instructions.");
            do
            {
                Console.WriteLine(@"
Menu:
1. View all contacts
2. Search
3. New contact
4. Exit
5. Save
6. Load");
                string action = PromptInput(">");
                switch (action)
                {
                    case "1":
                        ViewAllContacts(); break;
                    case "2":
                        Search(); break;
                    case "3":
                        NewContact(); break;
                    case "4":
                        return;
                    case "5":
                        Load(); break;
                    case "6":
                        Save(); break;
                }
            } while (true);
        }

        private static IContactServiceSerDes AskSerializer()
        {
            while (true)
            {
                string serializer = PromptInput(@"Select serializer:
1. Json
2. Xml
3. SQLite
>");
                string path = PromptInput("Input file path: ");
                switch (serializer)
                {
                    case "1": return new JSONSerDes(path);
                    case "2": return new XMLSerDes(path);
                    case "3": return new SQLiteSerDes(path);
                }
            }
        }

        private void Load()
        {
            IContactServiceSerDes serDes = AskSerializer();
            serDes.Serialize(contactService);
        }

        private void Save()
        {
            IContactServiceSerDes serDes = AskSerializer();
            contactService = serDes.Deserialize();
        }

        private static string PromptInput(string prompt)
        {
            Console.Write(prompt + " ");
            return Console.ReadLine()!;
        }
        private void ViewAllContacts()
        {
            PrintContacts(contactService.GetContacts().ToList());
        }
        private void Search()
        {
            Console.WriteLine("Search by");
            Array options = Enum.GetValues(typeof(ContactSearcher.SearchMode));
            for (int i = 0; i < options.Length; i++)
            {
                ContactSearcher.SearchMode option = (ContactSearcher.SearchMode)options.GetValue(i)!;
                string description = EnumDescription.EnumHelper.GetDescription(option);
                Console.WriteLine((i + 1) + ": " + description);
            }
            string mode = PromptInput(">");
            ContactSearcher.SearchMode selectedMode = (ContactSearcher.SearchMode)options.GetValue(int.Parse(mode) - 1)!;
            ContactSearcher searcher = new ContactSearcher(selectedMode);
            string query = PromptInput("Request:");
            Console.WriteLine("Searching...");
            PrintContacts(searcher.SearchContacts(contactService, query).ToList());
        }

        private static void PrintContacts(List<Contact> foundContacts)
        {
            Console.WriteLine("Results (" + foundContacts.Count + "):");
            for (int i = 0; i < foundContacts.Count; i++)
            {
                Contact contact = foundContacts[i];
                Console.WriteLine("#" + (i + 1) + " " + contact.ToString());
            }
        }

        private void NewContact()
        {
            Console.WriteLine("New contact");
            this.contactService.AddContact(new Contact
            {
                Name= PromptInput("Name:"),
                Surname = PromptInput("Surname:"),
                PhoneNumber = PromptInput("Phone:"),
                Email = PromptInput("E-Mail:")
            });
        }
    }
}
