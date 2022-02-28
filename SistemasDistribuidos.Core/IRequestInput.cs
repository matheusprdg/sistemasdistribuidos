namespace SistemasDistribuidos.Application
{
    public interface IRequestInput
    {
        double PrimeiroValor { get; set; }

        double SegundoValor { get; set; }

        int TipoOperacao { get; set; }
    }
}