using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VillageMVCWebApplication.Models;

namespace VillageMVCWebApplication.Controllers.API
{
    public class CitizensController : ApiController
    {
       private VillageDataContex VillageDB = new VillageDataContex();

        // GET: api/Citizens
        public IHttpActionResult Get()
        {
            return Ok(VillageDB.Citizens);
        }

        // GET: api/Citizens/5
        public async Task<IHttpActionResult> GetCitizen(int id)
        {
            Citizen CitizenToFind = await VillageDB.Citizens.FindAsync(id);
            if (CitizenToFind == null)
            {
                return NotFound();
            }

            return Ok(CitizenToFind);
        }


        // POST: api/Citizens
        public async Task<IHttpActionResult> Post([FromBody]Citizen citizen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            VillageDB.Citizens.Add(citizen);
            await VillageDB.SaveChangesAsync();
            return Ok("The citizen Added Successfully");
        }

        // PUT: api/Citizens/5
        public async Task<IHttpActionResult> PutElegantShoes(int id, Citizen citizen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Citizen citizenToUpdate = await VillageDB.Citizens.FindAsync(id);
                citizenToUpdate.CitizenParent = citizen.CitizenParent;
                citizenToUpdate.Gender = citizen.Gender;
                citizenToUpdate.IsBornInVillage = citizen.IsBornInVillage;
                citizenToUpdate.Birthdate = citizen.Birthdate;

                await VillageDB.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitizenExists(id))
                {
                    return NotFound();
                }
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        // DELETE: api/Citizens/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            Citizen citizen = await VillageDB.Citizens.FindAsync(id);
            if (citizen == null)
            {
                return NotFound();
            }

            VillageDB.Citizens.Remove(citizen);
            await VillageDB.SaveChangesAsync();

            return Ok("The citizen Deleted Successfully");
        }

        private bool CitizenExists(int id)
        {
            return VillageDB.Citizens.Count(e => e.CitizenId == id) > 0;
        }

    }
}
