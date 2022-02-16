/* CH.Karthik*/﻿
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
        #region gettersetters/accessors
        public String ClientName { get; set; }
        public long ClientPhNo { get; set; }
        #endregion

        #region client constructor
        public Client(String name, long No)
        {
            ClientName = name;
            ClientPhNo = No;
        }
        #endregion

    }

    public class ClientRegister
    {
        #region methods
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
        #endregion

    }


    public class message
    {
        
        server sr = new server();
        #region methods
        public void Messaging()
        {
            
            Console.WriteLine("Please enter the UserName of the person you want to send message");
            string name = Console.ReadLine();
            foreach (var x in sr.clients)
            {
                if (x.ClientName == name)
                {
                    Console.WriteLine("Enter the message you want to send");
                    string msg = Console.ReadLine();
                    Message m = new Message(msg, ProgramServer.active_user , name);
                    sr.MessagesList.Add(m);

                }
                else
                {
                    Console.WriteLine("There is no user with the name you entered");
                }
            }
        }
        #endregion methods

    }


    public class ContactBookInClient
    {
        public List<Client> ContactBook = new List<Client>();
        server sr = new server();
        #region methods
        public void AddToContactBook(string n, long phno)
            {
                string num = phno.ToString();
                ClientRegister cr = new ClientRegister();
                if (cr.PhoneNumberValidation(num))
                {

                    Client cb1 = new Client(n, phno);
                    if (!sr.CheckExistingUserOrNot(cb1))
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

        #endregion
    }


}



