using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PZ.Models;

namespace PZ.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext _context;
        public ItemsController(AppDbContext context)
        {
            _context = context;
        }

        private async Task<List<Items>> GetItems(Items.SexType Sex = 0,string Style = "",string ID_Item= "")
        {
            IQueryable<Items> query = _context.Items;

            if(Sex > Items.SexType.none) 
            {
                query = query.Where(x => x.Sex == Sex);

                if(!String.IsNullOrWhiteSpace(Style))
                {
                    query = query.Where(x => x.Style.Equals(Style));
                }
            }

            if(!String.IsNullOrWhiteSpace(ID_Item))
            {
                query = query.Where(x => x.ID_Item.Equals(ID_Item));
                query = query.Include(x => x.Pictures);
            }

            List<Items> orders = await query.Include(x => x.Brands).ToListAsync();

            return orders;
        }

        [HttpGet]
        public async Task<ActionResult> GetItemsAllJson()
        {
            return Json(await GetItems());
        }

        [HttpGet]
        public async Task<ActionResult> GetItemsBySexJson(Items.SexType Sex)
        {
            return Json(await GetItems(Sex));
        }

        [HttpGet]
        public async Task<ActionResult> GetItemsBySexAndStyleJson(Items.SexType Sex,string Style)
        {
            return Json(await GetItems(Sex,Style));
        }

        [HttpGet]
        public async Task<ActionResult> GetSingleItemJson(string ID_Item)
        {
            return Json((await GetItems(0,"",ID_Item)).FirstOrDefault());
        }

        [HttpPost]
        //[Authorize(Roles="Administrator,Manager")]
        public async Task<ActionResult> InsertItem([FromBody] Items item)
        {
            if(item.ID_Brand == 0)
            {
                return BadRequest("Brak wybranego producenta produktu!");
            }

            if(String.IsNullOrWhiteSpace(item.ID_Item))
            {
                return BadRequest("Brak identyfikatora produktu!");
            }

            if(String.IsNullOrWhiteSpace(item.ItemName))
            {
                return BadRequest("Brak wprowadzonej nazwy produktu!");
            }

            try
            {
                await _context.Items.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine($"ItemsController:Cannot insert:{e.ToString()}");
                return BadRequest("Zapis do bazy danych nie powiódł się!");
            }            

            return Ok();
        }
    }
}