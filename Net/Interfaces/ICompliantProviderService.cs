using Sabio.Models.Domain.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabio.Services.Interfaces
{
    public interface ICompliantProviderService
    {
        CompliantProvider SortCompliantByState(int stateId);
        CompliantProvider SortCompliantProviders();
    }
}
