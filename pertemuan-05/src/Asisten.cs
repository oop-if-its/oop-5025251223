namespace Pertemuan05;


//catatan say: Kelas Asisten diturunkan dari Mahasiswa dan disegel (sealed)
public sealed class Asisten : Mahasiswa
{
    public string MataKuliah { get; }

    public Asisten(string id, string nama, Alamat alamat, string nrp, string prodi, string mataKuliah) 
        : base(id, nama, alamat, nrp, prodi)
    {
        if (string.IsNullOrWhiteSpace(mataKuliah))
            throw new ArgumentException("Mata kuliah tidak boleh kosong.", nameof(mataKuliah));

        MataKuliah = mataKuliah;
        
        //catatan say: Batas pinjam khusus Asisten adalah 5
        BatasPinjam = 5;
    }

    //catatan say: InfoAsisten() mengembalikan informasi lengkap beserta mata kuliah
    public string InfoAsisten()
    {
        return $"{InfoLengkap()} | Asisten: {MataKuliah}";
    }
}
