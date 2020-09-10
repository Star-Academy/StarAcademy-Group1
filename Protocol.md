Endpoint

----------------------------------------------
GET
api/transactions/{transactionId}

Response
{
	"source": ...,
	"target": ...,
	"date": ...,
	"time": ...,
	"trackingId": ...,
  "amount": ...,
  "type": ...,
  "transactionId": ...
}

----------------------------------------------
GET
api/accounts/{accountId}

Response
{
  "accountId": ...,
  "cardId": ...,
  "sheba": ...,
  "accountType": ...,
  "branchTelephone": ...,
  "branchAdress": ...,
  "branchName": ...,
  "ownerName": ...,
  "ownerFamilyName": ...,
  "ownerId": ...
}

----------------------------------------------
GET
api/graph

Response
{
  "nodes": [
    {
      "id": 8666,
      "data": {
        ...
      },
    }
  ],
  "edges": [
      {
        "id": ...,
        "source": ...,
        "target": ...,
        "data": {
          ...
        }
      }
  ]
}

GET
api/graph/nodes?select&filter&pageIndex&pageSize
[

]

GET
api/v1/graph/edges?select&filter&pageIndex&pageSize
[

]

----------------------------------------------
GET
/api/v1/graph/paths?from=&to=&maxLength&filter=
Response
{
  "nodes": [
    {
      "id": 8666,
      "data": {
        ...
      },
    }
  ],
  "edges": [
      {
        "id": ...,
        "source": ...,
        "target": ...,
        "data": {
          ...
        }
      }
  ]
}


----------------------------------------------
POST
/api/v1/graph/flow?from=&to=&maxLength&filter

Response
{
  "nodes": [
    {
      "id": 8666,
      "data": {
        "id": 8666,
        "flow": ...
      },
    }
  ],
  "edges": [
      {
        "id": ...,
        "source": ...,
        "target": ...,
        "data": {
          ...
        }
      }
  ]
}


----------------------------------------------
GET
/api/v1/graph/expand?nodeId&filter

Response 
{
  "nodes": [
    {
      "id": 8666,
      "data": {
        ...
      },
    }
  ],
  "edges": [
      {
        "id": ...,
        "source": ...,
        "target": ...,
        "data": {
          ...
        }
      }
  ]
}


----------------------------------------------
GET
/api/graph/stats

Response
{
  "nodes": 10000,
  "edges": 11000
}