﻿using Newtonsoft.Json;

namespace Stripe
{
    public class StripeDeclineChargeOn
    {
        [JsonProperty("avs_failure")]
        public bool AvsFailure { get; set; }

        [JsonProperty("cvc_failure")]
        public bool CvcFailure { get; set; }
    }
}