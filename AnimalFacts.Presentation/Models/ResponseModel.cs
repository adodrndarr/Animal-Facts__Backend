using System;


namespace AnimalFacts.Presentation.Models
{
    public class ResponseModel
    {
        public DateTime AddedOn { get; set; }
        public string Fact { get; set; }
        public string Source { get; set; }
    }
}