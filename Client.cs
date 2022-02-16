using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HandsOnProject
{
    public class Client
    {

        public String ClientName { get; set; }
        public long ClientPhNo { get; set; }

        public Client(String name , long No)
        {
            ClientName = name;
            ClientPhNo = No;
        }
        

    }

    public class ClientRegister
    {
        public bool PhoneNumberValidation(string num)
        {
            string text = num;

            if (!Regex.Match(text, @"^[0-9]{10}$").Success)
            {
                //Console.WriteLine("Invalid phone number");
                return false;
            }
            else
            {
                //Console.WriteLine("valid Phone number");
                return true;    
            }
        }


    }

    public class ContactBookInClient
    {
        public List<Client> ContactBook = new List<Client>();
        server sr = new server();
        public void AddToContactBook(string n, long phno)
        {
            string num = phno.ToString();
            ClientRegister cr = new ClientRegister();
            if (cr.PhoneNumberValidation(num))
            {

                Client cb1 = new Client(n, phno);
                if (!sr.CheckExistingUserOrNot(cb1, ContactBook))
                    sr.clients.Add(cb1);
                    ContactBook.Add(cb1);
            }
        }

        public void DisplayContactBook()
        {
            foreach (var x in ContactBook)
            {
                Console.WriteLine(x.ClientName + " " + x.ClientPhNo);
            }
        }
    }

    public class Messages
    {
        List<string> Message = new List<string>();
        public  string MessageTosend(string msg)
        {
            Message.Add(msg);
            return msg;
        }

    }

}
