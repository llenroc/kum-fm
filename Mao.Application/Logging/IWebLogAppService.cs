using Abp.Application.Services;
using Mao.Application.Logging.Dto;
using Mao.Application.Dto;

namespace Mao.Application.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
