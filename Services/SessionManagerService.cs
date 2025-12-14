using System.Collections.Generic;
using System.Text.Json;
using WebApplication_f.Models;

namespace WebApplication_f.Services
{
    public class SessionManagerService : ISessionManagerService
    {
        public void Add(string key, object obj, HttpContext context)
        {
            string chaine = JsonSerializer.Serialize(obj);
            context.Session.SetString(key, chaine);
        }
        public T Get<T>(string key, HttpContext context)
        {
            return JsonSerializer.Deserialize<T>(context.Session.GetString(key) ?? "[]");
        }
    }
}
