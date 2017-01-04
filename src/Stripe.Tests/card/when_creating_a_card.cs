﻿using System;
using System.Collections.Generic;
using Machine.Specifications;

namespace Stripe.Tests
{
    public class when_creating_a_card
    {
        private static StripeCustomer _stripeCustomer;
        private static StripeCardService _stripeCardService;
        private static StripeCardCreateOptions _stripeCardCreateOptions;
        private static StripeCard _stripeCard;

        Establish context = () =>
        {
            _stripeCustomer = new StripeCustomerService().Create(new StripeCustomerCreateOptions()
            {
                Email = "bob@" + Guid.NewGuid() + ""
            });
            
            _stripeCardService = new StripeCardService();
            _stripeCardCreateOptions = new StripeCardCreateOptions()
            {
                SourceCard = new SourceCard()
                {
                    Name = "TestCard " + Guid.NewGuid(),
                    ReceiptEmail = "testcard@" + Guid.NewGuid() + ".com",
                    ExpirationMonth = "10",
                    ExpirationYear = "2021",
                    Number = "4000000000000077",
                    Metadata = new Dictionary<string, string>
                    {
                        { "OwnerId", "1234" },
                        { "EventId", "1414141" }
                    }
                }
            };
        };

        Because of = () =>
            _stripeCard = _stripeCardService.Create(_stripeCustomer.Id, _stripeCardCreateOptions);

        It should_have_metadata = () =>
            _stripeCard.Metadata.ShouldNotBeNull();

        It should_have_the_correct_metadata = () =>
        {
            _stripeCard.Metadata.Keys.ShouldContain("OwnerId");
            _stripeCard.Metadata["OwnerId"].ShouldEqual("1234");

            _stripeCard.Metadata.Keys.ShouldContain("EventId");
            _stripeCard.Metadata["EventId"].ShouldEqual("1414141");
        };
    }
}