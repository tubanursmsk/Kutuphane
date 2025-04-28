<img width="683" alt="program cs giriş" src="https://github.com/user-attachments/assets/932d00fd-3be3-4cd5-aabd-de67847a00d4" /># 📚 Kütüphane Yönetim Sistemi

Bu proje, C# dilinde ve ADO.NET kullanılarak geliştirilen bir **Kütüphane Yönetim Sistemi** uygulamasıdır.  
Konsol tabanlıdır ve **katmanlı mimari** kullanılmıştır.

## 🛠 Kullanılan Teknolojiler
- C# (.NET 8.0)
- SQL Server (DBeaver kullanıldı)
- ADO.NET
- Katmanlı Mimari (Models, Servis, Utils)

## 📦 Proje Özellikleri
- Yazar ekleme/listeleme
- Kitap ekleme/listeleme
- Üye ekleme/listeleme
- Kitap ödünç verme ve ödünçleri listeleme
- View, Stored Procedure, Function kullanımı
- Konsolda kullanıcı dostu menü

## 🗄 Veritabanı Yapısı
- Tablolar: `Yazarlar`, `Kitaplar`, `Uyeler`, `Oduncler`
- View: `vw_OduncDetaylari`
- Stored Procedure: `sp_KitapEkle`
- Function: `fn_GecikmeGunSayisi`

## 🚀 Kurulum
1. `KutuphaneDB.sql` dosyasındaki sorguları çalıştırarak veritabanını oluşturun.
2. Proje klasörünü açın.
3. Visual Studio Code ile `Program.cs` dosyasını çalıştırın.

## ✨ Katkı Sağlayanlar
- (https://github.com/tubanursmsk)

