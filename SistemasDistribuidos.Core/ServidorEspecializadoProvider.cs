using System;
using System.Linq;

namespace SistemasDistribuidos.Application
{
    public class ServidorEspecializadoProvider : IServidorEspecializadoProvider
    {
        public IServidorEspecializado Obter(TipoOperacao tipoOperacao)
        {
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(f => f.GetTypes())
                .Where(f => typeof(IServidorEspecializado).IsAssignableFrom(f) && !f.IsAbstract && !f.IsInterface);

            foreach (var type in types)
            {
                var handler = Activator.CreateInstance(type) as IServidorEspecializado;

                if (handler is IServidorEspecializado
                    && handler.TipoOperacao == tipoOperacao)
                {
                    return handler;
                }
            }

            throw new Exception("Servidor especializado não encontrado.");
        }
    }
}