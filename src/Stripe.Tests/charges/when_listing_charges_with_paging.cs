﻿using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;

namespace Stripe.Tests
{
    public class when_listing_charges_with_paging
    {
        private static StripeCustomer _stripeCustomer;
        private static StripeChargeService _stripeChargeService;

        private static List<StripeCharge> _stripeChargeListFirstPage;
        private static List<StripeCharge> _stripeChargeListSecondPage;
        private static List<StripeCharge> _stripeChargeListFirstPageFromSecond;

        private static List<string> _chargeIds;

        Establish context = () =>
        {
            var stripeCustomerService = new StripeCustomerService();
            _stripeCustomer = stripeCustomerService.Create(test_data.stripe_customer_create_options.ValidCard());

            _stripeChargeService = new StripeChargeService();
            var chargeCreateOptions = test_data.stripe_charge_create_options.ValidCustomer(_stripeCustomer.Id);

            _stripeChargeService = new StripeChargeService();

            _chargeIds = new List<string>();
            _chargeIds.Add(_stripeChargeService.Create(chargeCreateOptions).Id);
            _chargeIds.Add(_stripeChargeService.Create(chargeCreateOptions).Id);
            _chargeIds.Add(_stripeChargeService.Create(chargeCreateOptions).Id);
            _chargeIds.Add(_stripeChargeService.Create(chargeCreateOptions).Id);
            _chargeIds.Reverse();
        };

        Because of = () =>
        {
            _stripeChargeListFirstPage = _stripeChargeService.List(new StripeChargeListOptions
            {
                Limit = 2,
                CustomerId = _stripeCustomer.Id
            }).ToList();

            _stripeChargeListSecondPage = _stripeChargeService.List(new StripeChargeListOptions
            {
                Limit = 2,
                CustomerId = _stripeCustomer.Id,
                StartingAfter = _stripeChargeListFirstPage.Last().Id
            }).ToList();

            _stripeChargeListFirstPageFromSecond = _stripeChargeService.List(new StripeChargeListOptions
            {
                Limit = 2,
                CustomerId = _stripeCustomer.Id,
                EndingBefore = _stripeChargeListSecondPage.First().Id
            }).ToList();
        };

        It should_only_have_2_entries_on_first_page = () =>
            _stripeChargeListFirstPage.Count.ShouldEqual(2);

        It should_only_have_2_entries_on_second_page = () =>
            _stripeChargeListSecondPage.Count.ShouldEqual(2);

        It should_only_have_2_entries_on_first_page_from_second = () =>
            _stripeChargeListFirstPageFromSecond.Count.ShouldEqual(2);

        It should_start_second_page_from_third_charge = () =>
            _stripeChargeListSecondPage.First().Id.ShouldEqual(_chargeIds[2]);

        It should_start_first_page_from_second_from_first_charge = () =>
            _stripeChargeListFirstPageFromSecond.First().Id.ShouldEqual(_chargeIds[0]);
    }
}