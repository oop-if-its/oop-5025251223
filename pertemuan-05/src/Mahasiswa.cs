namespace Pertemuan05;

public class Mahasiswa : Anggota
{
    public string Nrp { get; }
    public string Prodi { get; }

    public Mahasiswa(string id, string nama, Alamat alamat, string nrp, string prodi) : base(id, nama, alamat)
    {
        //catatan say: Validasi NRP dan Prodi (Level 3)
        if (string.IsNullOrWhiteSpace(nrp))
            throw new ArgumentException("NRP tidak boleh kosong.", nameof(nrp));
        if (string.IsNullOrWhiteSpace(prodi))
            throw new ArgumentException("Prodi tidak boleh kosong.", nameof(prodi));

        Nrp = nrp;
        Prodi = prodi;
        
        //catatan say: Batas pinjam untuk Mahasiswa adalah 3 (Level 4)
        BatasPinjam = 3;
    }

    //catatan say: InfoLengkap Mahasiswa sesuai format uji (Level 7)
    public override string InfoLengkap()
    {
        return $"{Info()} | NRP: {Nrp} | Prodi: {Prodi} | Alamat: {Alamat}";
    }
}
