// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan05;

// Komposisi: Perpustakaan MEMILIKI kumpulan Anggota. Karena Mahasiswa dan Dosen
// adalah Anggota, satu daftar bertipe Anggota bisa menampung keduanya.
public class Perpustakaan
{
    private readonly List<Anggota> _anggota = new();

    public int JumlahAnggota => _anggota.Count;

    public void Daftarkan(Anggota anggota)
    {
        ArgumentNullException.ThrowIfNull(anggota);

        if (_anggota.Any(a => a.Id == anggota.Id))
            throw new InvalidOperationException($"Anggota dengan Id '{anggota.Id}' sudah terdaftar.");

        _anggota.Add(anggota);
    }

    public Anggota? Cari(string id)
    {
        return _anggota.FirstOrDefault(a => a.Id == id);
    }

    public int JumlahMahasiswa()
    {
        return _anggota.OfType<Mahasiswa>().Count();
    }

    public int JumlahDosen()
    {
        return _anggota.OfType<Dosen>().Count();
    }
}
