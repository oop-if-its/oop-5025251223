using System;
using System.Collections.Generic;
using System.Linq;


namespace Pertemuan05;

public class Perpustakaan
{
    public List<Anggota> DaftarAnggota { get; set; } = new List<Anggota>();

    public int JumlahAnggota => DaftarAnggota.Count;

    //catatan say: Menghitung jumlah Mahasiswa termasuk Asisten karena Asisten adalah turunan Mahasiswa
    public int JumlahMahasiswa() => DaftarAnggota.OfType<Mahasiswa>().Count();

    //catatan say: Menghitung jumlah Dosen
    public int JumlahDosen() => DaftarAnggota.OfType<Dosen>().Count();

    public void Daftarkan(Anggota anggota)
    {
        if (anggota == null)
            throw new ArgumentNullException(nameof(anggota), "Anggota tidak boleh null.");
        
        if (DaftarAnggota.Any(a => a.Id == anggota.Id))
            throw new InvalidOperationException("ID anggota sudah terdaftar.");

        DaftarAnggota.Add(anggota);
    }

    public Anggota Cari(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        return DaftarAnggota.FirstOrDefault(a => a.Id == id);
    }
}
