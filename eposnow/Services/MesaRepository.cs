using eposnow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eposnow.Services
{
    public class MesaRepository
    {
        private List<Mesa> mesas = new List<Mesa>();

        public List<Mesa> getMesas()
        {
            for (int i = 1; i <= 5; i++)
            {
                Mesa mesa = new Mesa
                {
                    id = i,
                    nome = "Mesa " + i,
                };

                this.mesas.Add(mesa);
            }

            return this.mesas;
        }
    }
}