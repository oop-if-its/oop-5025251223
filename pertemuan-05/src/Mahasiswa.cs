namespace Pertemuan05;

public class Mahasiswa : Anggota
{
    public string Nrp { get; set; }
    public string Prodi { get; set; }

    public Mahasiswa(string id, string nama, Alamat alamat, string nrp, string prodi) : base(id, nama, alamat)
    {
        if (string.IsNullOrWhiteSpace(nrp) || string.IsNullOrWhiteSpace(prodi))
        {
            throw new ArgumentException("NRP dan Prodi tidak boleh kosong.");
        }
        Nrp = nrp;
        Prodi = prodi;
        BatasPinjam = 3; // Level 4: Batas pinjam Mahasiswa = 3
    }

    public Mahasiswa(string id, string nama, Alamat alamat, string prodi) : base(id, nama, alamat)
    {
        if (string.IsNullOrWhiteSpace(prodi))
        {
            throw new ArgumentException("Prodi tidak boleh kosong.");
        }
        Nrp = id;
        Prodi = prodi;
        BatasPinjam = 3;
    }

    public Mahasiswa(string id, string nama, Alamat alamat) : base(id, nama, alamat)
    {
        Nrp = id;
        Prodi = "Informatika";
        BatasPinjam = 3;
    }

    // Level 7: InfoLengkap untuk Mahasiswa
    public override string InfoLengkap()
    {
        return $"{Info()} | NRP: {Nrp} | Prodi: {Prodi} | Alamat: {Alamat}";
    }
}