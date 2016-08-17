using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Colway.Infrastructure.DataAccess;
using XXX.Models.Entities;

namespace XXX.Infrastructure.DataAccess
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
            AutoMapper.Mapper.CreateMap<User, UpdateUserPasswordModel>();
        }
    }
}