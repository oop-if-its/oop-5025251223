namespace Pertemuan06;

public class Buku : Item
{
    public string Penulis { get; }

    public Buku(string judul, string penulis) : base(judul)
    {
        if (string.IsNullOrWhiteSpace(penulis))
            throw new ArgumentException("Penulis tidak boleh kosong.", nameof(penulis));
        Penulis = penulis;
    }

    // TODO(Level 2): tulis override HitungDenda(int) untuk Buku: Rp2.000 per hari terlambat (hariTerlambat <= 0 -> 0). Pakai `public override`, BUKAN `new`.
    // Catatan say: Gunakan `override` biar manggil versi Buku, jangan pakai `new` karena bakal dianggap menyembunyikan (bukan polimorfisme asli).
    public override int HitungDenda(int hariTerlambat)
    {
        if (hariTerlambat <= 0) return 0;
        return hariTerlambat * 2000;
    }

    // TODO(Level 4): override properti MasaPinjamHari -> 14.
    public override int MasaPinjamHari => 14;

    // TODO(Level 5): override Deskripsi() -> "<base.Deskripsi()> oleh <Penulis>", mis. "[Bumi Manusia] oleh Pramoedya".
    public override string Deskripsi()
    {
        // Catatan say: `base.Deskripsi()` dipakai buat narik teks `[Judul]` dari kelas induk Item, lalu ditambahin string penulis di belakangnya.
        return $"{base.Deskripsi()} oleh {Penulis}";
    }
}