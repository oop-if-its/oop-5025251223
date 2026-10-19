// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan06;

// Overloading (dipilih oleh KOMPILATOR berdasarkan tipe variabel) berbeda dari
// overriding (dipilih saat PROGRAM BERJALAN berdasarkan tipe objek sebenarnya).
public class Pemroses
{
    public string Proses(Item item)
    {
        // TODO(Level 9): kembalikan "Item: <Judul>".
        //catatan say: Overloading method Proses untuk Item (Level 9)
        if (item == null) throw new ArgumentNullException(nameof(item));
        return $"Item: {item.Judul}";
    }

    public string Proses(Buku buku)
    {
        // TODO(Level 9): kembalikan "Buku: <Judul>".
        //catatan say: Overloading method Proses untuk Buku (Level 9)
        if (buku == null) throw new ArgumentNullException(nameof(buku));
        return $"Buku: {buku.Judul}";
    }

    public string Proses(Majalah majalah)
    {
        // TODO(Level 9): kembalikan "Majalah: <Judul>".
        //catatan say: Overloading method Proses untuk Majalah (Level 9)
        if (majalah == null) throw new ArgumentNullException(nameof(majalah));
        return $"Majalah: {majalah.Judul}";
    }

    public string Kategori(Item item)
    {
        // TODO(Level 9): null -> ArgumentNullException. Pakai switch EXPRESSION
        //   dengan type pattern: Buku -> "Buku", Majalah -> "Majalah", Dvd ->
        //   "DVD", selain itu (Item biasa) -> "Item".
        //catatan say: Switch expression dengan type pattern untuk menentukan kategori (Level 9)
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        return item switch
        {
            Buku => "Buku",
            Majalah => "Majalah",
            Dvd => "DVD",
            _ => "Item"
        };
    }
}
