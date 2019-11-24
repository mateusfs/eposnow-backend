using System.Linq;
using System.Net;
using eposnow.Models;
using System.Web.Http;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using eposnow.Services;
using System.Net.Http;

namespace eposnow.Controllers
{
    public class CommandsController : ApiController
    {
        private CommandRepository commandRepository;

        public CommandsController()
        {
            this.commandRepository = new CommandRepository();
        }

        public HttpResponseMessage Options()
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        public List<Command> GetCommands()
        {
            return this.commandRepository.GetAllCommands();
        }

        [ResponseType(typeof(Command))]
        public Command Get(int id)
        {
            try
            {
                Command command = this.commandRepository.GetAllCommands().First(c => c.table.id.Equals(id));
                return command;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        [Route("api/commands/table/{idTable}")]
        public Command GetCommandByTable(int idTable)
        {
            try
            {
                Command command = this.commandRepository.GetAllCommands().Find(c => c.table.id.Equals(idTable));
                return command;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Command Put(Command command)
        {
            try
            {
                return this.commandRepository.SaveCommand(command);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        public Command Post(Command command)
        {
            try
            {
                return this.commandRepository.SaveCommand(command);
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
                Command command = this.commandRepository.GetAllCommands().Find(m => m.id.Equals(id));
                if (command != null)
                {
                    this.commandRepository.GetAllCommands().RemoveAt(this.commandRepository.GetAllCommands().IndexOf(command));
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
