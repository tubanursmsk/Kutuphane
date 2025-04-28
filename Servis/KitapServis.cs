using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Kutuphane.Models;
using Kutuphane.Utils;



namespace Kutuphane.Servis
{
    public class KitapServis
    {
        private DB _db;

        public KitapServis()
        {
            _db = new DB();
        }

        public void KitapEkle(Kitap kitap)
        {
            var connection = _db.GetConnection();
            try
            {
                string query = "INSERT INTO Kitaplar (Baslik, YazarID, YayinYili, ISBN) VALUES (@Baslik, @YazarID, @YayinYili, @ISBN)";
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Baslik", kitap.Baslik);
                cmd.Parameters.AddWithValue("@YazarID", kitap.YazarID);
                cmd.Parameters.AddWithValue("@YayinYili", kitap.YayinYili);
                cmd.Parameters.AddWithValue("@ISBN", kitap.ISBN);
                cmd.ExecuteNonQuery();
                Console.WriteLine("✅ Kitap başarıyla eklendi.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
            finally
            {
                _db.CloseConnection();
            }
        }

        public void KitaplariListele()
        {
            var connection = _db.GetConnection();
            try
            {
                string query = "SELECT k.KitapID, k.Baslik, y.Ad + ' ' + y.Soyad AS YazarAdi, k.YayinYili, k.ISBN FROM Kitaplar k JOIN Yazarlar y ON k.YazarID = y.YazarID";
                using SqlCommand cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("--- Kitaplar Listesi ---");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["KitapID"]} - Başlık: {reader["Baslik"]} - Yazar: {reader["YazarAdi"]} - Yayın Yılı: {reader["YayinYili"]} - ISBN: {reader["ISBN"]}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
            finally
            {
                _db.CloseConnection();
            }
        }

        public List<Kitap> TumKitaplariGetir()
        {
            var kitaplar = new List<Kitap>();
            var connection = _db.GetConnection();
            try
            {
                string query = "SELECT KitapID, Baslik, YazarID, YayinYili, ISBN FROM Kitaplar";
                using SqlCommand cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    kitaplar.Add(new Kitap
                    {
                        KitapID = reader.GetInt32(0),
                        Baslik = reader.GetString(1),
                        YazarID = reader.GetInt32(2),
                        YayinYili = reader.GetInt32(3),
                        ISBN = reader.GetString(4)
                    });
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
            finally
            {
                _db.CloseConnection();
            }

            return kitaplar;
        }


    }
}