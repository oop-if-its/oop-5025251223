using System;
using System.Collections.Generic;

namespace ProyekBankMini
{
    public class Transaksi
    {
        public DateTime Waktu { get; }
        public string Jenis { get; }
        public decimal Jumlah { get; }

        public Transaksi(string jenis, decimal jumlah)
        {
            Waktu = DateTime.Now;
            Jenis = jenis;
            Jumlah = jumlah;
        }

        public override string ToString() => $"[{Waktu:yyyy-MM-dd HH:mm}] {Jenis}: Rp {Jumlah:N0}";
    }

    public abstract class Rekening
    {
        private string _nomorRekening;
        private decimal _saldo;
        private List<Transaksi> _riwayatTransaksi;

        public string NomorRekening 
        { 
            get => _nomorRekening; 
            private set => _nomorRekening = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Nomor rekening tidak boleh kosong.") : value; 
        }

        public decimal Saldo 
        { 
            get => _saldo; 
            protected set => _saldo = value < 0 ? throw new ArgumentException("Saldo tidak boleh negatif.") : value; 
        }

        public IReadOnlyList<Transaksi> RiwayatTransaksi => _riwayatTransaksi.AsReadOnly();

        protected Rekening(string nomorRekening, decimal saldoAwal)
        {
            NomorRekening = nomorRekening;
            _riwayatTransaksi = new List<Transaksi>();
            Setor(saldoAwal, "Setor Awal");
        }

        public void Setor(decimal jumlah, string keterangan = "Setor Tunai")
        {
            if (jumlah <= 0) throw new ArgumentException("Jumlah setor harus lebih dari 0.");
            Saldo += jumlah;
            _riwayatTransaksi.Add(new Transaksi(keterangan, jumlah));
        }

        // Method pembantu agar kelas turunan (seperti Giro/Tabungan) bisa mencatat riwayat penarikan
        protected void CatatTransaksi(string keterangan, decimal jumlah)
        {
            _riwayatTransaksi.Add(new Transaksi(keterangan, jumlah));
        }

        public abstract decimal Tarik(decimal jumlah);
        public abstract decimal HitungBunga();

        public override string ToString() => $"{GetType().Name} ({NomorRekening}) - Saldo: Rp {Saldo:N0}";
    }
}
