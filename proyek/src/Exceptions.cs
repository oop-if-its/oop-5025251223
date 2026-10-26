using System;

namespace ProyekBankMini
{
    public class SaldoTidakCukupException : Exception
    {
        public SaldoTidakCukupException(string message) : base(message) { }
    }

    public class RekeningBelumTerdaftarException : Exception
    {
        public RekeningBelumTerdaftarException(string message) : base(message) { }
    }
}
