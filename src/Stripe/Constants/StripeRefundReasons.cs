﻿namespace Stripe
{
    public static class StripeRefundReasons
    {
        public const string Unknown = null;
        public const string Duplicate = "duplicate";
        public const string Fradulent = "fraudulent";
        public const string RequestedByCustomer = "requested_by_customer";
    }
}