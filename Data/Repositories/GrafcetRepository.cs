using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.IO;
using DynamicData;
using Tmds.DBus;
using GAG.Models;
using Opc.Ua;

namespace GAG.Data.Repositories
{
    public class GrafcetRepository
    {
        private OleDbConnection Connection { get; set; }
        public GrafcetRepository()
        {
            string parentDirName = new FileInfo(AppDomain.CurrentDomain.BaseDirectory)
                .Directory.Parent.FullName;

            string MDBPath = parentDirName + "\\MDB\\G_HK\\G_HKgag.mdb";

            Connection = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={MDBPath};Persist Security Info=False;");
        }

        public IEnumerable<Grafcet> GetAll()
        {
            List<Grafcet> grafcets = new List<Grafcet>();
            //string query = "SELECT * from t_grafcet";
            //OleDbCommand command = new OleDbCommand(query, Connection);
            //command.Connection.Open();

            //using (var reader = command.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //        grafcets.Add(new Grafcet
            //        {
            //            Nom = Convert.ToString(reader["grafcet"]),
            //            Titre = Convert.ToString(reader["titre"]),
            //            Type = Convert.ToInt32(reader["révision"]) == 1 ? "Simple" : "Phase",
            //            Recette = Convert.ToBoolean(reader["recette"]),
            //            Phase = Convert.ToBoolean(reader["phase"]),
            //            Serveur = Convert.ToBoolean(reader["serveur"]),
            //            Revision = Convert.ToInt32(reader["révision"]),
            //        });
            //    }
            //}
            //Connection.Close();
            grafcets.Add(new Grafcet { Nom = "Grafcet", Titre = "Grafcet1", Type = "Simple", Recette = true, Phase = true, Serveur = true, Revision = 4 });
            grafcets.Add(new Grafcet { Nom = "Grafcet2", Titre = "Grafcet2", Type = "Phase", Recette = true, Phase = false, Serveur = true, Revision = 35 });
            grafcets.Add(new Grafcet { Nom = "Grafcet", Titre = "Grafcet3", Type = "Simple", Recette = false, Phase = true, Serveur = true, Revision = 1 });
    
            return grafcets;
        }

    }
}