using System;

namespace ProyekBankMini
{
    public class Giro : Rekening
    {
        public decimal BatasOverdraft { get; private set; }

        public Giro(string nomorRekening, decimal saldoAwal, decimal batasOverdraft) 
            : base(nomorRekening, saldoAwal)
        {
            if (batasOverdraft < 0)
                throw new ArgumentException("Batas overdraft tidak boleh negatif.");
            BatasOverdraft = batasOverdraft;
        }

        public override decimal Tarik(decimal jumlah)
        {
            if (jumlah <= 0)
                throw new ArgumentException("Jumlah penarikan harus lebih dari nol.");

            if (jumlah > Saldo + BatasOverdraft)
            {
                throw new SaldoTidakCukupException($"Penarikan Giro gagal. Saldo dan batas overdraft tidak mencukupi untuk menarik {jumlah:C}.");
            }

            Saldo -= jumlah;
            CatatTransaksi("Tarik Giro (Overdraft)", jumlah);
            return Saldo;
        }

        public override decimal HitungBunga()
        {
            return Saldo > 0 ? Saldo * 0.005m : 0m;
        }
    }
}
