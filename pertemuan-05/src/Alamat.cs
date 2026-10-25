namespace Pertemuan05;

public class Alamat
{
    // Catatan Sayyidah: Properti get-only sesuai instruksi Level 1
    public string Jalan { get; }
    public string Kota { get; }

    public Alamat(string jalan, string kota)
    {
        // Catatan Sayyidah: Validasi input tidak boleh null, kosong, atau spasi
        if (string.IsNullOrWhiteSpace(jalan) || string.IsNullOrWhiteSpace(kota))
        {
            throw new ArgumentException("Jalan dan Kota tidak boleh kosong.");
        }

        Jalan = jalan;
        Kota = kota;
    }

    // Catatan Sayyidah: Override ToString untuk mengembalikan format "<Jalan>, <Kota>"
    public override string ToString()
    {
        return $"{Jalan}, {Kota}";
    }
}