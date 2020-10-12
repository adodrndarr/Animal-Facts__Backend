using System;


namespace AnimalFacts.Presentation.Models
{
    public class RequestModel
    {
        public DateTime AddedOn { get; set; }
        public string Fact { get; set; }
        public string Source { get; set; }
    }
}