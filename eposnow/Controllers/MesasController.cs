using eposnow.Models;

using System;
using System.Linq;
using System.Web.Http;
using System.Collections.Generic;
using eposnow.Services;

namespace eposnow.Controllers
{
    public class MesasController : ApiController
    {
        private MesaRepository mesaRepositoy = new MesaRepository();

        public List<Mesa> Get()
        {
            try
            {
                return this.mesaRepositoy.getMesas();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Mesa Get(int id)
        {
            try
            {
                Mesa mesa = this.mesaRepositoy.getMesas().First(m => m.id.Equals(id));
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
                Mesa mesa = this.mesaRepositoy.getMesas().First(m => m.id.Equals(id));
                if (mesa != null)
                {
                    this.mesaRepositoy.getMesas().RemoveAt(this.mesaRepositoy.getMesas().IndexOf(mesa));
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
