using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnProject
{
    public class server
    {
        //list that contains the customers details(All Data)

        public List<Client> clients = new List<Client>();
        


        //checking UserExistingorNot in current clients list
        public bool CheckExistingUserOrNot(Client client, List<Client> lst)
        {
            foreach (var x in lst)
            {
                if (x.ClientPhNo == client.ClientPhNo && x.ClientName == client.ClientName)
                {
                    return true;
                }
            }
            return false;
        }

        public void DisplayUsersDetails()
        {
            //print the list of clients
            foreach (var x in clients)
            {
                Console.WriteLine(x.ClientName + " " + x.ClientPhNo);
            }
        }

        public void MessageServiceFromSenderToReceiver(string msg, string clientname)
        {

        }


    }
}
