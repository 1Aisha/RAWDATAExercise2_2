using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercise_2_2_2
{
    public class Imdb
    {

        private Repository _repository;

        public Imdb(Repository repository)
        {
            _repository = repository;
        }

        public event EventHandler<Person> NewPersonEvent;

        public IEnumerable<Movie> Movies { get { return _repository.Movies; }  }
        public IEnumerable<Person> Persons { get { return _repository.Persons; } }

        public IEnumerable<Casting> Castings { get { return _repository.Castings; } }

        public Movie FindMovie(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }

        public void AddPerson(Person person)
        {
            _repository.AddPerson(person);
            OnNewPersonEvent(person);
        }

        protected virtual void OnNewPersonEvent(Person person)
        {
            if(NewPersonEvent != null)
                NewPersonEvent.Invoke(this, person);
        }
    }
}