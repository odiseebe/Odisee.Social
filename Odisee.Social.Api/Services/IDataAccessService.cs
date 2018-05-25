using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Odisee.Social.Api.Services
{
    public interface IDataAccessService<ViewModel>
    {
        Task<ViewModel> GetSingleRecordAsync(
            int Id,
            CancellationToken ct
        );

        Task<IEnumerable<ViewModel>> GetMultipleRecordsAsync(
            CancellationToken ct
        );
    }
}
