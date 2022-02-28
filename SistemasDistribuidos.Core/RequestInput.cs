namespace SistemasDistribuidos.Application
{
    public class RequestInput : IRequestInput
    {
        public double PrimeiroValor { get; set; }

        public double SegundoValor { get; set; }

        public int TipoOperacao { get; set; }
    }
}