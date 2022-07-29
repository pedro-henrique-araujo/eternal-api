namespace Eternal.Models
{
    public class Dependent
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int ClientId { get; set; }

        public Client? Client { get; set; }
    }
}
