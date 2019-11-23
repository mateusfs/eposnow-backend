using System.Linq;
using System.Net;
using eposnow.Models;
using System.Web.Http;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;

namespace eposnow.Controllers
{
    public class ComandasController : ApiController
    {

        private eposnowContext db = new eposnowContext();

        public IQueryable<Comanda> GetComandas()
        {
            return db.Comandas;
        }

        [ResponseType(typeof(Comanda))]
        public async Task<IHttpActionResult> GetComanda(int id)
        {
            Comanda comanda = await db.Comandas.FindAsync(id);
            if (comanda == null)
            {
                return NotFound();
            }

            return Ok(comanda);
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComanda(int id, Comanda comanda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comanda.id)
            {
                return BadRequest();
            }

            if (comanda.situacao != SituacaoEnum.CONCLUIDA)
            {
                return BadRequest();
            }

            db.Entry(comanda).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComandaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Comanda))]
        public async Task<IHttpActionResult> PostComanda(Comanda comanda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (comanda.situacao != SituacaoEnum.CONCLUIDA)
            {
                return BadRequest();
            }

            db.Comandas.Add(comanda);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = comanda.id }, comanda);
        }

        [ResponseType(typeof(Comanda))]
        public async Task<IHttpActionResult> DeleteComanda(int id)
        {
            Comanda comanda = await db.Comandas.FindAsync(id);
            if (comanda == null)
            {
                return NotFound();
            }

            db.Comandas.Remove(comanda);
            await db.SaveChangesAsync();

            return Ok(comanda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComandaExists(int id)
        {
            return db.Comandas.Count(e => e.id == id) > 0;
        }

    }
}
