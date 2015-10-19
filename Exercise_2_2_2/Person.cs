namespace Exercise_2_2_2
{
    public class Person
    {
        public enum GenderType
        {
            Male,
            Female
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public GenderType Gender { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Gender: {2}", Id, Name, Gender);
        }
    }
}