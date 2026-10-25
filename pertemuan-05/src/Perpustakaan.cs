using System.Collections.Generic;
using System.Linq;

namespace Pertemuan05;

public class Perpustakaan
{
    public List<Anggota> DaftarAnggota { get; set; } = new List<Anggota>();
    public int JumlahAnggota => DaftarAnggota.Count;

    // Level 8: Menghitung Mahasiswa (termasuk Asisten karena Asisten adalah turunan Mahasiswa)
    public int JumlahMahasiswa() => DaftarAnggota.OfType<Mahasiswa>().Count();
    
    // Level 8: Menghitung Dosen
    public int JumlahDosen() => DaftarAnggota.OfType<Dosen>().Count();

    // Level 8: Daftarkan anggota dengan validasi
    public void Daftarkan(Anggota anggota)
    {
        ArgumentNullException.ThrowIfNull(anggota);
        if (DaftarAnggota.Any(a => a.Id == anggota.Id))
        {
            throw new InvalidOperationException("ID anggota sudah terdaftar.");
        }
        DaftarAnggota.Add(anggota);
    }

    // Level 8: Cari anggota berdasarkan ID, NRP, atau NIP
    public Anggota Cari(string id)
    {
        return DaftarAnggota.FirstOrDefault(a => a.Id == id || (a is Mahasiswa m && m.Nrp == id) || (a is Dosen d && d.Nip == id));
    }
}