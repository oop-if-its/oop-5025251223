using System;

namespace ProyekBankMini
{
    public class Tabungan : Rekening
    {
        public Tabungan(string nomorRekening, decimal saldoAwal) : base(nomorRekening, saldoAwal) { }

        public override decimal Tarik(decimal jumlah)
        {
            if (jumlah <= 0) throw new ArgumentException("Jumlah tarik harus lebih dari 0.");
            if (Saldo < jumlah) throw new SaldoTidakCukupException("Saldo tabungan tidak mencukupi!");

            Saldo -= jumlah;
            return Saldo;
        }

        public override decimal HitungBunga()
        {
            // Bunga sederhana 2%
            return Saldo * 0.02m;
        }
    }
}