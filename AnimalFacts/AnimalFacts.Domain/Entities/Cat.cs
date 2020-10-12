using System;


namespace AnimalFacts.Domain.Entities
{
    public class Cat
    {
        public int Id { get; set; }
        public DateTime AddedOn { get; set; }
        public string Fact { get; set; }
        public string Source { get; set; }
    }
}
