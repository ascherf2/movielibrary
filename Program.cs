using System;
using System.IO;

namespace MovieLibrary
{
    class Program
    {
        public static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";

            // create instance of Logger
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();

            //start logging
            logger.Info("Test");

            // creating variables

            FileManager fileManager = new FileManager();

            //initiate stream reader

            try
            {
                Console.WriteLine("Hello, how can I help?");
                Console.WriteLine("Please enter 1 for Movie library:");
                //Display library in a pleasing fashion
                Console.WriteLine("Please enter 2 to add to Movie library");
                //Add to not write over 
                Console.WriteLine("Please enter any other key to exit.");

                //readline here, convert toint32
                var userInput = Console.ReadLine();

                do
                {
                    if (userInput == "1")
                    {
                        // List Movies
                        fileManager.Read();
                    }
                    else if (userInput == "2")
                    {
                        // Add Movie
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                //after every new entry movie id = new movie id ++
                //dont give option to enter movie ID, self assigned by program
                //menu example: "Please add data to Movie ID 00000:"

                //option 1 read through library and display 

            }
            catch (Exception e)
            {
                Console.WriteLine("Please try again, error:");
                Console.WriteLine(e.Message);
            }
            //     //exit/ close file
            //     //Unit testing
            //     //Git uploads
        }
    }
}
