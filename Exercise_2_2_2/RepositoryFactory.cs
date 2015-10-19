using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;

namespace Exercise_2_2_2
{
    public class RepositoryFactory
    {

        public static RepositoryFactory Instance = new RepositoryFactory();

        private Repository _repository;


        private RepositoryFactory()
        {
            
        }

        public Repository Repository
        {
            get
            {
                if (_repository == null)
                {
                    var movies = GetMovies();
                    var persons = GetPersons();

                    _repository = new Repository(movies, persons);

                    AddCastings(_repository);
                    AddMovieInfo(_repository);
                }
                return _repository;
            }
        }


        private List<Movie> GetMovies()
        {
            var movies = new List<Movie>();
            using (var reader = new StreamReader("data/movie.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var data = CsvParser.ParseLine(reader.ReadLine());
                    movies.Add(new Movie
                    {
                        Id = int.Parse(data[0]),
                        Title = data[1],
                        Year = int.Parse(data[2])
                    });
                }
            }
            return movies;
        }

        private List<Person> GetPersons()
        {
            var persons = new List<Person>();
            using (var reader = new StreamReader("data/person.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var data = CsvParser.ParseLine(reader.ReadLine());
                    persons.Add(new Person
                    {
                        Id = int.Parse(data[0]),
                        Name = data[1],
                        Gender = data[2] == "m" ? Person.GenderType.Male : Person.GenderType.Female
                    });
                }
            }
            return persons;
        }

        private void AddCastings(Repository repository)
        {
            using (var reader = new StreamReader("data/cast.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var data = CsvParser.ParseLine(reader.ReadLine());
                    repository.AddCasting(int.Parse(data[0]), int.Parse(data[1]), data[2]);
                }
            }
        }

        private void AddMovieInfo(Repository repository)
        {
            using (var reader = new StreamReader("data/movieinfo.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var data = CsvParser.ParseLine(reader.ReadLine());
                    repository.AddMovieInfo(int.Parse(data[0]), data[1], data[2]);
                }
            }
        }
    }
}