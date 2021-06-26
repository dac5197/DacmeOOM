﻿using DacmeOOM.Core.Application.Models;
using DacmeOOM.Core.Domain.Models;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Interfaces.IValidators
{
    public interface IOrgTypeValidator
    {
        Task<ErrorListModel> ValidateAsync(OrgTypeModel entity);
    }
}