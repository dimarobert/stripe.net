﻿using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeLegalEntityVerification
    {
        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("details_code")]
        public string DetailsCode { get; set; }

        #region Expandable Document
        public string DocumentId { get; set; }

        [JsonIgnore]
        public StripeFileUpload Document { get; set; }

        [JsonProperty("document")]
        internal object InternalDocument
        {
            set
            {
                ExpandableProperty<StripeFileUpload>.Map(value, s => DocumentId = s, o => Document = o);
            }
        }
        #endregion

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}