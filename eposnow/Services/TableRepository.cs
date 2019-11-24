using eposnow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eposnow.Services
{
    public class TableRepository
    {
        private List<Table> tables = new List<Table>();

        public List<Table> getTables()
        {
            for (int i = 1; i <= 5; i++)
            {
                Table table = new Table
                {
                    id = i,
                    name = "Table " + i,
                };

                this.tables.Add(table);
            }

            return this.tables;
        }
    }
}