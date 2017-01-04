﻿using Machine.Specifications;

namespace Stripe.Tests
{
    public class when_creating_a_coupon
    {
        protected static StripeCouponCreateOptions StripeCouponCreateOptions;
        protected static StripeCoupon StripeCoupon;

        private static StripeCouponService _stripeCouponService;

        Establish context = () =>
        {
            _stripeCouponService = new StripeCouponService();
            StripeCouponCreateOptions = test_data.stripe_coupon_create_options.Valid();
        };

        Because of = () =>
            StripeCoupon = _stripeCouponService.Create(StripeCouponCreateOptions);

        Behaves_like<coupon_behaviors> behaviors;
    }
}