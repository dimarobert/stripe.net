﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Stripe
{
    public class BankAccountVerifyOptions
    {
        [JsonProperty("amounts[]")]
        public int AmountOne { get; set; }

        [JsonProperty("amounts[]")]
        public int AmountTwo { get; set; }
    }
}
