namespace Pertemuan05;

public class Dosen : Anggota
{
    public string Nip { get; }

    public Dosen(string id, string nama, Alamat alamat, string nip) : base(id, nama, alamat)
    {
        //catatan say: Validasi NIP (Level 3)
        if (string.IsNullOrWhiteSpace(nip))
            throw new ArgumentException("NIP tidak boleh kosong.", nameof(nip));

        Nip = nip;
        
        //catatan say: Batas pinjam untuk Dosen adalah 10 (Level 4)
        BatasPinjam = 10;
    }

    //catatan say: InfoLengkap Dosen sesuai format uji (Level 7)
    public override string InfoLengkap()
    {
        return $"{Info()} | NIP: {Nip} | Alamat: {Alamat}";
    }
}
