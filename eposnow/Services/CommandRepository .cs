using eposnow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;

namespace eposnow.Services
{
    public class CommandRepository
    {

        private const string CacheKey = "CommandStore";

        public List<Command> GetAllCommands()
        {
            var ctx = HttpContext.Current;

            if (ctx.Cache[CacheKey] != null)
            {
                return (List<Command>)ctx.Cache[CacheKey];
            }

            return new List<Command>();
        }

        public Command SaveCommand(Command command)
        {
            var ctx = HttpContext.Current;

            try
            {
                List<Command> commandData = (List<Command>)ctx.Cache[CacheKey];
                if(commandData == null)
                {
                    commandData = new List<Command>();
                }

                if(commandData.Count > 0)
                { 
                    Command commandFind = commandData.Find(c => c.id.Equals(command.id));
                    if (commandFind != null)
                    {
                        commandData.RemoveAt(commandData.IndexOf(commandFind));
                    }
                }

                commandData.Add(command);
                
                
                ctx.Cache[CacheKey] = commandData;

                return command;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}