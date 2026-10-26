# PROSES

Berkas ini menjadi bahan utama ujian lisan. Tulis dengan kata-kata sendiri.

## 1. Domain dan masalahnya

Domain yang didapat adalah Bank Mini, yang memodelkan pengelolaan rekening nasabah(whenyh nasabah prio BCA)-(Tabungan dan Deposito), penyetoran, penarikan, serta transfer antar rekening. Masalah utama yang diselesaikan adalah bagaimana memastikan keamanan data (enkapsulasi saldo agar tidak bisa diubah sembarangan atau bernilai negatif), aturan penarikan khusus (seperti penalti pada deposito jika ditarik sebelum jatuh tempo), serta konsistensi data saat melakukan transfer (prinsip all-or-nothing agar saldo tidak berkurang sebelah jika terjadi kegagalan di tengah proses)

## 2. Rancangan kelas

Kelas apa saja, siapa mewarisi siapa, siapa memiliki siapa, dan mengapa dirancang begitu.

- Rekening: Kelas induk abstrak (abstract class) yang memiliki atribut privat `_nomorRekening` dan `_saldo`, serta menyimpan `List<Transaksi>` riwayat transaksi.
- Tabungan: Kelas turunan dari `Rekening` yang mengimplementasikan metode `Tarik()` secara normal dan `HitungBunga()` sebesar 2%.
- Deposito: Kelas turunan dari `Rekening` yang mengimplementasikan metode `Tarik()` dengan aturan penalti 10% jika ditarik sebelum jatuh tempo, serta `HitungBunga()` sebesar 5%.
- Nasabah: Kelas yang menampung komposisi banyak rekening (`List<Rekening>`) dan mengatur logika transfer dana antar rekening milik nasabah tersebut.
- Exceptions: Kelas kustom seperti `SaldoTidakCukupException` dan `RekeningBelumTerdaftarException` untuk menangani kesalahan spesifik.

## 3. Satu keputusan desain dan alasannya

Contoh: memilih interface atau abstract class untuk suatu hal, mengapa.

Memilih menggunakan **abstract class (`Rekening`)** daripada _interface_. Alasannya karena kelas `Rekening` punya data yang sama persis untuk semua jenis rekening, seperti nomor rekening, saldo, dan riwayat transaksi. Jadi, fungsi dasar seperti setor uang dan simpan riwayat bisa ditulis sekali saja di kelas induk supaya tidak perlu menulis ulang kodenya, sedangkan fungsi tarik dan hitung bunga dibiarkan abstrak agar bisa diatur beda-beda sesuai jenis rekeningnya (Tabungan atau Deposito).

## 4. Bug atau kendala (minimal dua)

Untuk tiap kendala: apa yang terjadi, bagaimana menemukan penyebabnya, bagaimana memperbaikinya.

1. Kendala saat transfer uang:
   - _Apa yang terjadi:_ Waktu transfer saldo dari satu rekening ke rekening lain, saldo rekening pengirim sempat terlanjur terpotong duluan padahal gagal masuk ke rekening tujuan.
   - _Cara menemukan:_ Mengecek alur jalannya program saat proses tarik saldo berhasil tapi langkah setor berikutnya error.
   - _Cara memperbaiki:_ Memakai blok `try-catch`. Jadi kalau di tengah jalan ada error, kodenya otomatis mengembalikan uang ke rekening asal pakai fungsi setor (_rollback_).

2. Kendala keamanan saldo agar tidak minus:
   - _Apa yang terjadi:_ Nilai saldo awalnya sempat bisa diubah sembarangan dari luar kelas karena memakai properti publik biasa.
   - _Cara menemukan:_ Menyadari aturan dasar enkapsulasi di PBO di mana data penting harus dilindungi.
   - _Cara memperbaiki:_ Mengubah status pengaturnya menjadi `protected set` dan menambahkan pengecekan jika nilainya kurang dari 0, program akan langsung menolak dan memunculkan pesan error.
