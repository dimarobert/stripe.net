﻿using System;
using Newtonsoft.Json;
using Stripe.Infrastructure;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Stripe
{
    public class StripeDispute : StripeObject
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        [JsonProperty("amount")]
        public int? Amount { get; set; }

        #region Expandable Charge
        public string ChargeId { get; set; }

        [JsonIgnore]
        public StripeCharge Charge { get; set; }

        [JsonProperty("charge")]
        internal object InternalCharge
        {
            set
            {
                ExpandableProperty<StripeCharge>.Map(value, s => ChargeId = s, o => Charge = o);
            }
        }
        #endregion

        [JsonProperty("created")]
        [JsonConverter(typeof(StripeDateTimeConverter))]
        public DateTime? Created { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("balance_transactions")]
        public List<StripeBalanceTransaction> BalanceTransactions { get; set; }

        // needs evidence object
        // needs evidence_details

        [JsonProperty("is_charge_refundable")]
        public bool IsChargeRefundable { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
    }
}