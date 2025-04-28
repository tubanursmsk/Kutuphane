using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Kutuphane.Models;
using Kutuphane.Utils;

namespace Kutuphane.Servis;

public class OduncServis
{
    DB db = new();

    public void OduncEkle(Odunc odunc)
    {
        var connection = db.GetConnection();
        SqlCommand cmd = new SqlCommand("INSERT INTO Oduncler (KitapID, UyeID, OduncTarihi) VALUES (@KitapID, @UyeID, @OduncTarihi)", connection);
        cmd.Parameters.AddWithValue("@KitapID", odunc.KitapID);
        cmd.Parameters.AddWithValue("@UyeID", odunc.UyeID);
        cmd.Parameters.AddWithValue("@OduncTarihi", odunc.OduncTarihi);
        cmd.ExecuteNonQuery();
        db.CloseConnection();
    }

    public List<Odunc> TumOdunclariGetir()
    {
        List<Odunc> oduncler = new();
        var connection = db.GetConnection();
        SqlCommand cmd = new SqlCommand("SELECT * FROM vw_OduncDetaylari", connection);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            oduncler.Add(new Odunc
            {
                OduncID = (int)reader["OduncID"],
                KitapID = 0, // View'dan KitapID almıyoruz
                UyeID = 0,   // View'dan UyeID almıyoruz
                OduncTarihi = (DateTime)reader["OduncTarihi"],
                IadeTarihi = reader["IadeTarihi"] == DBNull.Value ? null : (DateTime?)reader["IadeTarihi"]
            });
        }
        reader.Close();
        db.CloseConnection();
        return oduncler;
    }

    public List<Odunc> GecikmeliOdunclariGetir()
    {
        List<Odunc> oduncler = new List<Odunc>();
        using (var connection = new DB().GetConnection())
        {
            var command = new SqlCommand("SELECT * FROM vw_GecikmeliOduncler", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                oduncler.Add(new Odunc
                {
                    OduncID = Convert.ToInt32(reader["OduncID"]),
                    KitapID = Convert.ToInt32(reader["KitapID"]),
                    UyeID = Convert.ToInt32(reader["UyeID"]),
                    OduncTarihi = Convert.ToDateTime(reader["OduncTarihi"]),
                    IadeTarihi = reader["IadeTarihi"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["IadeTarihi"]),
                });
            }
        }
        return oduncler;
    }

    

}
