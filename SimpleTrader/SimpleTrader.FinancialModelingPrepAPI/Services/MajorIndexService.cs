using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {

        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            using(FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
            {
                string apiKey = "3532baa7edd9e854c317707d454f3aaa";
                string uri = "majors-indexes/" + GetUriSuffix(indexType);

                var majorIndex = await client.GetAsync<MajorIndex>(uri);
                majorIndex.First().Type = indexType;

                return majorIndex.First();
            }
        }

        private string GetUriSuffix(MajorIndexType indexType)
        {
            switch(indexType)
            {
                case MajorIndexType.DowJones:
                    return ".DJI";
                case MajorIndexType.Nasdaq:
                    return ".IXIC";
                case MajorIndexType.SP500:
                    return ".INX";
                default:
                    throw new Exception("MajorIndexType does not have a suffix defined.");

            }
        }
    }
}
