# Cray Finance .NET SDK

Official .NET SDK for Cray Finance APIs. This library targets .NET Standard 2.0, making it compatible with .NET Core 2.0+, .NET Framework 4.6.1+, and modern .NET 5/6/7/8 applications.

## Requirements

- .NET Standard 2.0 compatible runtime
  - .NET Core 2.0+
  - .NET Framework 4.6.1+
  - .NET 5+

## Installation

(Assuming the package is published to NuGet)

```bash
dotnet add package CrayFi.Sdk
```

## Usage

### Initialization

```csharp
using Cray;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Initialize with Base URL and API Key
        // Base URL: The API endpoint (e.g., "https://pay.connectramp.com/")
        // Token: Your secret API key
        var client = new CrayClient("https://pay.connectramp.com/", "your-api-key");

        // Example: Initiate a card transaction
        try 
        {
            var result = await client.Cards.Initiate(new 
            {
                reference = "unique-ref-123",
                amount = 1000,
                currency = "NGN",
                email = "customer@example.com",
                card_data = new {
                    pan = "539983...",
                    cvv = "123",
                    expiryMonth = "12",
                    expiryYear = "25"
                }
            });
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
```

### Modules

#### Cards

```csharp
// Initiate a card transaction
var initiateResponse = await client.Cards.Initiate(new 
{
    reference = "ref-123",
    amount = 1000,
    currency = "NGN",
    card_data = new { /* ... */ }
});

// Charge
var chargeResponse = await client.Cards.Charge(new { transaction_id = "trans-id" });

// Query
var statusResponse = await client.Cards.Query("customer-ref-123");
```

#### MoMo (Mobile Money)

```csharp
// Initiate Mobile Money Payment
var momoResponse = await client.MoMo.Initiate(new 
{
    amount = 500,
    phone_no = "2348012345678",
    provider = "MTN",
    currency = "NGN"
});

// Requery
var momoStatus = await client.MoMo.Requery("customer-ref-123");
```

#### Wallets

```csharp
// Get Wallet Balance
// Returns all Cray accounts/wallets and their respective balances
var balances = await client.Wallets.Balance();

// Get Subaccounts
// Returns list of all subaccounts
var subaccounts = await client.Wallets.Subaccounts();
```

#### FX (Foreign Exchange)

```csharp
// Get Specific Exchange Rate
var rate = await client.FX.Rate(new { source_currency = "USD", destination_currency = "NGN" });

// Get Rates by Destination
var rates = await client.FX.RatesByDestination(new { destination_currency = "NGN" });

// Generate Quote
var quote = await client.FX.Quote(new 
{ 
    source_currency = "NGN", 
    destination_currency = "USD", 
    source_amount = 1500 
});

// Execute Conversion
var conversion = await client.FX.Convert(new { quote_id = "quote:..." });

// History
var history = await client.FX.History();
```

#### Payouts

```csharp
// Get Payment Methods
var methods = await client.Payouts.PaymentMethods("GH");

// Get Banks
var banks = await client.Payouts.Banks("GH");

// Validate Account
var accountInfo = await client.Payouts.ValidateAccount(new 
{ 
    account_number = "0123456789", 
    bank_code = "058",
    country_code = "GH" 
});

// Process Transfer (Disburse)
var transfer = await client.Payouts.Disburse(new 
{
    amount = "5000",
    account_number = "1234567890",
    bank_code = "058",
    currency = "NGN",
    customer_reference = "ref-123"
});

// Verify Transaction
var status = await client.Payouts.Verify("transaction-id");
```

#### Refunds

```csharp
// Initiate Refund
var refund = await client.Refunds.Initiate(new
{
    pan = "4696...",
    subaccount_id = "...",
    amount = "100" // Optional for full refund
});

// Query Refund
var refundStatus = await client.Refunds.Query("refund-ref");
```

#### Virtual Accounts

```csharp
// Create a virtual account
var va = await client.VirtualAccounts.Create(new
{
    bvn = "22192474887",
    type = "Corporate",              // "Corporate" or "Individual"
    nin = "11111122221",
    virtual_account_type = "Permanent", // "Permanent" or "Onetime"
    account_name = "BOlaOla",
    rc_number = "99988828822",      // Required for Corporate type
    currency = "NGN",
    reference = "cbf0d060-1544-4a53-a00b-7cb75a3eb59d",
    customer_email = "hello@gmail.com",
    provider = "monnify"
});

// Initiate a virtual account request (pre-create step)
var initiated = await client.VirtualAccounts.Initiate(new
{
    provider = "wema",
    bvn = "22192474887"
});

// List all virtual accounts for the merchant
var list = await client.VirtualAccounts.List();

// Get available virtual account providers
var providers = await client.VirtualAccounts.Providers();

// Submit OTP to complete the two-step Wema flow
var result = await client.VirtualAccounts.SubmitOtp(new
{
    merchant_id = "123",
    otp = "768238",
    customer_email = "hello@gmail.com"
});
```

## Error Handling

The SDK throws custom exceptions for different error scenarios:

*   `AuthenticationException`: Invalid API key or unauthorized access.
*   `ValidationException`: Invalid parameters or data.
*   `RequestException`: API returned an error status code.
*   `CrayException`: General SDK errors.
