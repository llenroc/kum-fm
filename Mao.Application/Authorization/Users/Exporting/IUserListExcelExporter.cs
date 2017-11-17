using System.Collections.Generic;
using Mao.Application.Authorization.Users.Dto;
using Mao.Application.Dto;

namespace Mao.Application.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}