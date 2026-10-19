// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan06;

public class Majalah : Item
{
    public int Edisi { get; }

    // SUDAH LENGKAP -- jangan diubah.
    public Majalah(string judul, int edisi) : base(judul)
    {
        if (edisi <= 0)
            throw new ArgumentOutOfRangeException(nameof(edisi), "Edisi harus positif.");
        Edisi = edisi;
    }

    // TODO(Level 3): override HitungDenda(int): Rp500 per hari terlambat
    //   (hariTerlambat <= 0 -> 0).
    //catatan say: Override HitungDenda untuk Majalah sebesar Rp500 per hari (Level 3)
    public override int HitungDenda(int hariTerlambat)
    {
        if (hariTerlambat <= 0)
            return 0;
        return hariTerlambat * 500;
    }

    // TODO(Level 4): override MasaPinjamHari -> 3.
    //catatan say: Override MasaPinjamHari menjadi 3 hari untuk Majalah (Level 4)
    public override int MasaPinjamHari => 3;

    // TODO(Level 5): override Deskripsi() -> "<base.Deskripsi()> edisi <Edisi>",
    //   mis. "[Tempo] edisi 12".
    //catatan say: Override Deskripsi dengan memanggil base.Deskripsi() dan menambahkan edisi (Level 5)
    public override string Deskripsi()
    {
        return $"{base.Deskripsi()} edisi {Edisi}";
    }
}
