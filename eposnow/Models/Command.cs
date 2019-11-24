using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eposnow.Models
{
    public enum CommandStatusEnum { STARTED=1, DONE= 2 };

    public class Command
    {
        public int id { get; set; }
        public string name { get; set; }

        public int customers { get; set; }

        public Table table { get; set; }

        public List<Product> products { get; set; } = new List<Product>();

        public CommandStatusEnum status = new CommandStatusEnum();

    }
}