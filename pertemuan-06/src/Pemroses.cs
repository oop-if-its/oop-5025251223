namespace Pertemuan06;

public class Pemroses
{
    public string Proses(Item item)
    {
        // TODO(Level 9): kembalikan "Item: <Judul>".
        return $"Item: {item?.Judul}";
    }

    public string Proses(Buku buku)
    {
        // TODO(Level 9): kembalikan "Buku: <Judul>".
        return $"Buku: {buku?.Judul}";
    }

    public string Proses(Majalah majalah)
    {
        // TODO(Level 9): kembalikan "Majalah: <Judul>".
        return $"Majalah: {majalah?.Judul}";
    }

    public string Kategori(Item item)
    {
        // TODO(Level 9): null -> ArgumentNullException. Pakai switch EXPRESSION dengan type pattern: Buku -> "Buku", Majalah -> "Majalah", Dvd -> "DVD", selain itu (Item biasa) -> "Item".
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        // Catatan say: Switch expression modern C# pakai type pattern (`Buku => ...`) jauh lebih bersih ketimbang if-else bertumpuk.
        return item switch
        {
            Buku => "Buku",
            Majalah => "Majalah",
            Dvd => "DVD",
            _ => "Item"
        };
    }
}