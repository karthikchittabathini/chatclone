using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HandsOnProject
{
    public class ProgramServer
    {
        //server intilazation
        public static server srvr = new server();
        //client register class 
        public static ClientRegister cr = new ClientRegister();

        public static ContactBookInClient cbic = new ContactBookInClient();
        public static string active_user;
        //Main Method
        static void Main(string[] args)
        {

        #region switch case
            bool itereate = true;

            while (itereate)
            {
                Console.WriteLine("1 - New User - Create Your Account");
                Console.WriteLine("2 - Already Registered User - Login");
                Console.WriteLine("3 - Add contact to the ContactsBook");
                Console.WriteLine("4 - Message");
                Console.WriteLine("5- Delete Your Existing Account");
                Console.WriteLine("6 - Exit");


                Console.WriteLine("Please enter Your Option");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        NewUser();
                        break;

                    case "2":
                        GettingLoginCredentials();
                        break;


                    case "3":
                        
                        Console.WriteLine("please enter the name of the contact");
                        String name = Console.ReadLine();
                        Console.WriteLine("please enter the number of the contact");
                        long phoneno = Convert.ToInt64(Console.ReadLine());
                        cbic.AddToContactBook(name, phoneno);
                        cbic.DisplayContactBook();
                        break;
                        
                       

                    case "4":

                        break;

                    case "5":
                        srvr.DeleteExistingUser();
                        Console.WriteLine("User deleted from the server, You are no longer a member of our family byee....");
                        break;

                    case "6":
                        itereate = false;
                        break;


                    default:
                        Console.WriteLine("Invalid Option ! - Please enter a Valid Option : ");
                        break;

                }
                Console.WriteLine("Please press y to continue or press n to exit");
                string ans =  Console.ReadLine();
                itereate = ans == "y" ? true : false;
            }

            //displaying the contents of the list
            srvr.DisplayUsersDetails();
            Console.Read();
        }
        #endregion

        #region methods
        //Getting login Credentials
        static void GettingLoginCredentials()
        {
            Console.WriteLine("please enter Registered user name : ");
            String name = Console.ReadLine();
            active_user = name;
            Console.WriteLine("Enter the registered Phone Number");
            long phno = Convert.ToInt64(Console.ReadLine());
            Client c = new Client(name, phno);
            if(srvr.CheckExistingUserOrNot(c))
            {
                Console.WriteLine("Connecting..... ");
                Thread.Sleep(5000);
                Console.WriteLine("Login Successful");
                Console.WriteLine("Welcome "+name);
            }

        }


        //function to create a new user
        static void NewUser()
        {
            Console.WriteLine("please enter a user name you want: ");
            String name = Console.ReadLine();
            Console.WriteLine("Enter Your Phone Number");
            long phno = Convert.ToInt64(Console.ReadLine());
            Client newone = new Client(name, phno);
            if (srvr.CheckExistingUserOrNot(newone))
            {
                Console.WriteLine("Your are already a registered user please login or check your credentials and try again");
            }
            else
            {
                string number = phno.ToString();
                if(cr.PhoneNumberValidation(number))
                {
                    srvr.clients.Add(newone);
                }
                else
                {
                    Console.WriteLine("The phone number was incorrect please enter 10 digits valid phone number");
                }  
            }
            
        }
        #endregion
    }

}
