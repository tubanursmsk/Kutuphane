using System;
using Kutuphane.Models;
using Kutuphane.Servis;
using Kutuphane.Utils;


namespace Kutuphane;

class Program
{
    static void Main(string[] args)
    {
        YazarServis yazarServis = new();
        KitapServis kitapServis = new();
        UyeServis uyeServis = new();
        OduncServis oduncServis = new();

        while (true)
        {
            Console.WriteLine("\n--- KÜTÜPHANE YÖNETİM SİSTEMİ ---");
            Console.WriteLine("1. Yazar Ekle");
            Console.WriteLine("2. Yazar Listele");
            Console.WriteLine("3. Kitap Ekle");
            Console.WriteLine("4. Kitap Listele");
            Console.WriteLine("5. Üye Ekle");
            Console.WriteLine("6. Üye Listele");
            Console.WriteLine("7. Kitap Ödünç Ver");
            Console.WriteLine("8. Ödünçleri Listele");
            Console.WriteLine("9. Geciken Ödünçleri Listele");
            Console.WriteLine("10. Çıkış");
            Console.Write("Seçiminiz: ");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Console.Write("Yazar Adı: ");
                    string yazarAd = Console.ReadLine();
                    Console.Write("Yazar Soyadı: ");
                    string yazarSoyad = Console.ReadLine();
                    yazarServis.YazarEkle(new Yazar { Ad = yazarAd, Soyad = yazarSoyad });
                    Console.WriteLine("Yazar eklendi.");
                    break;

                case "2":
                    var yazarlar = yazarServis.TumYazarlariGetir();
                    Console.WriteLine("\n--- Yazarlar ---");
                    foreach (var y in yazarlar)
                        Console.WriteLine($"{y.YazarID} - {y.Ad} {y.Soyad}");
                    break;

                case "3":
                    Console.Write("Kitap Başlığı: ");
                    string kitapBaslik = Console.ReadLine();
                    Console.Write("Yazar ID: ");
                    int kitapYazarID = int.Parse(Console.ReadLine());
                    Console.Write("Yayın Yılı: ");
                    int yayinYili = int.Parse(Console.ReadLine());
                    Console.Write("ISBN: ");
                    string isbn = Console.ReadLine();
                    kitapServis.KitapEkle(new Kitap { Baslik = kitapBaslik, YazarID = kitapYazarID, YayinYili = yayinYili, ISBN = isbn });
                    Console.WriteLine("Kitap eklendi.");
                    break;

                case "4":
                    var kitaplar = kitapServis.TumKitaplariGetir();
                    Console.WriteLine("\n--- Kitaplar ---");
                    foreach (var k in kitaplar)
                        Console.WriteLine($"{k.KitapID} - {k.Baslik} (YazarID: {k.YazarID})");
                    break;

                case "5":
                    Console.Write("Üye Adı: ");
                    string uyeAd = Console.ReadLine();
                    Console.Write("Üye Soyadı: ");
                    string uyeSoyad = Console.ReadLine();
                    Console.Write("Eposta: ");
                    string eposta = Console.ReadLine();
                    Console.Write("Telefon: ");
                    string telefon = Console.ReadLine();
                    uyeServis.UyeEkle(new Uye { Ad = uyeAd, Soyad = uyeSoyad, Eposta = eposta, Telefon = telefon });
                    Console.WriteLine("Üye eklendi.");
                    break;

                case "6":
                    var uyeler = uyeServis.TumUyeleriGetir();
                    Console.WriteLine("\n--- Üyeler ---");
                    foreach (var u in uyeler)
                        Console.WriteLine($"{u.UyeID} - {u.Ad} {u.Soyad} ({u.Eposta})");
                    break;

                case "7":
                    Console.Write("Kitap ID: ");
                    int oduncKitapID = int.Parse(Console.ReadLine());
                    Console.Write("Üye ID: ");
                    int oduncUyeID = int.Parse(Console.ReadLine());
                    oduncServis.OduncEkle(new Odunc { KitapID = oduncKitapID, UyeID = oduncUyeID, OduncTarihi = DateTime.Now });
                    Console.WriteLine("Kitap ödünç verildi.");
                    break;

                case "8":
                    var oduncler = oduncServis.TumOdunclariGetir();
                    Console.WriteLine("\n--- Ödünçler ---");
                    foreach (var o in oduncler)
                        Console.WriteLine($"{o.OduncID} - KitapID: {o.KitapID} ÜyeID: {o.UyeID} ÖdünçTarihi: {o.OduncTarihi} İadeTarihi: {o.IadeTarihi}");
                    break;

                case "9":
                    var gecikmeliOduncler = oduncServis.GecikmeliOdunclariGetir();
                    Console.WriteLine("\n--- Geç İade Kitaplar ---");
                    foreach (var o in gecikmeliOduncler)
                        Console.WriteLine($"{o.OduncID} - KitapID: {o.KitapID} ÜyeID: {o.UyeID} ÖdünçTarihi: {o.OduncTarihi} İadeTarihi: {o.IadeTarihi}");
                    break;


                case "10":
                    Console.WriteLine("Çıkış yapılıyor...");
                    return;

                default:
                    Console.WriteLine("Geçersiz seçim! Tekrar deneyin.");
                    break;
            }
        }
    }
}
