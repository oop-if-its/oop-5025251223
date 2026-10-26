# AI-LOG

Catat setiap penggunaan AI yang menghasilkan kode. Satu entri per penggunaan. Tulis "tidak memakai AI" jika memang tidak.
Log yang jujur tidak mengurangi nilai; log yang tidak sesuai dengan kode, atau isi log yang tidak bisa dijelaskan, yang mengurangi nilai.

## Contoh format (hapus contoh ini)

## Denda keterlambatan (aturan khas)

- Prompt: "buat interface kebijakan denda dan dua implementasinya untuk rental kendaraan"
- Dipakai: `IKebijakanDenda`, `DendaFlat` di Denda.cs
- Diubah: hasil AI menaruh `new DendaFlat()` langsung di `Penyewaan`; saya pindah ke parameter konstruktor (DI)

## Entri saya

## Struktur Diagram Kelas Mermaid untuk README

- Prompt: "bantu buatkan sintaks mermaid class diagram untuk proyek Bank Mini dengan kelas Rekening, Tabungan, Deposito, Nasabah, dan Custom Exception"
- Dipakai: blok kode diagram kelas di dalam `README.md`
- Diubah: disesuaikan dengan nama _custom exception_ yang saya tentukan sendiri

## Kerangka Kode Model Objek (OOP) Bank Mini

- Prompt: "buatkan kerangka kode C# untuk kelas abstrak Rekening, Tabungan, Deposito, Nasabah, dan Exceptions sesuai prinsip PBO"
- Dipakai: berkas `Exceptions.cs`, `Rekening.cs`, `Tabungan.cs`, `Deposito.cs`, dan `Nasabah.cs`
- Diubah: menyalin & memahami ulang bagian _try-catch rollback_ pada fungsi transfer biar gak ngang ngong pas ujian lisan:)

## Implementasi Kelas Giro & Penyesuaian Method Tarik

- Prompt: "bagaimana cara mengimplementasikan kelas Giro dengan fitur overdraft di C# dan menyamakan tipe return method Tarik?"
- Dipakai: struktur kelas `Giro.cs` serta penyesuaian tipe kembalian `decimal` pada method `Tarik` di kelas `Rekening`
- Diubah: menyesuaikan penanganan exception dan pencatatan riwayat transaksi agar cocok dengan arsitektur yang sudah dibuat

## Perbaikan Error Kompilasi & Kelas Giro

- Prompt: "fix error C# return type must be decimal untuk method Tarik di kelas turunan dan cara nambahin fitur overdraft di giro"
- Dipakai: solusi penyesuaian tipe data kembalian method `Tarik` dan logika pengecekan _overdraft_ di `Giro.cs`
- Diubah: menyesuaikan method pembantu pencatatan transaksi di `Rekening.cs` dan merapikan skenario pengujian di `Program.cs`
