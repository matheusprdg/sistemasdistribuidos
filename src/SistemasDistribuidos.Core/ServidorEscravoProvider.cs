using System;
using System.Linq;

namespace SistemasDistribuidos.Application
{
    public class ServidorEscravoProvider : IServidorEscravoProvider
    {
        public IServidorEscravo Obter(int id)
        {
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(f => f.GetTypes())
                .Where(f => typeof(IServidorEscravo).IsAssignableFrom(f) && !f.IsAbstract && !f.IsInterface);

            foreach (var type in types)
            {
                var handler = Activator.CreateInstance(type) as IServidorEscravo;

                if (handler is IServidorEscravo
                    && handler.Compativel(id))
                {
                    return handler;
                }
            }

            throw new Exception("Servidor não encontrado.");
        }
    }
}