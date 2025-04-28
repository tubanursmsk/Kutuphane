using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Kutuphane.Models;
using Kutuphane.Utils;

namespace Kutuphane.Servis;

public class UyeServis
{
    DB db = new();

    public void UyeEkle(Uye uye)
    {
        var connection = db.GetConnection();
        SqlCommand cmd = new SqlCommand("INSERT INTO Uyeler (Ad, Soyad, Eposta, Telefon) VALUES (@Ad, @Soyad, @Eposta, @Telefon)", connection);
        cmd.Parameters.AddWithValue("@Ad", uye.Ad);
        cmd.Parameters.AddWithValue("@Soyad", uye.Soyad);
        cmd.Parameters.AddWithValue("@Eposta", uye.Eposta);
        cmd.Parameters.AddWithValue("@Telefon", uye.Telefon);
        cmd.ExecuteNonQuery();
        db.CloseConnection();
    }

    public List<Uye> TumUyeleriGetir()
    {
        List<Uye> uyeler = new();
        var connection = db.GetConnection();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Uyeler", connection);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            uyeler.Add(new Uye
            {
                UyeID = (int)reader["UyeID"],
                Ad = reader["Ad"].ToString(),
                Soyad = reader["Soyad"].ToString(),
                Eposta = reader["Eposta"].ToString(),
                Telefon = reader["Telefon"].ToString()
            });
        }
        reader.Close();
        db.CloseConnection();
        return uyeler;
    }
}
