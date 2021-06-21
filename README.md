# TechnicalE.Web 
Technical evaluation in .Net

Language: C#
Framework: .Net5

In the email I send to the recruiter I included 2 file with the database script with the structure and another with the data, I also uploaded those files in this project.

The api has the two main endpoints: 

1. https://localhost:44303/api/ExchangeRate/{IsoCode} 
this will retrieve the exchange rate for the available currencies send as parameter the country iso code for example https://localhost:44303/api/ExchangeRate/US

2. https://localhost:44303/api/Transaction/Purchase
this one need to send an object in order to make a transaction for example:
{
    "IdUser": 1,
    "Code": "brl",
    "Amount": 1500
}

---------------------------------------------------------------------------------

Questions in the evaluation:

1. About the endpoints created above, we would like to know what do you think about using the user ID as the input endpoint?
I think the user Id should not be exposed by sending it as an input or output, it is a risk because that id can be copied and use later, instead of the user id, 
a token is more safe.

2. Also, how would you improve the transaction to ensure that the user who makes the purchase is the correct user?
When a customer is logged in, we already have his information and is not a problem for us to find him in our DB, but I am assuming that the scenario for this question is
in case a customer credential has been compromised and probably another person can be trying to use those credential, if that is the scenario, I belieave the best way to ensure
is the correct customer, it will be by adding an electronic token that can verify that the customer that is trying to log in is the right one, or adding security questions,
sending a confirmation email could be another option, I think it will depend of the business security needs.

