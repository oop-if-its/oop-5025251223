using System;

namespace ProyekBankMini
{
    public class Deposito : Rekening
    {
        public bool SudahJatuhTempo { get; set; } = false;

        public Deposito(string nomorRekening, decimal saldoAwal) : base(nomorRekening, saldoAwal) { }

        public override decimal Tarik(decimal jumlah)
        {
            decimal totalPotong = jumlah;
            if (!SudahJatuhTempo)
            {
                // Penalti 10% jika ditarik sebelum jatuh tempo
                totalPotong += jumlah * 0.10m; 
            }

            if (Saldo < totalPotong) throw new SaldoTidakCukupException("Saldo deposito tidak cukup (termasuk penalti)!");

            Saldo -= totalPotong;
            return Saldo;
        }

        public override decimal HitungBunga()
        {
            // Bunga deposito 5%
            return Saldo * 0.05m;
        }
    }
}