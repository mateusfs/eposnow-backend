using eposnow.Models;

using System;
using System.Linq;
using System.Web.Http;
using System.Collections.Generic;
using eposnow.Services;

namespace eposnow.Controllers
{
    public class TablesController : ApiController
    {
        private TableRepository tableRepository = new TableRepository();

        public List<Table> Get()
        {
            try
            {
                return this.tableRepository.getTables();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Table Get(int id)
        {
            try
            {
                Table mesa = this.tableRepository.getTables().Find(m => m.id.Equals(id));
                return mesa;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

 
        public void Delete(int id)
        {
            try
            {
                Table mesa = this.tableRepository.getTables().Find(m => m.id.Equals(id));
                if (mesa != null)
                {
                    this.tableRepository.getTables().RemoveAt(this.tableRepository.getTables().IndexOf(mesa));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
