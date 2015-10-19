using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise_2_2_2.tests;

namespace Exercise_2_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var imdb = new Imdb(RepositoryFactory.Instance.Repository);

            imdb.NewPersonEvent += (sender, person) => Console.WriteLine("New person added: {0}", person);

            imdb.AddPerson(new Person { Name = "Henrik", Gender = Person.GenderType.Male });

            Console.WriteLine("Name of first 5 persons:");

            foreach (var p in imdb.Persons.Take(5))
            {
                Console.WriteLine(p.Name);
            }

            var counting = from movie in imdb.Movies
                group movie by movie.Year
                into c
                orderby c.Count() descending 
                select new {Key = c.Key, Count = c.Count()};

            // Alternative                      Key          Elements 
            var counting2 = imdb.Movies.GroupBy(x => x.Year, x => x)
                                       .Select(x => new { Key = x.Key, Count = x.Count()})
                                       .OrderByDescending(x => x.Count);

                            

            foreach (var gr in counting)
            {
                Console.WriteLine("{0}: {1}", gr.Key, gr.Count);
            }



        }

        
    }
}
