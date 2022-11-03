namespace DemoApp.Api.Controllers
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