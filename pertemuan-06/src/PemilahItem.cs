namespace Pertemuan06;

public static class PemilahItem
{
    public static List<Buku> AmbilBuku(IEnumerable<Item> daftar)
    {
        // TODO(Level 7): null -> ArgumentNullException; kembalikan hanya item yang bertipe Buku (urutan asli dipertahankan). Boleh dengan `is`/`as` di dalam foreach atau OfType<Buku>().
        if (daftar == null)
            throw new ArgumentNullException(nameof(daftar));

        return daftar.OfType<Buku>().ToList();
    }

    public static string? PenulisAtauNull(Item item)
    {
        // TODO(Level 7): kembalikan Penulis kalau item adalah Buku, selain itu null. Pakai pattern matching `is Buku b`.
        // Catatan say: Pattern matching `item is Buku b` langsung ngecek tipe sekaligus casting variabel `b` dalam satu baris. Canggih kan!
        return item is Buku b ? b.Penulis : null;
    }

    public static Buku KeBuku(Item item)
    {
        // TODO(Level 8): item null -> ArgumentNullException. Selain itu lakukan EXPLICIT CAST `(Buku)item` -- kalau item bukan Buku, biarkan .NET melempar InvalidCastException (jangan ditangkap, jangan diganti pesan sendiri).
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        return (Buku)item;
    }

    public static bool CobaKeBuku(Item? item, out Buku? buku)
    {
        // TODO(Level 8): pola TryXxx -- kembalikan true dan isi `buku` kalau item adalah Buku; selain itu (termasuk item null) kembalikan false dan isi `buku` = null. TIDAK boleh melempar exception.
        if (item is Buku b)
        {
            buku = b;
            return true;
        }
        buku = null;
        return false;
    }
}