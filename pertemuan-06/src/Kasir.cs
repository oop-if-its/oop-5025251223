namespace Pertemuan06;

public record Peminjaman(Item Item, int HariTerlambat);

public class Kasir
{
    public int TotalDenda(IEnumerable<Peminjaman> daftar)
    {
        // TODO(Level 6): null -> ArgumentNullException; jumlahkan p.Item.HitungDenda(p.HariTerlambat) untuk semua peminjaman. JANGAN memeriksa jenis item (tidak boleh ada if/is/switch atas tipe) -- biarkan polimorfisme bekerja.
        if (daftar == null)
            throw new ArgumentNullException(nameof(daftar));

        int total = 0;
        foreach (var p in daftar)
        {
            // Catatan say: Di sini Kasir gak perlu tahu apakah item itu Buku/Majalah/DVD, cukup panggil method-nya dan polimorfisme C# yang otomatis nentuin rumus denda yang bener!
            total += p.Item.HitungDenda(p.HariTerlambat);
        }
        return total;
    }

    public Item? ItemDenganDendaTertinggi(IEnumerable<Peminjaman> daftar)
    {
        // TODO(Level 6): null -> ArgumentNullException; kembalikan Item dengan denda TERTINGGI (kalau seri, ambil yang pertama muncul); daftar kosong -> null.
        if (daftar == null)
            throw new ArgumentNullException(nameof(daftar));

        Item? itemTertinggi = null;
        int dendaTertinggi = -1;

        foreach (var p in daftar)
        {
            int denda = p.Item.HitungDenda(p.HariTerlambat);
            if (denda > dendaTertinggi)
            {
                dendaTertinggi = denda;
                itemTertinggi = p.Item;
            }
        }
        return itemTertinggi;
    }
}