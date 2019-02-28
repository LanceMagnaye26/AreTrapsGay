using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models

{
    public class TrapItem
    {
        public int Id { get; set; }
        public string TrapType { get; set; }

        [DataType(DataType.Date)]
        public DateTime Timestamp { get; set; }
        public string Location { get; set; }
        public decimal AmountOfBait { get; set; }
    }
}