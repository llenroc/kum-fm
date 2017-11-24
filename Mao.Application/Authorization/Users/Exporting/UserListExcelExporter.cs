using System.Collections.Generic;
using System.Linq;
using Abp.Collections.Extensions;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Mao.Application.Authorization.Users.Dto;
using Mao.Application.DataExporting.Excel.EpPlus;
using Mao.Application.Dto;

namespace Mao.Application.Authorization.Users.Exporting
{
    public class UserListExcelExporter : EpPlusExcelExporterBase, IUserListExcelExporter
    {
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public UserListExcelExporter(
            ITimeZoneConverter timeZoneConverter, 
            IAbpSession abpSession)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<UserListDto> userListDtos)
        {
            throw new System.NotImplementedException();
        }
    }
}
