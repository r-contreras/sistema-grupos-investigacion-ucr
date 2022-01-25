using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchRepository.Presentation.ResearchProjects.Models
{

    public class JsonFormat
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public Persons[]? Persons { get; set; } = null!;
        public Theses[]? Theses { get; set; } = null!;
        public Publications[]? Publications { get; set; } = null!;
    }
    public class Persons
    {
        public string Email { get; set; }
        public string Role { get; set; }
    }


    public class Theses
    {
        public string name { get; set; }
    }
    public class Publications
    {
        public string PublicationID { get; set; }
    }
}
