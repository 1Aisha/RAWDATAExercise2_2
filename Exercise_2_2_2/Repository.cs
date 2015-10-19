using System.Collections.Generic;
using System.Linq;

namespace Exercise_2_2_2
{
    public class Repository : IRepository
    {
        private readonly Dictionary<int, Movie> _movies = new Dictionary<int, Movie>();
        private readonly Dictionary<int, Person> _persons = new Dictionary<int, Person>();
        private readonly List<Casting> _castings = new List<Casting>();
        
        public Repository(List<Movie> movies, List<Person> persons)
        {
            foreach (var movie in movies)
            {
                _movies[movie.Id] = movie;
            }

            foreach (var person in persons)
            {
                _persons[person.Id] = person;
            }
        }

        public void AddCasting(int movieId, int personId, string role)
        {
            Movie movie = null;
            Person person = null;
            _movies.TryGetValue(movieId, out movie);
            _persons.TryGetValue(personId, out person);
            if(movie != null && person != null)
                _castings.Add(new Casting{ Movie = movie, Person = person, Role = role });
        }

        public void AddMovieInfo(int movieId, string type, string info)
        {
            Movie movie = null;
            _movies.TryGetValue(movieId, out movie);
            if (movie != null)
            {
                if (movie.Info == null)
                {
                    movie.Info = new List<MovieInfo>();
                }
                movie.Info.Add(new MovieInfo {Type = type, Info = info});
            }
        }

        public IEnumerable<Movie> Movies { get { return _movies.Values; } }
        public IEnumerable<Person> Persons { get { return _persons.Values; } }
        public IEnumerable<Casting> Castings { get { return _castings;} }

        public void AddPerson(Person person)
        {
            int maxId = _persons.Values.Max(x => x.Id);
            _persons[maxId + 1] = person;
            person.Id = maxId + 1;
        }
    }
}