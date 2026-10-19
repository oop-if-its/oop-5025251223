// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan06;

public class Buku : Item
{
    public string Penulis { get; }

    // SUDAH LENGKAP -- jangan diubah.
    public Buku(string judul, string penulis) : base(judul)
    {
        if (string.IsNullOrWhiteSpace(penulis))
            throw new ArgumentException("Penulis tidak boleh kosong.", nameof(penulis));
        Penulis = penulis;
    }

    // TODO(Level 2): tulis override HitungDenda(int) untuk Buku: Rp2.000 per
    //   hari terlambat (hariTerlambat <= 0 -> 0). Pakai `public override`, BUKAN
    //   `new`.
    //catatan say: Override HitungDenda untuk Buku sebesar Rp2.000 per hari (Level 2)
    public override int HitungDenda(int hariTerlambat)
    {
        if (hariTerlambat <= 0)
            return 0;
        return hariTerlambat * 2000;
    }

    // TODO(Level 4): override properti MasaPinjamHari -> 14.
    //catatan say: Override MasaPinjamHari menjadi 14 hari untuk Buku (Level 4)
    public override int MasaPinjamHari => 14;

    // TODO(Level 5): override Deskripsi() -> "<base.Deskripsi()> oleh
    //   <Penulis>", mis. "[Bumi Manusia] oleh Pramoedya".
    //catatan say: Override Deskripsi dengan memanggil base.Deskripsi() dan menambahkan penulis (Level 5)
    public override string Deskripsi()
    {
        return $"{base.Deskripsi()} oleh {Penulis}";
    }
}
