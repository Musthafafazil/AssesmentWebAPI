using AssesementWebAPI.Domain.Models;

namespace AssesementWebAPI.Services
{
    public interface ITokenQuery
    {
        Task<Token> GetToken();

    }
}
