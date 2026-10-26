// Titik masuk aplikasi. Ganti isi berkas ini dengan demo (menu atau skenario berurutan)
// yang memperlihatkan semua aturan khas domain kalian, termasuk skenario gagal yang
// ditangani exception. Kelas-kelas domain ditulis di berkas terpisah.
using System;

namespace ProyekBankMini
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== APLIKASI BANK MINI ===");
            Console.WriteLine("Nasabah: Sayyidah Fatimah Azzahrah Rakhmatullah (5025251223)\n");

            // 1. Buat Nasabah
            Nasabah nasabah = new Nasabah("Sayyidah");

            // 2. Tambah 3 Jenis Rekening (Tabungan, Deposito, Giro)
            Tabungan tabungan1 = new Tabungan("TRK-001", 1000000);
            Deposito deposito1 = new Deposito("DEP-002", 5000000);
            Giro giro1 = new Giro("GRO-003", 500000, 300000); // Saldo 500rb, Overdraft 300rb

            nasabah.TambahRekening(tabungan1);
            nasabah.TambahRekening(deposito1);
            nasabah.TambahRekening(giro1);

            // 3. Tampilkan Rekening Awal
            Console.WriteLine("--- Daftar Rekening Awal ---");
            foreach (var rek in nasabah.DaftarRekening)
            {
                Console.WriteLine(rek);
            }

            // 4. Coba Setor & Tarik Tunai Normal
            Console.WriteLine("\n--- Simulasi Setor & Tarik ---");
            tabungan1.Setor(250000);
            Console.WriteLine($"Setelah setor ke Tabungan: Saldo = Rp {tabungan1.Saldo:N0}");

            tabungan1.Tarik(300000);
            Console.WriteLine($"Setelah tarik dari Tabungan: Saldo = Rp {tabungan1.Saldo:N0}");

            // 5. Uji Coba Fitur Overdraft pada Giro
            Console.WriteLine("\n--- Simulasi Overdraft Giro ---");
            try
            {
                giro1.Tarik(700000); 
                Console.WriteLine($"Berhasil tarik melebihi saldo via overdraft! Sisa saldo Giro: Rp {giro1.Saldo:N0}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // 6. Uji Coba Skenario Gagal (Exception Kustom: SaldoTidakCukupException)
            Console.WriteLine("\n--- Simulasi Gagal (Saldo Tidak Cukup) ---");
            try
            {
                tabungan1.Tarik(5000000); // Melebihi saldo tabungan
            }
            catch (SaldoTidakCukupException ex)
            {
                Console.WriteLine($"Tertangkap Exception: {ex.Message}");
            }

            // 7. Uji Coba Skenario Gagal (Exception Kustom: RekeningBelumTerdaftarException)
            Console.WriteLine("\n--- Simulasi Gagal (Rekening Tujuan Tidak Ada) ---");
            try
            {
                nasabah.Transfer("TRK-001", "SALAH-999", 100000);
            }
            catch (RekeningBelumTerdaftarException ex)
            {
                Console.WriteLine($"Tertangkap Exception: {ex.Message}");
            }

            // 8. Coba Transfer Aman (All-or-Nothing yang Berhasil)
            Console.WriteLine("\n--- Simulasi Transfer Sukses (All-or-Nothing) ---");
            try
            {
                nasabah.Transfer("TRK-001", "DEP-002", 200000);
                Console.WriteLine("Transfer berhasil dilakukan dengan aman!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // 9. Tampilkan Hasil Akhir & Riwayat Transaksi
            Console.WriteLine("\n--- Kondisi Rekening & Riwayat Akhir ---");
            foreach (var rek in nasabah.DaftarRekening)
            {
                Console.WriteLine(rek);
                Console.WriteLine("Riwayat Transaksi:");
                foreach (var t in rek.RiwayatTransaksi)
                {
                    Console.WriteLine($"  - {t}");
                }
                Console.WriteLine();
            }
        }
    }
}
