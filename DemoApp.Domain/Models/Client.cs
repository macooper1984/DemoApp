namespace DemoApp.Domain.Models
{
    public class Client
    {
        public Client(string identifier, string name)
        {
            Identifier = identifier;
            Name = name;
        }

        public string Identifier { get; set; }

        public string Name { get; set; }
    }
}