﻿using Machine.Specifications;

namespace Stripe.Tests
{
    public class when_deleting_a_customer
    {
        private static StripeCustomerService _stripeCustomerService;
        private static string _createdStripeCustomerId;

        Establish context = () =>
        {
            _stripeCustomerService = new StripeCustomerService();
 
            var stripeCustomer = _stripeCustomerService.Create(test_data.stripe_customer_create_options.ValidCard());
            _createdStripeCustomerId = stripeCustomer.Id;
        };

        Because of = () =>
            _stripeCustomerService.Delete(_createdStripeCustomerId);

        It should_show_as_deleted = () =>
            _stripeCustomerService.Get(_createdStripeCustomerId).Deleted.ShouldEqual(true);
    }
}