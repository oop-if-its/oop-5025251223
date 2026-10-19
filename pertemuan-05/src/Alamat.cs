namespace Pertemuan05;


public class Alamat
{
    //catatan say: Properti get-only untuk Jalan dan Kota sesuai ketentuan Level 1
    public string Jalan { get; }
    public string Kota { get; }

    public Alamat(string jalan, string kota)
    {
        //catatan say: Validasi parameter jalan dan kota tidak boleh kosong/null/spasi
        if (string.IsNullOrWhiteSpace(jalan))
            throw new ArgumentException("Nama jalan tidak boleh kosong.", nameof(jalan));
        if (string.IsNullOrWhiteSpace(kota))
            throw new ArgumentException("Nama kota tidak boleh kosong.", nameof(kota));

        Jalan = jalan;
        Kota = kota;
    }

    //catatan say: Override ToString() sesuai format "<Jalan>, <Kota>"
    public override string ToString()
    {
        return $"{Jalan}, {Kota}";
    }
}
