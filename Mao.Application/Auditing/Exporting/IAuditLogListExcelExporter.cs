using System.Collections.Generic;
using Mao.Application.Auditing.Dto;
using Mao.Application.Dto;

namespace Mao.Application.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
