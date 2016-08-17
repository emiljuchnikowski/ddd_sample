using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Colway.Domain
{
    [ExcludeFromCodeCoverage]
    public class Mapper
    {
        private static Mapper _instance;
        private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1);

        private Mapper()
        {
        }

        public static Mapper Instance
        {
            get
            {
                // ReSharper disable once InvertIf
                if (_instance == null)
                {
                    Semaphore.Wait();
                    _instance = new Mapper();
                    Semaphore.Dispose();
                }

                return _instance;
            }
        }

        public void Load()
        {
            // TODO : wszystkie mapy z domeny
        }
    }
}
