// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan05;

// Kelas dasar (base class) untuk semua jenis anggota perpustakaan.
public class Anggota
{
    public string Id { get; }
    public string Nama { get; }

    // Komposisi: Anggota memiliki Alamat.
    public Alamat Alamat { get; }

    // Level 4: BatasPinjam dengan protected set
    public int BatasPinjam { get; protected set; } = 2;

    public int JumlahPinjam { get; private set; }

    // Level 9: setiap Anggota MEMILIKI log-nya sendiri
    private readonly LogAktivitas _log = new();

    // Level 9: riwayat aktivitas milik anggota ini.
    public IReadOnlyList<string> Riwayat => _log.Semua;

    public Anggota(string id, string nama, Alamat alamat)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Id tidak boleh kosong.", nameof(id));
        if (string.IsNullOrWhiteSpace(nama))
            throw new ArgumentException("Nama tidak boleh kosong.", nameof(nama));
        ArgumentNullException.ThrowIfNull(alamat);

        Id = id;
        Nama = nama;
        Alamat = alamat;
    }

    public string Info()
    {
        return $"{Id} - {Nama}";
    }

    public void Pinjam(string judul)
    {
        if (string.IsNullOrWhiteSpace(judul))
            throw new ArgumentException("Judul tidak boleh kosong.", nameof(judul));
        if (JumlahPinjam >= BatasPinjam)
            throw new InvalidOperationException("Jumlah pinjaman telah mencapai batas maksimal.");

        JumlahPinjam++;
        _log.Catat($"Pinjam: {judul}");
    }
}
