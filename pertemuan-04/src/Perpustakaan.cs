// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan04;

public class Perpustakaan
{
    // TODO(Level 7): koleksi di bawah ini PUBLIK -- pihak luar bisa Add/Clear
    //   seenaknya, melewati aturan Tambah(). Simpan daftar di field PRIVATE
    //   (List<Buku>) dan ekspos DaftarBuku sebagai properti read-only bertipe
    //   IReadOnlyList<Buku> (atau IReadOnlyCollection/IEnumerable) yang tidak
    //   bisa dipakai untuk mengubah koleksi asli.
    
    // SAY: List aslinya dibikin private pakai underscore (_) biar aman dari luar. Terus kita ekspos pakai 'AsReadOnly()' lewat properti DaftarBuku 
    // supaya orang luar cuma bisa baca doang, gak bisa asal .Add() atau .Clear() seenaknya.
    private readonly List<Buku> _daftarBuku = new();

    public IReadOnlyList<Buku> DaftarBuku => _daftarBuku.AsReadOnly();

    public int JumlahJudul => _daftarBuku.Count;

    public void Tambah(Buku buku)
    {
        // TODO(Level 7): buku null -> ArgumentNullException; ISBN yang sudah ada
        //   di koleksi -> InvalidOperationException; selain itu tambahkan ke
        //   koleksi.
        
        // SAY: Sebelum nambahin buku, kita validasi dulu: 
        // 1. Kalau objek bukunya null, lempar ArgumentNullException.
        // 2. Kalau ISBN-nya udah pernah terdaftar di list, lempar InvalidOperationException.
        if (buku == null)
        {
            throw new ArgumentNullException(nameof(buku), "Buku tidak boleh null.");
        }

        if (_daftarBuku.Any(b => b.Isbn == buku.Isbn))
        {
            throw new InvalidOperationException("Buku dengan ISBN yang sama sudah terdaftar.");
        }

        _daftarBuku.Add(buku);
    }

    public Buku? Cari(string isbn)
    {
        // TODO(Level 7): kembalikan buku dengan Isbn yang sama persis (apa
        //   adanya, tanpa normalisasi), atau null kalau tidak ada.
        
        // SAY: Cari buku di dalam list yang ISBN-nya persis sama kayak parameter. 
        // Kalau ketemu dikembalikan objek bukunya, kalau gak ketemu bakal return null (makanya tipe balikannya Buku?).
        return _daftarBuku.FirstOrDefault(b => b.Isbn == isbn);
    }

    public void PinjamBuku(string isbn, AkunAnggota akun)
    {
        // TODO(Level 10): "Tell, don't ask" -- Perpustakaan memutuskan semuanya.
        //   akun null -> ArgumentNullException; ISBN tidak ada ->
        //   ArgumentException; akun.Denda > 0 -> InvalidOperationException;
        //   akun.JumlahPinjamanAktif sudah sama dengan AkunAnggota.MaksPinjaman
        //   -> InvalidOperationException; selain itu panggil buku.Pinjam()
        //   (boleh melempar kalau stok habis) lalu akun.CatatPinjam().
        
        // SAY: Prinsip "Tell, Don't Ask" artinya kelas Perpustakaan yang ngecek semua aturan mainnya di sini. Urutannya:
        // 1. Cek akun null -> lempar ArgumentNullException.
        // 2. Cari bukunya, kalau gak ketemu -> lempar ArgumentException.
        // 3. Cek apakah akun punya denda (Denda > 0) -> lempar InvalidOperationException.
        // 4. Cek apakah pinjaman aktif udah mentok (>= MaksPinjaman/3) -> lempar InvalidOperationException.
        // Kalau semua syarat lolos, baru jalankan buku.Pinjam() dan catat di akun.
        if (akun == null)
        {
            throw new ArgumentNullException(nameof(akun), "Akun anggota tidak boleh null.");
        }

        Buku? buku = Cari(isbn);
        if (buku == null)
        {
            throw new ArgumentException("Buku dengan ISBN tersebut tidak ditemukan.", nameof(isbn));
        }

        if (akun.Denda > 0)
        {
            throw new InvalidOperationException("Anggota masih memiliki denda yang belum dibayar.");
        }

        if (akun.JumlahPinjamanAktif >= AkunAnggota.MaksPinjaman)
        {
            throw new InvalidOperationException("Jumlah pinjaman aktif sudah mencapai batas maksimal.");
        }

        buku.Pinjam();
        akun.CatatPinjam();
    }

    public void KembalikanBuku(string isbn, AkunAnggota akun)
    {
        // TODO(Level 10): akun null -> ArgumentNullException; ISBN tidak ada ->
        //   ArgumentException; akun.JumlahPinjamanAktif = 0 ->
        //   InvalidOperationException; selain itu panggil buku.Kembalikan() lalu
        //   akun.CatatKembali().
        
        // SAY: Mirip kayak pinjam, tapi ini buat proses pengembalian:
        // 1. Cek akun null.
        // 2. Cek buku ada atau gak.
        // 3. Cek apakah emang punya pinjaman aktif (JumlahPinjamanAktif > 0), kalau 0 ya gak bisa balikin buku.
        // Kalau aman, panggil buku.Kembalikan() dan catat pengembaliannya di akun.
        if (akun == null)
        {
            throw new ArgumentNullException(nameof(akun), "Akun anggota tidak boleh null.");
        }

        Buku? buku = Cari(isbn);
        if (buku == null)
        {
            throw new ArgumentException("Buku dengan ISBN tersebut tidak ditemukan.", nameof(isbn));
        }

        if (akun.JumlahPinjamanAktif <= 0)
        {
            throw new InvalidOperationException("Anggota tidak memiliki pinjaman aktif.");
        }

        buku.Kembalikan();
        akun.CatatKembali();
    }
}
