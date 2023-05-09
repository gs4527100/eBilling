using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using eBilling.Models;
using System.Data;

namespace eBilling.DAL
{
    public class Items_DAL
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        public static IConfiguration Configration { get; set; }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configration = builder.Build();

            return Configration.GetConnectionString("DefaultConnection");
        }

        public List<Items> GetItems()
        {
            List < Items > list= new List<Items>();
            using(con=new SqlConnection(GetConnectionString()))
            {
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "udp_sel_Item";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    Items i = new Items();
                    i.Id = Convert.ToInt32(dr["Id"]);
                    i.Name = dr["Name"].ToString();
                   // i.Active =  dr["Active"].ToString().ToCharArray();
                    list.Add(i);
                }
                con.Close();
            }
            return list;
        }
    }
}
