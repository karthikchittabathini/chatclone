using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnProject
{
    public class ProgramServer
    {
        static void Main(string[] args)
        {

            //client register class(that contains phoneNumberValidation method)
            ClientRegister cr = new ClientRegister();
            //client class
            ContactBookInClient cbic = new ContactBookInClient();
            //Messages class in client class
            Messages msg = new Messages();


            //client 1 details and reading stuff from the console
            string name1 = Console.ReadLine();
            long phno1 = Convert.ToInt64(Console.ReadLine());
            string phnoStr1 = phno1.ToString();
            Client c1 = new Client(name1, phno1);
            Console.WriteLine(cr.PhoneNumberValidation(phnoStr1) ? "Valid phone number" : " Invalid phone number");

            //client 2 details and reading stuff from the console
            string name2 = Console.ReadLine();
            long phno2 = Convert.ToInt64(Console.ReadLine());
            string phnoStr2 = phno2.ToString();
            Client c2 = new Client(name2, phno2);
            Console.WriteLine(cr.PhoneNumberValidation(phnoStr2) ? "Valid phone number" : " Invalid phone number");


            server srvr = new server();

            //checking if user entered was already present or not in the main list(client list in server class)
            if (srvr.CheckExistingUserOrNot(c1, srvr.clients))
            {
                Console.WriteLine("Already a registered user");
            }
            else
            {
                srvr.clients.Add(c1);
            }

            if (srvr.CheckExistingUserOrNot(c2, srvr.clients))
            {
                Console.WriteLine("Already a registered user");
            }
            else
            {
                srvr.clients.Add(c2);
            }


            //displaying the contents of the list
            srvr.DisplayUsersDetails();

            Console.WriteLine("1 - Add contact to the ContactsBook");
            Console.WriteLine("2 - Message to a contact");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":  
                    Console.WriteLine("please enter the name of the contact");
                    String name = Console.ReadLine();
                    Console.WriteLine("please enter the number of the contact");
                    long phoneno = Convert.ToInt64(Console.ReadLine());
                    cbic.AddToContactBook(name, phoneno);
                    cbic.DisplayContactBook();
                    break;

                case "2":
                    cbic.DisplayContactBook();
                    Console.WriteLine("Please select a contact name you want to chat with");
                    // Sender name , Time , date
                    string NameToMsg = Console.ReadLine();
                    foreach (var x in cbic.ContactBook)
                    {
                        if(x.ClientName == NameToMsg)
                        {
                            string messge = Console.ReadLine();
                            string info = msg.MessageTosend(messge);

                        }
                        else
                        {

                            Console.Write("Incorrect contact name !");
                        }
                    }
                    
                    break;
                          
            }




            Console.Read();

        }



        



        


    }
}
