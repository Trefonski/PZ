using Microsoft.AspNetCore.Mvc;
using PZ.Models;

namespace PZ.Services
{
    public class ClientsService
    {
        private readonly AppDbContext _context;
        public ClientsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> InsertClient(string UserName)
        {
            if(String.IsNullOrWhiteSpace(UserName))
            {
                return new BadRequestResult();
            }

            Clients client = new Clients();

            client.ClientName = UserName;
            client.ID_Client = _context.Clients.OrderByDescending(x => x.ID_Client).Select(x => x.ID_Client).FirstOrDefault() + 1;
            client.Login = UserName;

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return new OkResult();
        }
    }
}