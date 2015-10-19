using System.Collections.Generic;
using System.Linq;

namespace Exercise_2_2_2
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public List<MovieInfo> Info { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}\nTitle: {1}\nYear: {2}\nInfo:\n{3}",
                Id, Title, Year, string.Join("\n", Info));
        }
    }
}