using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using HairSalon.Models;
using System.Linq;
using System.Threading.Tasks;

namespace HairSalon.ViewModels
{
    public class StylistViewModel
    {
        public Stylist stylist { get; set; }

        public StylistViewModel(Stylist stylist)
        {
            this.stylist = stylist;
        }

        public List<Client> GetAllClients()
        {
            return Client.GetAll();
        }

        public List<Specialty> GetAllSpecialties()
        {
            return Specialty.GetAll();
        }
    }
}
