namespace Pertemuan05;

public class Anggota
{
    public string Id { get; set; }
    public string Nama { get; set; }
    public Alamat Alamat { get; set; }
    
    // Catatan Sayyidah: Komposisi LogAktivitas (milik tiap anggota) - Level 9
    private readonly LogAktivitas _log = new();
    public IReadOnlyList<string> Riwayat => _log.Riwayat().ToList();

    // Catatan Sayyidah: Modifier protected set untuk BatasPinjam - Level 4
    public int BatasPinjam { get; protected set; } = 2;
    public int JumlahPinjam { get; set; } = 0;

    public Anggota(string id, string nama, Alamat alamat)
    {
        // Catatan Sayyidah: Validasi parameter konstruktor - Level 2
        if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(nama))
        {
            throw new ArgumentException("ID dan Nama wajib terisi.");
        }
        ArgumentNullException.ThrowIfNull(alamat);

        Id = id;
        Nama = nama;
        Alamat = alamat; // Disimpan tanpa disalin (objek yang sama)
    }

    public virtual int Pinjam(string judul)
    {
        // Catatan Sayyidah: Validasi judul dan batas pinjam - Level 5 & Level 9
        if (string.IsNullOrWhiteSpace(judul))
        {
            throw new ArgumentException("Judul buku tidak boleh kosong.");
        }
        if (JumlahPinjam >= BatasPinjam)
        {
            throw new InvalidOperationException("Batas peminjaman buku sudah tercapai.");
        }

        // Catatan Sayyidah: Catat ke log aktivitas jika berhasil meminjam
        _log.Catat($"Pinjam: {judul}");
        return ++JumlahPinjam;
    }

    // Catatan Sayyidah: Format Info sesuai Level 2 -> "<Id> - <Nama>"
    public virtual string Info()
    {
        return $"{Id} - {Nama}";
    }

    public virtual string InfoLengkap()
    {
        return Info();
    }
}