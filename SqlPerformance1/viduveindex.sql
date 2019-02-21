/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [CustomerID]
      ,[PersonID]
      ,[StoreID]
      ,[TerritoryID]
      ,[AccountNumber]
      ,[rowguid]
      ,[ModifiedDate]
  FROM [AdventureWorks2017].[Sales].[Customer_noindex] where [CustomerID] = 1

  SELECT [CustomerID]
      ,[PersonID]
      ,[StoreID]
      ,[TerritoryID]
      ,[AccountNumber]
      ,[rowguid]
      ,[ModifiedDate]
  FROM [AdventureWorks2017].[Sales].[Customer] where [CustomerID] = 1


