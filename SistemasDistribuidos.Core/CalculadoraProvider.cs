using System;
using System.Linq;

namespace SistemasDistribuidos.Application
{
    public class CalculadoraProvider : ICalculadoraProvider
    {
        public ICalculadora Obter(TipoOperacao tipoOperacao)
        {
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(f => f.GetTypes())
                .Where(f => typeof(ICalculadora).IsAssignableFrom(f) && !f.IsAbstract && !f.IsInterface);

            foreach (var type in types)
            {
                var handler = Activator.CreateInstance(type) as ICalculadora;

                if (handler is ICalculadora
                    && handler.TipoOperacao == tipoOperacao)
                {
                    return handler;
                }
            }

            return null;
        }
    }
}
