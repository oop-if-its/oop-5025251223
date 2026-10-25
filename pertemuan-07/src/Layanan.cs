// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan07;

// Bekerja dengan KONTRAK (interface), bukan kelas konkret.
public static class Katalog
{
    public static int PinjamSemua(IEnumerable<IDapatDipinjam> daftar)
    {
        // TODO(Level 5): null -> ArgumentNullException. Panggil Pinjam() pada
        //   tiap elemen; kalau sebuah elemen melempar InvalidOperationException
        //   (sedang dipinjam), lewati tanpa menghentikan yang lain. Kembalikan
        //   JUMLAH yang berhasil dipinjam.
        if (daftar == null)
            throw new ArgumentNullException(nameof(daftar));

        int berhasil = 0;
        foreach (var item in daftar)
        {
            try
            {
                item.Pinjam();
                berhasil++;
            }
            catch (InvalidOperationException)
            {
                // Lewati jika sudah dipinjam
            }
        }
        return berhasil;
    }

    public static List<IDapatDipinjam> HanyaBisaDipinjam(IEnumerable<Item> daftar)
    {
        // TODO(Level 5): null -> ArgumentNullException. Dari campuran Item,
        //   ambil hanya yang mengimplementasikan IDapatDipinjam (urutan asli
        //   dipertahankan). BukuReferensi tidak ikut[cite: 21].
        if (daftar == null)
            throw new ArgumentNullException(nameof(daftar));

        return daftar.OfType<IDapatDipinjam>().ToList();
    }
}

// Dependency Injection: LayananPeminjaman TIDAK membuat pemberitahuannya
// sendiri -- ia menerimanya dari luar lewat konstruktor, sebagai interface.
public class LayananPeminjaman
{
    private readonly INotifikasi _notifikasi;

    public LayananPeminjaman(INotifikasi notifikasi)
    {
        // TODO(Level 6): notifikasi null -> ArgumentNullException; selain itu
        //   simpan ke field private readonly `_notifikasi`.
        _notifikasi = notifikasi ?? throw new ArgumentNullException(nameof(notifikasi));
    }

    public void Pinjamkan(Item item, string namaAnggota)
    {
        // TODO(Level 6): item null -> ArgumentNullException; item BUKAN
        //   IDapatDipinjam -> InvalidOperationException; selain itu panggil
        //   Pinjam() (kalau melempar, biarkan menjalar dan JANGAN kirim
        //   notifikasi), lalu kirim pesan "<namaAnggota> meminjam <Judul>" lewat
        //   INotifikasi.
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        if (item is not IDapatDipinjam dipinjam)
            throw new InvalidOperationException("Item tidak dapat dipinjam.");

        dipinjam.Pinjam();
        _notifikasi.Kirim($"{namaAnggota} meminjam {item.Judul}");
    }
}