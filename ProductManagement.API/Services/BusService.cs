using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.API.Services
{
    //arka planda  servisim ayağa kalkması için gerekli
    //bus start- stop süreçlerini yönetiminde  kullanıyoruz.
    public class BusService : IHostedService
    {
        private readonly IBusControl _bustcontrol;
        public BusService(IBusControl bustcontrol)
        {
            _bustcontrol = bustcontrol;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
          return  _bustcontrol.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _bustcontrol.StopAsync(cancellationToken);
        }
    }
}
