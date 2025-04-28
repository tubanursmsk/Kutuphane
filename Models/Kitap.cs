namespace Kutuphane.Models;
public class Kitap
{
    public int KitapID { get; set; }
    public string? Baslik { get; set; }
    public int YazarID { get; set; }
    public int YayinYili { get; set; }
    public string? ISBN { get; set; }

    // İlişkiyi modellemek için
    public Yazar Yazar { get; set; }
}