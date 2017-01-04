﻿using Newtonsoft.Json;
using Stripe.Infrastructure;
using System;
using System.Collections.Generic;

namespace Stripe
{
    public class StripeApplicationFeeRefund : StripeObject
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(StripeDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("balance_transaction")]
        public string BalanceTransaction { get; set; }

        [JsonProperty("fee")]
        public string Fee { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
    }
}
