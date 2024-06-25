namespace CityDirectory
{
    public class Enterprise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Address} - {Phone}";
        }
    }
}
