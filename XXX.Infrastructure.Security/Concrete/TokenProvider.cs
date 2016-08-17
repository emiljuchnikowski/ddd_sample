using System;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using XXX.Models.Entities;
using XXX.Providers.Interfaces;
using XXX.Repositories.Interfaces;

namespace XXX.Infrastructure.Security.Concrete
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IRepositoryBase<CustomerToken> _customerTokenRepository;

        [ExcludeFromCodeCoverage]
        public TokenProvider(IRepositoryBase<CustomerToken> customerTokenRepository)
        {
            _customerTokenRepository = customerTokenRepository;
        }

        public async Task<string> CreateForAsync(User customer)
        {
            var attemptsCount = 0;
            const int attemptsCountMax = 10000;

            while (true)
            {
                if (++attemptsCount > attemptsCountMax)
                    throw new Exception("Przekroczono ilość prób wygenerowania tokenu(" + attemptsCountMax + ")");

                var token = "M";
                var random = new Random(DateTime.Now.Ticks.GetHashCode());

                var chars = Enumerable.Range(0, 9).Select(x => random.Next(0, 9).ToString());
                token += string.Join("", chars);

                if (await _customerTokenRepository.GetAll().AnyAsync(x => x.Token == token)) continue;

                return token;
            }
        }
    }
}