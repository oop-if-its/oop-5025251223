namespace Pertemuan05;

public class Dosen : Anggota
{
    public string Nip { get; set; }

    public Dosen(string id, string nama, Alamat alamat, string nip) : base(id, nama, alamat)
    {
        if (string.IsNullOrWhiteSpace(nip))
        {
            throw new ArgumentException("NIP tidak boleh kosong.");
        }
        Nip = nip;
        BatasPinjam = 10; // Level 4: Batas pinjam Dosen = 10
    }

    public Dosen(string id, string nama, Alamat alamat) : base(id, nama, alamat)
    {
        Nip = id;
        BatasPinjam = 10;
    }

    // Level 7: InfoLengkap untuk Dosen
    public override string InfoLengkap()
    {
        return $"{Info()} | NIP: {Nip} | Alamat: {Alamat}";
    }
}