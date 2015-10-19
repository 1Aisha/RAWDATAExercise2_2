namespace Exercise_2_2_2
{
    public class MovieInfo
    {
        public string Type { get; set; }
        public string Info { get; set; }

        public override string ToString()
        {
            return string.Format("[{0} = {1}]", Type, Info);
        }
    }
}