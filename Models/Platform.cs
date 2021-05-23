using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace GraphQueryTest.Models
{
    [GraphQLDescription("Represents any software or service that has commandline interface")]
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [GraphQLDescription("Represents any a purchase, valid license for the platfor")]
        public string LicenseKey { get; set; }

        public ICollection<Command> Commands { get; set; } =new List<Command>();
    }
}