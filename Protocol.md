Endpoint

GET
/transaction/{transactionId}
{
	source
	target
	date
	time
	trackingId
  amount
  type
  transactionId
}

GET
/account/{accountId}
{
  accountId
  cardId
  sheba
  accountType
  branchTelephone
  branchAdress
  branchName
  ownerName
  ownerFamilyName
  ownerId
}

GET
/graph/{graphId}
{
"edges": [
    {
      "id": 13337,
      "source": 8372,
      "target": 124,
      "data": {
        "type": "HAS_MARKET"
      }
    }
  ]
}
