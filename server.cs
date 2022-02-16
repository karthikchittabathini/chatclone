using System;
using System.Collections.Generic;
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
    public class server
    {
        //list that contains the customers details(All Data)

        public List<Client> clients = new List<Client>();

        public List<Message> MessagesList = new List<Message>();

        #region methods
        //checking UserExistingorNot in current clients list
        public bool CheckExistingUserOrNot(Client client)
        {
            foreach (var x in clients)
            {
                if (x.ClientPhNo == client.ClientPhNo || x.ClientName == client.ClientName)
                {
                    return true;
                }
            }
            return false;
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
}
