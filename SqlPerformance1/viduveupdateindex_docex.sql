--Example 1 on AdventureWorksDW2017
SELECT Color, COUNT(DISTINCT ProductKey) --scalar
FROM AdventureWorksDW2017.dbo.DimProduct
WHERE ReorderPoint < 800 --filter
GROUP BY Color --stream aggregate
HAVING COUNT(DISTINCT ProductKey) > 10
ORDER BY Color --sort

USE [AdventureWorksDW2017]
GO
CREATE NONCLUSTERED INDEX IX_DimProduct_ReOrderPoint
ON [dbo].[DimProduct] ([ReorderPoint])
INCLUDE ([Color])
GO
--Example 2

SELECT DP.ProductKey, 
 DP.EnglishProductName,
 DPC.ProductCategoryKey,
 DPC.EnglishProductCategoryName,
 DPSC.ProductSubcategoryKey, 
 DPSC.EnglishProductSubcategoryName
FROM AdventureWorksDW2017..DimProduct DP 
 INNER JOIN AdventureWorksDW2017..DimProductSubcategory DPSC
 ON DP.ProductSubcategoryKey=DPSC.ProductSubcategoryKey 
 INNER JOIN AdventureWorksDW2017..DimProductCategory DPC 
 ON DPSC.ProductCategoryKey=DPC.ProductCategoryKey

 USE [AdventureWorksDW2017]
GO
CREATE NONCLUSTERED INDEX IX_DimProduct_ProductSubcategoryKey
ON [dbo].[DimProduct] ([ProductSubcategoryKey])
INCLUDE ([EnglishProductName])
GO