﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Stripe
{
    public class StripeBankAccount : StripeObject
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("account")]
        public string AccountId { get; set; }

        [JsonProperty("account_holder_type")]
        public string AccountHolderType { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("default_for_currency")]
        public bool DefaultForCurrency { get; set; }

        [JsonProperty("last4")]
        public string Last4 { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("bank_name")]
        public string BankName { get; set; }

        [JsonProperty("fingerprint")]
        public string Fingerprint { get; set; }

        [JsonProperty("routing_number")]
        public string RoutingNumber { get; set; }
    }
}
