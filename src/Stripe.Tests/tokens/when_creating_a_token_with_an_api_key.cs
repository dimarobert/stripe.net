﻿using System.Configuration;
using Machine.Specifications;

namespace Stripe.Tests
{
    public class when_creating_a_token_with_an_api_key
    {
        protected static StripeTokenCreateOptions StripeTokenCreateOptions;
        protected static StripeToken StripeToken;

        private static StripeTokenService _stripeTokenService;

        Establish context = () =>
        {
            _stripeTokenService = new StripeTokenService(ConfigurationManager.AppSettings["StripeApiKey"]);
            StripeTokenCreateOptions = test_data.stripe_token_create_options.Valid();
        };

        Because of = () =>
            StripeToken = _stripeTokenService.Create(StripeTokenCreateOptions);

        Behaves_like<token_behaviors> behaviors;
    }
}
