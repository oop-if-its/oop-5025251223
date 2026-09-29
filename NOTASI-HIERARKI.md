# Diagram Hierarki Kelas (UML) — Perpustakaan

Gambarkan diagram UML yang menunjukkan **hubungan antar kelas** di pertemuan ini, di bagian **bawah** penanda di akhir berkas ini. Format bebas — boleh kotak ASCII/Mermaid (`classDiagram`) atau daftar bertingkat. Yang wajib ada:

- Kelas `Anggota`, `Mahasiswa`, `Dosen`, `Asisten`, `Alamat`, dan `LogAktivitas`.
- Hubungan **pewarisan** (*is-a*): panah segitiga kosong dari kelas turunan ke kelas induk (`<|--` di Mermaid, atau `▲`, atau tulis "extends"/"turunan dari").
- Hubungan **komposisi** (*has-a*): berlian terisi dekat pihak pemilik (`*--` di Mermaid, atau `◆`, atau tulis "komposisi"/"memiliki") — siapa memiliki siapa?
- Anggota `protected` ditandai dengan simbol `#` (mis. `# BatasPinjam`), `public` dengan `+`, `private` dengan `-`.

Contoh format Mermaid (untuk kelas lain, bukan jawaban):

```mermaid
classDiagram
    Kendaraan <|-- Mobil
    Mobil *-- Mesin
    class Kendaraan {
        + Merek : string
        # kecepatan : int
    }
```

Jangan hapus baris penanda di bawah ini — jawaban kalian harus ditulis **setelah** baris itu, bukan sebelumnya.

<!-- TULIS JAWABAN KALIAN DI BAWAH BARIS INI -->

```mermaid
classDiagram
    %% Hubungan Pewarisan (Inheritance / is-a)
    Anggota <|-- Mahasiswa : mewarisi (is-a)
    Anggota <|-- Dosen : mewarisi (is-a)
    Mahasiswa <|-- Asisten : mewarisi (is-a)

    %% Hubungan Komposisi (Composition / has-a)
    Anggota *-- Alamat : memiliki (komposisi)
    Anggota *-- LogAktivitas : memiliki (komposisi)

    class Alamat {
        + Jalan : string
        + Kota : string
        + Alamat(jalan: string, kota: string)
        + ToString() string
    }

    class LogAktivitas {
        - _entri : List~string~
        + Semua : IReadOnlyList~string~
        + Catat(pesan: string) void
    }

    class Anggota {
        + Id : string
        + Nama : string
        + Alamat : Alamat
        # BatasPinjam : int
        + JumlahPinjam : int
        - _log : LogAktivitas
        + Riwayat : IReadOnlyList~string~
        + Anggota(id: string, nama: string, alamat: Alamat)
        + Info() string
        + Pinjam(judul: string) void
    }

    class Mahasiswa {
        + Nrp : string
        + Prodi : string
        + Mahasiswa(id: string, nama: string, alamat: Alamat, nrp: string, prodi: string)
        + InfoLengkap() string
    }

    class Dosen {
        + Nip : string
        + Dosen(id: string, nama: string, alamat: Alamat, nip: string)
        + InfoLengkap() string
    }

    class Asisten {
        + MataKuliah : string
        + Asisten(id: string, nama: string, alamat: Alamat, nrp: string, prodi: string, mataKuliah: string)
        + InfoAsisten() string
    }
```

### Penjelasan Hubungan Antar Kelas

1. **Hubungan Pewarisan (*is-a* / Inheritance)**:
   - Simbol panah segitiga kosong (`<|--`): Menunjukkan kelas turunan mewarisi atribut dan perilaku dari kelas induk.
   - `Mahasiswa` adalah turunan dari (`extends` / mewarisi) `Anggota`.
   - `Dosen` adalah turunan dari (`extends` / mewarisi) `Anggota`.
   - `Asisten` adalah turunan bertingkat dari (`extends` / mewarisi) `Mahasiswa` (sehingga `Asisten` secara transitif juga *is-a* `Anggota`). Kelas ini bersifat `sealed`.

2. **Hubungan Komposisi (*has-a* / Composition)**:
   - Simbol wajik terisi (`*--`): Menunjukkan kepemilikan kuat (komposisi), di mana masa hidup objek komponen bergantung pada objek pemilik.
   - `Anggota` memiliki objek `Alamat` (`Anggota *-- Alamat`).
   - `Anggota` memiliki objek `LogAktivitas` secara privat dan independen per instance (`Anggota *-- LogAktivitas`).

3. **Simbol Visibilitas Anggota Kelas**:
   - `+` menandakan akses **`public`** (dapat diakses dari luar kelas).
   - `#` menandakan akses **`protected`** (dapat diakses oleh kelas itu sendiri dan kelas-kelas turunannya, seperti `# BatasPinjam`).
   - `-` menandakan akses **`private`** (hanya dapat diakses di dalam kelas yang mendefinisikannya, seperti field `_log` dan `_entri`).

