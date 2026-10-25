namespace Pertemuan05;

public sealed class Asisten : Mahasiswa
{
    public string MataKuliah { get; set; }

    public Asisten(string id, string nama, Alamat alamat, string nrp, string prodi, string mataKuliah) : base(id, nama, alamat, nrp, prodi)
    {
        if (string.IsNullOrWhiteSpace(mataKuliah))
        {
            throw new ArgumentException("Mata kuliah tidak boleh kosong.");
        }
        MataKuliah = mataKuliah;
        BatasPinjam = 5; // Level 6: Batas pinjam Asisten = 5
    }

    public Asisten(string id, string nama, Alamat alamat, string mataKuliah) : base(id, nama, alamat)
    {
        if (string.IsNullOrWhiteSpace(mataKuliah))
        {
            throw new ArgumentException("Mata kuliah tidak boleh kosong.");
        }
        MataKuliah = mataKuliah;
        BatasPinjam = 5;
    }

    // Level 6: InfoAsisten
    public string InfoAsisten()
    {
        return $"{InfoLengkap()} | Asisten: {MataKuliah}";
    }
}