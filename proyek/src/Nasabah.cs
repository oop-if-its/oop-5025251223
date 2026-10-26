using System;
using System.Collections.Generic;

namespace ProyekBankMini
{
    public class Nasabah
    {
        private List<Rekening> _daftarRekening = new List<Rekening>();
        public string Nama { get; }
        public IReadOnlyList<Rekening> DaftarRekening => _daftarRekening.AsReadOnly();

        public Nasabah(string nama)
        {
            Nama = nama;
        }

        public void TambahRekening(Rekening rekening)
        {
            _daftarRekening.Add(rekening);
        }

        public Rekening CariRekening(string noRek)
        {
            foreach (var rek in _daftarRekening)
            {
                if (rek.NomorRekening == noRek) return rek;
            }
            throw new RekeningBelumTerdaftarException($"Rekening dengan nomor {noRek} tidak terdaftar!");
        }

        // Transfer aman (try/catch semua-atau-tidak-sama-sekali)
        public void Transfer(string noRekAsal, string noRekTujuan, decimal jumlah)
        {
            Rekening asal = CariRekening(noRekAsal);
            Rekening tujuan = CariRekening(noRekTujuan);

            try
            {
                // Tarik dari asal
                asal.Tarik(jumlah);
                // Setor ke tujuan
                tujuan.Setor(jumlah, $"Transfer Masuk dari {asal.NomorRekening}");
                Console.WriteLine("Transfer berhasil dilakukan!");
            }
            catch (Exception)
            {
                // Rollback manual jika terjadi error di tengah proses
                asal.Setor(jumlah, "Rollback Gagal Transfer");
                Console.WriteLine("Transfer gagal! Saldo dikembalikan seperti semula.");
                throw;
            }
        }
    }
}
