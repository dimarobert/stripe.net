﻿using System;
using Machine.Specifications;
using System.Linq;

namespace Stripe.Tests
{
    public class when_canceling_a_subscription_and_trying_to_retrieve
    {
        private static StripeCustomer _stripeCustomer;
        private static StripeSubscription _stripeSubscription;
        private static StripeSubscriptionService _stripeSubscriptionService;

        Establish context = () =>
        {
            var _stripePlanService = new StripePlanService();
            var _stripePlan = _stripePlanService.Create(test_data.stripe_plan_create_options.Valid());

            var _stripeCouponService = new StripeCouponService();
            var _stripeCoupon = _stripeCouponService.Create(test_data.stripe_coupon_create_options.Valid());

            var _stripeCustomerService = new StripeCustomerService();
            _stripeCustomer = _stripeCustomerService.Create(test_data.stripe_customer_create_options.ValidCard(_stripePlan.Id, _stripeCoupon.Id, DateTime.UtcNow.AddDays(10)));

            _stripeSubscriptionService = new StripeSubscriptionService();
        };

        Because of = () =>
            _stripeSubscription = _stripeSubscriptionService.Cancel(_stripeCustomer.Id, _stripeSubscriptionService.List(_stripeCustomer.Id).ToList()[0].Id, false);

        It should_throw_exception_when_retrieved = () =>
        {
            var exception = Catch.Exception(() => _stripeSubscriptionService.Get(_stripeCustomer.Id, _stripeSubscription.Id));
            exception.Message.ShouldNotBeNull(); 
        };
    }
}