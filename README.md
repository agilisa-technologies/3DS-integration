# 3DS-integration

3D Secure integration samples

## Integrate 3D Secure 2.0 with your payment page

To send a request to page ThreeDSIFrame, POST a request with the following parameters:

| Parameter | Description |
| --- | --- |
| `amount` | Authorization amount |
| `pan` | Credit Card Number |
| `month` | Expiry Month |
| `year` | Expiry Year |
| `successUrl` | Final POST page to send results |
| --- | --- |

The page will process the 3DS flow to authenticate the card holder.

## Receiving the 3DS response

The response object will be sent as a POST request to the `successUrl` page.
The response will be a JSON object with the following parameters:

``` json
{
  "status": "Y",  // Y=Success, N=Failure, A=Attempted, U=Unknown
  "authenticationValue": "IguOhr82ov//0g7HYDpygCku/DQ=",
  "eci": "05",
  "dsTransId": "f54d78a4-7b4b-4640-aa18-d1ebcfec7bbb",
  "acsTransId": "ca5f9649-b865-47ce-be6f-54422a0fce47",
  "protocolVersion": "2.2.0",
  "scaIndicator": false
}
```

## Authorize transaction with 3DS Data

Use endpoint /v6/Authorize to authorize a transaction with 3DS data.
Sample request:

``` json
{
    "MerchantKey": "LTE2NDUxMDA4NDQ=",
    "AccountType": "1",
    "AccountNumber": "4485666666666668",
    "ExpirationMonth": 10,
    "ExpirationYear": 2029,
    "CVV": "123",
    "CustomerId": "Customer-4289",
    "CustomerName": "Jacob Toombs",
    "CustomerEmail": "xramex@gmail.com",
    "Amount": "4.40",
    "Currency": "840",
    "Tax": "0",
    "Invoice": "78392",
    "Transaction_Detail": "test transaction",
    "ThreeDS": {
      "status": "Y",  // Y=Success, N=Failure, A=Attempted, U=Unknown
      "authenticationValue": "IguOhr82ov//0g7HYDpygCku/DQ=",
      "eci": "05",
      "dsTransId": "f54d78a4-7b4b-4640-aa18-d1ebcfec7bbb",
      "acsTransId": "ca5f9649-b865-47ce-be6f-54422a0fce47",
      "protocolVersion": "2.2.0",
      "scaIndicator": false
    }
}
```
