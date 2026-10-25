namespace Pertemuan06;

public class Item
{
    public string Judul { get; }

    public Item(string judul)
    {
        if (string.IsNullOrWhiteSpace(judul))
            throw new ArgumentException("Judul tidak boleh kosong.", nameof(judul));
        Judul = judul;
    }

    // TODO(Level 2): jadikan method ini `virtual` supaya bisa di-override (lalu tulis override-nya di Buku, Majalah, Dvd).
    // Catatan say: Wajib pakai `virtual` di sini supaya method-nya bisa ditimpa (override) di kelas anak (Polimorfisme).
    public virtual int HitungDenda(int hariTerlambat)
    {
        // TODO(Level 1): denda umum = Rp1.000 per hari terlambat. hariTerlambat <= 0 -> 0.
        if (hariTerlambat <= 0) return 0;
        return hariTerlambat * 1000;
    }

    // TODO(Level 4): jadikan properti ini `virtual`, lalu override di Buku (14), Majalah (3), dan Dvd (2).
    public virtual int MasaPinjamHari => 7;

    // TODO(Level 5): jadikan `virtual`; override di Buku/Majalah/Dvd dengan MEMANGGIL versi induk lewat base.Deskripsi() lalu menambahkan detailnya.
    public virtual string Deskripsi()
    {
        // TODO(Level 5): kembalikan "[<Judul>]" -- mis. "[Bumi Manusia]".
        return $"[{Judul}]";
    }

    public override string ToString()
    {
        // TODO(Level 5): kembalikan Deskripsi() (dipanggil secara polimorfik -- jenis objek yang sebenarnya menentukan hasilnya).
        return Deskripsi();
    }

    // TODO(Level 10 (bonus)): override Equals(object?) dan GetHashCode(): dua Item dianggap SAMA bila jenis (GetType()) sama DAN Judul sama (huruf besar/kecil diabaikan). GetHashCode harus konsisten dengan Equals.
    public override bool Equals(object? obj)
    {
        if (obj is not Item other)
            return false;

        return GetType() == other.GetType() &&
               string.Equals(Judul, other.Judul, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType(), Judul.ToLowerInvariant());
    }
}