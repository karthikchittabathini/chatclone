using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnProject
{
    public class Message
    {
        #region GettersSetters

        public String msg { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }

        public DateTime dt { get; set; }
        #endregion

        #region constructors
        public Message(String m, string s, string r)
        {
            msg = m;
            sender = s;
            receiver = r;
            dt = DateTime.Now;
        }
        #endregion

    }
    public class FilesDataBase
    {
        public string clientdatabasepath = $"E:\\clientsDatabase.txt";
    }
    public class server
    {
        FilesDataBase fd = new FilesDataBase();
        //list that contains the customers details(All Data)

        public List<Client> clients = new List<Client>();

        public List<Message> MessagesList = new List<Message>();

        #region methods
        //checking UserExistingorNot in current clients list
        public bool CheckExistingUserOrNot(Client client)
        {
            using (StreamReader sr = File.OpenText(fd.clientdatabasepath))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    string[] splitter = s.Split(',');
                    if (splitter[1] == client.ClientPhNo.ToString() || splitter[0] == client.ClientName)
                    {
                        return true;
                    }
                    Array.Clear(splitter, 0, splitter.Length);
                }
                return false;
            }
        }


        //To delete a existing user
        public void DeleteExistingUser()
        {
            Console.WriteLine("please enter Registered user name : ");
            String name = Console.ReadLine();
            Console.WriteLine("Enter the registered Phone Number");
            long phno = Convert.ToInt64(Console.ReadLine());
            Client cl = new Client(name, phno);
            foreach (var x in clients.ToArray())
            {
                if (x.ClientPhNo == cl.ClientPhNo && x.ClientName == cl.ClientName)
                {
                    clients.Remove(x);
                }
            }
        }



        public void DisplayUsersDetails()
        {
            //print the list of clients
            foreach (var x in clients)
            {
                Console.WriteLine(x.ClientName + " " + x.ClientPhNo);
            }
        }
        #endregion
    }

    public class Messaging
    {
        public void MessagingFunctionality(string sender, string receiver, string message)
        {
            string path = $"E:\\{receiver}.txt";
            if (File.Exists(path))
            {
                //Console.WriteLine("you are inside");
                string receiverpath = $"E:\\{receiver}messages.txt";
                string senderpath = $"E:\\{sender}messages.txt";
                string mesg = $"{message}\n";
                File.AppendAllText(receiverpath, mesg);
                File.AppendAllText(senderpath, mesg);
            }
        }

        public void ViewMessages()
        {
            string currentactiveuser = $"E:\\{ProgramServer.active_user}messages.txt";
            using (StreamReader sr = File.OpenText(currentactiveuser))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
