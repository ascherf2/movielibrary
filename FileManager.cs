using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class FileManager
    {
        List<UInt64> MovieIds { get; set; }
        List<string> MovieTitles { get; set; }
        List<string> MovieGenres { get; set; }

        private readonly string _file = "movies.csv";

        // default constructor
        public FileManager()
        {
            MovieIds = new List<UInt64>();
            MovieTitles = new List<string>();
            MovieGenres = new List<string>();

            Parse();
        }

        private void Parse()
        {
            // create instance of Logger
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();

            try
            {
                StreamReader sr = new StreamReader(_file);
                // first line contains column headers
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    // first look for quote(") in string
                    // this indicates a comma(,) in movie title
                    int idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        // no quote = no comma in movie title
                        // movie details are separated with comma(,)
                        string[] movieDetails = line.Split(',');
                        // 1st array element contains movie id
                        MovieIds.Add(UInt64.Parse(movieDetails[0]));
                        // 2nd array element contains movie title
                        MovieTitles.Add(movieDetails[1]);
                        // 3rd array element contains movie genre(s)
                        // replace "|" with ", "
                        MovieGenres.Add(movieDetails[2].Replace("|", ", "));
                    }
                    else
                    {
                        // quote = comma in movie title
                        // extract the movieId
                        MovieIds.Add(UInt64.Parse(line.Substring(0, idx - 1)));
                        // remove movieId and first quote from string
                        line = line.Substring(idx + 1);
                        // find the next quote
                        idx = line.IndexOf('"');
                        // extract the movieTitle
                        MovieTitles.Add(line.Substring(0, idx));
                        // remove title and last comma from the string
                        line = line.Substring(idx + 2);
                        // replace the "|" with ", "
                        MovieGenres.Add(line.Replace("|", ", "));
                    }
                }
                // close file when done
                sr.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        public void Read()
        {
            // Display All Movies
            // loop thru Movie Lists

            Console.WriteLine("How many movies do you want to display?");
            var userDisplayChoice = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < userDisplayChoice; i++)
            {
                // display movie details
                Console.WriteLine($"Id: {MovieIds[i]}");
                Console.WriteLine($"Title: {MovieTitles[i]}");
                Console.WriteLine($"Genre(s): {MovieGenres[i]}");
                Console.WriteLine();
            }
        }
    }
}
