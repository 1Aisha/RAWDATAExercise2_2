using System.Collections.Generic;

namespace Exercise_2_2_2
{
    public interface IRepository
    {
        IEnumerable<Movie> Movies { get; }
        IEnumerable<Person> Persons { get; }

        IEnumerable<Casting> Castings { get; }

        void AddPerson(Person person);
    }
}