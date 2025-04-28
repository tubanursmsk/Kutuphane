namespace Kutuphane.Models;
public class Odunc
{
    public int OduncID { get; set; }
    public int KitapID { get; set; }
    public int UyeID { get; set; }
    public DateTime OduncTarihi { get; set; }
    public DateTime? IadeTarihi { get; set; }

    // İlişkiler
    public Kitap Kitap { get; set; }
    public Uye Uye { get; set; }
}