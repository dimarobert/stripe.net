using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Stripe.Services.Account {
    public class StripeConnectedAccounts : StripeService {
        public StripeConnectedAccounts(string apiKey) : base(apiKey) { }

        public virtual List<StripeAccount> GetAll(int limit = 99999) {
            var accountsBldr = new UriBuilder(Urls.Accounts);
            var query = HttpUtility.ParseQueryString(accountsBldr.Query);
            query.Add("limit", limit.ToString());
            accountsBldr.Query = query.ToString();

            var response = Requestor.GetString(accountsBldr.ToString(), SetupRequestOptions(null));

            return Mapper<List<StripeAccount>>.MapFromJson(Mapper<Dictionary<string, object>>.MapFromJson(response)["data"].ToString());
        }
    }
}
