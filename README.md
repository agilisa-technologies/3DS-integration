# 3DS-integration

3D Secure integration samples

To integrate 3D Secure 2.2 with your payment page, you can implement the following options:

## Wapper v1

Integrate 3D Secure capturing the credit card details on your payment page, and send the information to /ThreeDSProcess page. 
A sample request page is located on /src/Pages/ThreeDSMain

To send a request to page /ThreeDSProcess, POST a request with the following parameters:

| Parameter | Description |
| --- | --- |
| `amount` | Authorization amount |
| `pan` | Credit Card Number |
| `month` | Expiry Month |
| `year` | Expiry Year |
| `successUrl` | Final POST page to send results |


The page will process the 3DS flow to authenticate the card holder.

## Wapper v2

 Integrate 3D Secure capturing the credit card details on your payment page, integrate to 3DS using API, and delegate the Challenge process to a wrapper page (/ThreeDSHandler).
 A sample request page is located on /src/Pages/ThreeDSSample

In this sample the connection to 3DS Servers is done using the available APIs (view [text](https://docs.3dsintegrator.com/docs/3ds-api)) calling Authenticate and GetResult endpoints
The information from both responses, is combined and POSTed to //ThreeDSHandler

| Parameter | Description |
| --- | --- |
| `ThreeAuthResponse` | combined JSON from APIs |
| `successUrl` | Final POST page to send results |



A sample json for ThreeAuthResponse field:

``` json
{
    "methodURL": "https://acs-server-sandbox.3dsintegrator.com/v2/fingerprint",
    "protocolVersion": "2.2.0",
    "correlationId": "1f9ccf06-fa2c-11ef-96b5-0242ac110004",
    "transactionId": "3090a636-fa2c-11ef-96b5-0242ac110004",
    "threeDSMethodData": "eyJ0aHJlZURTTWV0aG9k...MTEwMDA0In0",
    "scaIndicator": false,
    "status": "C",
    "creq": "eyJtZXN...SI6IjAxIn0",
    "authenticationType": "01",
    "challengeWindowURL": {
        "href": "/authenticate/challenge/3090a636-fa2c-11ef-96b5-0242ac110004",
        "rel": "authenticate",
        "type": "GET"
    },
    "dsTransId": "2adfc378-c5f1-41ee-9b3e-feb699b66101",
    "acsTransId": "d6f15aae-2c9d-4333-a920-954be07c0c76",
    "acsURL": "https://acs-server-sandbox.3dsintegrator.com/v2/challenge/ui",
    "transStatusReasonDetail": "Medium confidence",
    "transStatusReason": "16"
}
```

## Integrate 3D Secure 2.0 with your payment page

After you obtain the 3DS authentication data 

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
