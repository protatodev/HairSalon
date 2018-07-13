using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System.Linq;
using System.Threading.Tasks;

namespace HairSalon.Models
{
    public class Stylist
    {
        public string Name { get; set; }
        public int ClientId { get; set; }
        public int Experience { get; set; }
        public int Id { get; set; }
        
        public Stylist(string name, int client_id, int experience = 0, int id = 0)
        {
            Name = name;
            ClientId = client_id;
            Experience = experience;
            Id = id;
        }
    }
}
