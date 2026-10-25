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
- Diubah: disesuaikan dengan nama _custom exception_ yang saya tentukan sendiri.

## Kerangka Kode Model Objek (OOP) Bank Mini

- Prompt: "buatkan kerangka kode C# untuk kelas abstrak Rekening, Tabungan, Deposito, Nasabah, dan Exceptions sesuai prinsip PBO"
- Dipakai: berkas `Exceptions.cs`, `Rekening.cs`, `Tabungan.cs`, `Deposito.cs`, dan `Nasabah.cs`
- Diubah: gaada yg diubah si.., disalin tapi juga dipahamin biar pas ujian lisan gak ngang ngong banget:)
