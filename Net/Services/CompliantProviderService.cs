using Sabio.Data;
using Sabio.Data.Providers;
using Sabio.Models.Domain.Providers;
using Sabio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Sabio.Services
{
    public class CompliantProviderService:ICompliantProviderService

    {
        IDataProvider _data = null;
        public CompliantProviderService(IDataProvider data) {
            _data = data;
        }
        public CompliantProvider SortCompliantByState(int stateId) {
            CompliantProvider cp = new CompliantProvider();
            _data.ExecuteCmd("dbo.Providers_SelectCompliantByState", inputParamMapper: delegate (SqlParameterCollection col)
            {
                col.AddWithValue("@stateId", stateId);
            }, singleRecordMapper: delegate (IDataReader reader, short set)
            {

                cp.Compliant = reader.GetSafeInt32(0);
                cp.NonCompliant = reader.GetSafeInt32(1);
                cp.TotalCount = reader.GetSafeInt32(2);

            });
            return cp;
        }
        public CompliantProvider SortCompliantProviders() {
            CompliantProvider cp = new CompliantProvider();
            _data.ExecuteCmd("dbo.Providers_SortByCompliant", inputParamMapper: delegate (SqlParameterCollection col) { }, singleRecordMapper: delegate (IDataReader reader, short set) {
                cp.Compliant = reader.GetSafeInt32(0);
                cp.NonCompliant = reader.GetSafeInt32(1);
                cp.TotalCount = reader.GetSafeInt32(2);
            });
            return cp;
        }
    }
}
