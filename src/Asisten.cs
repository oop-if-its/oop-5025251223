namespace Pertemuan05;

// Pewarisan bertingkat: Asisten "adalah sebuah" Mahasiswa, yang "adalah sebuah" Anggota.
// Kelas ini disegel (sealed) sehingga tidak dapat diturunkan lagi.
public sealed class Asisten : Mahasiswa
{
    public string MataKuliah { get; }

    public Asisten(string id, string nama, Alamat alamat, string nrp, string prodi, string mataKuliah)
        : base(id, nama, alamat, nrp, prodi)
    {
        if (string.IsNullOrWhiteSpace(mataKuliah))
            throw new ArgumentException("Mata kuliah tidak boleh kosong.", nameof(mataKuliah));

        MataKuliah = mataKuliah;
        BatasPinjam = 5;
    }

    public string InfoAsisten()
    {
        return $"{InfoLengkap()} | Asisten: {MataKuliah}";
    }
}
