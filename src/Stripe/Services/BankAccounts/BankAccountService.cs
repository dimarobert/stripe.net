﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stripe
{
    public class BankAccountService : StripeService
    {
        public BankAccountService(string apiKey = null) : base(apiKey) { }

        public bool ExpandCustomer { get; set; }

        public virtual CustomerBankAccount Create(string customerId, BankAccountCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(createOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts"),
                    SetupRequestOptions(requestOptions)
                )
            );
        }

        public virtual CustomerBankAccount Get(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null)
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                Requestor.GetString(
                    this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    SetupRequestOptions(requestOptions)
                )
            );
        }

        public virtual CustomerBankAccount Update(string customerId, string bankAccountId, BankAccountUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(updateOptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    SetupRequestOptions(requestOptions)
                )
            );
        }

        public virtual void Delete(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null)
        {
            Requestor.Delete(
                this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                SetupRequestOptions(requestOptions)
            );
        }

        public virtual IEnumerable<CustomerBankAccount> List(string customerId, StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return Mapper<CustomerBankAccount>.MapCollectionFromJson(
                Requestor.GetString(
                    this.ApplyAllParameters(listOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts", true),
                    SetupRequestOptions(requestOptions)
                )
            );
        }

        public virtual CustomerBankAccount Verify(string customerId, string bankAccountId, BankAccountVerifyOptions verifyoptions, StripeRequestOptions requestOptions = null)
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(verifyoptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}/verify"),
                    SetupRequestOptions(requestOptions)
                )
            );
        }

        public virtual async Task<CustomerBankAccount> CreateAsync(string customerId, BankAccountCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(createOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts"),
                    SetupRequestOptions(requestOptions)
                )
            );
        }

        public virtual async Task<CustomerBankAccount> GetAsync(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null)
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                await Requestor.GetStringAsync(
                    this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    SetupRequestOptions(requestOptions)
                )
            );
        }

        public virtual async Task<CustomerBankAccount> UpdateAsync(string customerId, string bankAccountId, BankAccountUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(updateOptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    SetupRequestOptions(requestOptions)
                )
            );
        }

        public virtual async Task DeleteAsync(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null)
        {
            await Requestor.DeleteAsync(
                this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                SetupRequestOptions(requestOptions)
            );
        }

        public virtual async Task<IEnumerable<CustomerBankAccount>> ListAsync(string customerId, StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return Mapper<CustomerBankAccount>.MapCollectionFromJson(
                await Requestor.GetStringAsync(
                    this.ApplyAllParameters(listOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts", true),
                    SetupRequestOptions(requestOptions)
                )
            );
        }

        public virtual async Task<CustomerBankAccount> VerifyAsync(string customerId, string bankAccountId, BankAccountVerifyOptions verifyoptions, StripeRequestOptions requestOptions = null)
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(verifyoptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}/verify"),
                    SetupRequestOptions(requestOptions)
                )
            );
        }
    }
}