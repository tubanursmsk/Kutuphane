using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Kutuphane.Models;
using Kutuphane.Utils;


namespace Kutuphane.Servis;

public class YazarServis
{
    DB db = new();

    public void YazarEkle(Yazar yazar)
    {
        var connection = db.GetConnection();
        SqlCommand cmd = new SqlCommand("INSERT INTO Yazarlar (Ad, Soyad) VALUES (@Ad, @Soyad)", connection);
        cmd.Parameters.AddWithValue("@Ad", yazar.Ad);
        cmd.Parameters.AddWithValue("@Soyad", yazar.Soyad);
        cmd.ExecuteNonQuery();
        db.CloseConnection();
    }

    public List<Yazar> TumYazarlariGetir()
    {
        List<Yazar> yazarlar = new();
        var connection = db.GetConnection();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Yazarlar", connection);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            yazarlar.Add(new Yazar
            {
                YazarID = (int)reader["YazarID"],
                Ad = reader["Ad"].ToString(),
                Soyad = reader["Soyad"].ToString()
            });
        }
        reader.Close();
        db.CloseConnection();
        return yazarlar;
    }


    public List<Yazar> YazarListele()
{
    List<Yazar> yazarlar = new List<Yazar>();
    var connection = db.GetConnection();
    SqlCommand cmd = new SqlCommand("SELECT * FROM Yazarlar", connection);
    SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        yazarlar.Add(new Yazar
        {
            YazarID = (int)reader["YazarID"],
            Ad = reader["Ad"].ToString(),
            Soyad = reader["Soyad"].ToString()
        });
    }
    reader.Close();
    db.CloseConnection();
    return yazarlar;
}

}
