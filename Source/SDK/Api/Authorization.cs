//==============================================================================
//
//  This file was auto-generated by a tool using the PayPal REST API schema.
//  More information: https://developer.paypal.com/docs/api/
//
//==============================================================================
using Newtonsoft.Json;
using PayPal.Util;
using System;

namespace PayPal.Api
{
    /// <summary>
    /// An authorization transaction.
    /// <para>
    /// See <a href="https://developer.paypal.com/docs/api/">PayPal Developer documentation</a> for more information.
    /// </para>
    /// </summary>
    public class Authorization : PayPalRelationalObject
    {
        /// <summary>
        /// ID of the authorization transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Amount being authorized.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public Amount amount { get; set; }

        /// <summary>
        /// Specifies the payment mode of the transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_mode")]
        public string payment_mode { get; set; }

        /// <summary>
        /// State of the authorization.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state")]
        public string state { get; set; }

        /// <summary>
        /// Reason code, `AUTHORIZATION`, for a transaction state of `pending`.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "reason_code")]
        public string reason_code { get; set; }

        /// <summary>
        /// The level of seller protection in force for the transaction. Only supported when the `payment_method` is set to `paypal`. Allowed values:<br>  `ELIGIBLE`- Merchant is protected by PayPal's Seller Protection Policy for Unauthorized Payments and Item Not Received.</br> `PARTIALLY_ELIGIBLE`- Merchant is protected by PayPal's Seller Protection Policy for Item Not Received or Unauthorized Payments. Refer to `protection_eligibility_type` for specifics. <br> `INELIGIBLE`- Merchant is not protected under the Seller Protection Policy.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "protection_eligibility")]
        public string protection_eligibility { get; set; }

        /// <summary>
        /// The kind of seller protection in force for the transaction. This property is returned only when the `protection_eligibility` property is set to `ELIGIBLE`or `PARTIALLY_ELIGIBLE`. Only supported when the `payment_method` is set to `paypal`. Allowed values:<br> `ITEM_NOT_RECEIVED_ELIGIBLE`- Sellers are protected against claims for items not received.<br> `UNAUTHORIZED_PAYMENT_ELIGIBLE`- Sellers are protected against claims for unauthorized payments.<br> One or both of the allowed values can be returned.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "protection_eligibility_type")]
        public string protection_eligibility_type { get; set; }

        /// <summary>
        /// Fraud Management Filter (FMF) details applied for the payment that could result in accept, deny, or pending action. Returned in a payment response only if the merchant has enabled FMF in the profile settings and one of the fraud filters was triggered based on those settings. See [Fraud Management Filters Summary](https://developer.paypal.com/docs/classic/fmf/integration-guide/FMFSummary/) for more information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "fmf_details")]
        public FmfDetails fmf_details { get; set; }

        /// <summary>
        /// ID of the Payment resource that this transaction is based on.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "parent_payment")]
        public string parent_payment { get; set; }

        /// <summary>
        /// Authorization expiration time and date as defined in [RFC 3339 Section 5.6](http://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "valid_until")]
        public string valid_until { get; set; }

        /// <summary>
        /// Time of authorization as defined in [RFC 3339 Section 5.6](http://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "create_time")]
        public string create_time { get; set; }

        /// <summary>
        /// Time that the resource was last updated.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "update_time")]
        public string update_time { get; set; }

        /// <summary>
        /// Collection of payment response related fields returned from a payment request.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "processor_response")]
        public ProcessorResponse processor_response { get; set; }

        #region Obsolete Properties
        /// <summary>
        /// Reason code for the transaction state being Pending.
        /// </summary>
        [JsonIgnore]
        [Obsolete("This property is obsolete. Use reason_code instead.", false)]
        public string pending_reason { get { return this.reason_code; } set { this.reason_code = value; } }

        /// <summary>
        /// Identifier to the purchase or transaction unit corresponding to this authorization transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "reference_id")]
        public string reference_id { get; set; }

        /// <summary>
        /// Receipt id is 16 digit number payment identification number returned for guest users to identify the payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "receipt_id")]
        public string receipt_id { get; set; }

        #endregion

        /// <summary>
        /// Shows details for an authorization, by ID.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="authorizationId">The ID of the authorization for which to show details.</param>
        /// <returns>Authorization</returns>
        public static Authorization Get(APIContext apiContext, string authorizationId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(authorizationId, "authorizationId");

            // Configure and send the request
            var pattern = "v1/payments/authorization/{0}";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { authorizationId });
            return PayPalResource.ConfigureAndExecute<Authorization>(apiContext, HttpMethod.GET, resourcePath);
        }

        /// <summary>
        /// Captures and processes an authorization, by ID. To use this call, the original payment call must specify an intent of `authorize`.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="capture">Capture</param>
        /// <returns>Capture</returns>
        public Capture Capture(APIContext apiContext, Capture capture)
        {
            return Authorization.Capture(apiContext, this.id, capture);
        }

        /// <summary>
        /// Creates (and processes) a new Capture Transaction added as a related resource.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="authorizationId">ID of the authorization to capture.</param>
        /// <param name="capture">Capture</param>
        /// <returns>Capture</returns>
        public static Capture Capture(APIContext apiContext, string authorizationId, Capture capture)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(authorizationId, "authorizationId");
            ArgumentValidator.Validate(capture, "capture");

            // Configure and send the request
            var pattern = "v1/payments/authorization/{0}/capture";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { authorizationId });
            return PayPalResource.ConfigureAndExecute<Capture>(apiContext, HttpMethod.POST, resourcePath, capture.ConvertToJson());
        }

        /// <summary>
        /// Voids, or cancels, an authorization, by ID. You cannot void a fully captured authorization.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns>Authorization</returns>
        public Authorization Void(APIContext apiContext)
        {
            return Authorization.Void(apiContext, this.id);
        }

        /// <summary>
        /// Voids (cancels) an Authorization.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="authorizationId">ID of the authorization to void.</param>
        /// <returns>Authorization</returns>
        public static Authorization Void(APIContext apiContext, string authorizationId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(authorizationId, "authorizationId");

            // Configure and send the request
            var pattern = "v1/payments/authorization/{0}/void";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { authorizationId });
            return PayPalResource.ConfigureAndExecute<Authorization>(apiContext, HttpMethod.POST, resourcePath);
        }

        /// <summary>
        /// Reauthorizes a PayPal account payment, by authorization ID. To ensure that funds are still available, reauthorize a payment after the initial three-day honor period. Supports only the `amount` request parameter.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns>Authorization</returns>
        public Authorization Reauthorize(APIContext apiContext)
        {
            return Authorization.Reauthorize(apiContext, this);
        }

        /// <summary>
        /// Reauthorizes an expired Authorization.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="authorization">The Authorization object containing the details of the authorization that should be reauthorized.</param>
        /// <returns>Authorization</returns>
        public static Authorization Reauthorize(APIContext apiContext, Authorization authorization)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(authorization, "authorization");

            // Configure and send the request
            var pattern = "v1/payments/authorization/{0}/reauthorize";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { authorization.id });
            return PayPalResource.ConfigureAndExecute<Authorization>(apiContext, HttpMethod.POST, resourcePath, authorization.ConvertToJson());
        }
    }
}
