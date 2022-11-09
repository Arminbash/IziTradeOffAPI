using IziTradeOff.Application.Dtos.SendGrid;
using System.Threading.Tasks;

namespace IziTradeOff.Application.Interfaces.SendGrid
{
    public interface ISendGridEnviar
    {
        Task<(bool resultado, string errorMessage)> EnviarEmail(SendGridData data);
    }
}
