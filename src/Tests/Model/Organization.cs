namespace Tests.model
{
    public class Organization
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public User DefaultAdmin { get; set; }

        public string Code { get; set; }
    }
}