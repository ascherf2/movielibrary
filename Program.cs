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

                //after every new entry movie id = new movie id ++
                //dont give option to enter movie ID, self assigned by program
                //menu example: "Please add data to Movie ID 00000:"

                //option 1 read through library and display 
                using (StreamReader sr = new StreamReader("movies.csv"))
                {
                    string line;
                
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
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
