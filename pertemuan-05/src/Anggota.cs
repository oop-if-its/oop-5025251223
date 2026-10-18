using System.Collections.Generic;

namespace Pertemuan05;

public class Anggota
{
    public string Id { get; }
    public string Nama { get; }
    public Alamat Alamat { get; }

    //catatan say: Komposisi LogAktivitas (Level 9)
    private readonly LogAktivitas _log = new();
    public IReadOnlyList<string> Riwayat => (IReadOnlyList<string>)_log.Riwayat();

    //catatan say: Modifier protected set untuk BatasPinjam (Level 4)
    public int BatasPinjam { get; protected set; } = 2;
    public int JumlahPinjam { get; private set; } = 0;

    public Anggota(string id, string nama, Alamat alamat)
    {
        //catatan say: Validasi parameter konstruktor Anggota (Level 2)
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("ID tidak boleh kosong.", nameof(id));
        if (string.IsNullOrWhiteSpace(nama))
            throw new ArgumentException("Nama tidak boleh kosong.", nameof(nama));
        
        Alamat = alamat ?? throw new ArgumentNullException(nameof(alamat), "Alamat tidak boleh null.");

        Id = id;
        Nama = nama;
    }

    //catatan say: Method Info() mengembalikan format "<Id> - <Nama>" (Level 2)
    public virtual string Info()
    {
        return $"{Id} - {Nama}";
    }

    public virtual string InfoLengkap()
    {
        return $"{Info()} | Alamat: {Alamat}";
    }

    //catatan say: Method Pinjam dengan validasi batas pinjam (Level 5) dan pencatatan log (Level 9)
    public virtual void Pinjam(string judul)
    {
        if (string.IsNullOrWhiteSpace(judul))
            throw new ArgumentException("Judul buku tidak boleh kosong.", nameof(judul));
        
        if (JumlahPinjam >= BatasPinjam)
            throw new InvalidOperationException("Batas maksimal peminjaman telah tercapai.");

        JumlahPinjam++;
        _log.Catat($"Pinjam: {judul}");
    }
}
