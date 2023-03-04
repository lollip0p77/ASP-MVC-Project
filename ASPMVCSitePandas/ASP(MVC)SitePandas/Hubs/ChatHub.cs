using Microsoft.AspNetCore.Mvc;
using ASP_MVC_SitePandas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ASP_MVC_SitePandas.Hubs
{
    public class ChatHub : Hub
    {
        private readonly LesPetitsPandasContext _context;
        public ChatHub(LesPetitsPandasContext context)
        {
            _context = context;
        }
        public async Task SendMessage(string userE, string userR, string role, string message)
        {
            int userEducatrice = int.Parse(userE);
            int userRepondant = int.Parse(userR);
            DateTime date = DateTime.Now;
            var chatMessage = new Message
            {
                RepondantId = userRepondant, // Replace with the actual receiver
                EducatriceId = userEducatrice,
                Date = date,
                Message1 = message,
                Actif = true,
                Envoyeur = role
            };
            _context.Messages.Add(chatMessage);
            await _context.SaveChangesAsync();
            await Clients.All.SendAsync("ReceiveMessage", message, date, role);           
        }
    }
}
