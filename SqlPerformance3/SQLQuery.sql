

-- more detail

USE AdventureWorks2017
GO
SELECT * INTO dbo.SalesOrderDetailTestPartitionTable_have FROM AdventureWorks2017.Sales.SalesOrderDetail
GO

USE AdventureWorks2017
GO
SELECT * INTO dbo.SalesOrderDetailTestPartitionTable_notHave FROM AdventureWorks2017.Sales.SalesOrderDetail
GO

USE AdventureWorks2017
GO
SELECT * INTO dbo.SalesOrderDetailTestPartitionTable_haveButIndexNotIncludeInside FROM AdventureWorks2017.Sales.SalesOrderDetail
GO

USE AdventureWorks2017
GO
CREATE PARTITION FUNCTION SalesOrderDetail_func(INT) AS RANGE RIGHT FOR VALUES (250, 500, 750) 
GO 

CREATE PARTITION SCHEME PScheme_SalesOrderDetail AS PARTITION SalesOrderDetail_func ALL TO ([PRIMARY])




SELECT TOP (1000000) [SalesOrderID]
      ,[SalesOrderDetailID]
      ,[CarrierTrackingNumber]
      ,[OrderQty]
      ,[ProductID]
      ,[SpecialOfferID]
      ,[UnitPrice]
      ,[UnitPriceDiscount]
      ,[LineTotal]
      ,[rowguid]
      ,[ModifiedDate]
FROM [AdventureWorks2017].[dbo].[SalesOrderDetailTestPartitionTable_have] where [SalesOrderDetailID] > 400 and [SalesOrderDetailID] < 600


  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000000) [SalesOrderID]
      ,[SalesOrderDetailID]
      ,[CarrierTrackingNumber]
      ,[OrderQty]
      ,[ProductID]
      ,[SpecialOfferID]
      ,[UnitPrice]
      ,[UnitPriceDiscount]
      ,[LineTotal]
      ,[rowguid]
      ,[ModifiedDate]
  FROM [AdventureWorks2017].[dbo].[SalesOrderDetailTestPartitionTable_notHave] where [SalesOrderDetailID] > 400 and [SalesOrderDetailID] < 600

  USE [AdventureWorks2017]
GO

/****** Object:  Index [PK_SalesOrderDetailTestPartitionTable_have]    Script Date: 08/03/2019 14:01:26 ******/
ALTER TABLE [dbo].[SalesOrderDetailTestPartitionTable_have] ADD  CONSTRAINT [PK_SalesOrderDetailTestPartitionTable_have] PRIMARY KEY CLUSTERED 
(
	[SalesOrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON PScheme_SalesOrderDetail([SalesOrderDetailID])
GO


SELECT
ps.database_id, ps.OBJECT_ID,
ps
.index_id, b.name,
ps
.avg_fragmentation_in_percent
FROM
sys.dm_db_index_physical_stats (DB_ID(N'AdventureWorks2017'), 
	NULL, NULL, NULL , 'DETAILED') AS ps
INNER
JOIN sys.indexes AS b ON ps.OBJECT_ID = b.OBJECT_ID
AND
ps.index_id = b.index_id
WHERE
ps.database_id = DB_ID()
ORDER
BY ps.OBJECT_ID
GO


-- basic example

-- tạo filegroup
ALTER DATABASE AdventureWorks2017 ADD FILEGROUP FG2009AndBefore 
ALTER DATABASE AdventureWorks2017 ADD FILEGROUP FG2010 
ALTER DATABASE AdventureWorks2017 ADD FILEGROUP FG2011AndAfter


ALTER DATABASE AdventureWorks2017 ADD FILE (NAME = N'FY2009AndBefore', FILENAME = N'C:\Users\Ruby\Desktop\partitest\FY2009AndBefore.ndf') TO FILEGROUP FG2009AndBefore 
ALTER DATABASE AdventureWorks2017 ADD FILE (NAME = N'FY2010', FILENAME = N'C:\Users\Ruby\Desktop\partitest\FY2010.ndf') TO FILEGROUP FG2010 
ALTER DATABASE AdventureWorks2017 ADD FILE (NAME = N'FY2011AndAfter', FILENAME = N'C:\Users\Ruby\Desktop\partitest\FY201AndAfter.ndf') TO FILEGROUP FG2011AndAfter


USE AdventureWorks2017
GO
CREATE PARTITION FUNCTION PFunc_NGD(DATETIME) AS RANGE RIGHT FOR VALUES ('2010-01-01', '2011-01-01') 
GO 
CREATE PARTITION SCHEME PScheme_NGD AS PARTITION PFunc_NGD TO (FG2009AndBefore, FG2010, FG2011AndAfter)
--CREATE PARTITION SCHEME PScheme_NGD AS PARTITION PFunc_NGD ALL TO ([PRIMARY])

USE AdventureWorks2017
GO
CREATE TABLE dbo.BanHang(
BanHang_ID INT IDENTITY,
NgayGiaoDich DATETIME,
MaSP INT,
SoLuong INT,
ThanhTien INT
) ON PScheme_NGD(NgayGiaoDich)
GO

CREATE CLUSTERED INDEX CI_BanHang_NGD ON dbo.BanHang(NgayGiaoDich) ON PScheme_NGD(NgayGiaoDich)
--CREATE CLUSTERED INDEX CI_BanHang_NGD ON dbo.BanHang(NgayGiaoDich)  ON [PRIMARY]


SELECT $PARTITION.PFunc_NGD('2008-07-24')
SELECT $PARTITION.PFunc_NGD('2009-12-31')
SELECT $PARTITION.PFunc_NGD('2010-01-01')
SELECT $PARTITION.PFunc_NGD('2010-11-25')
SELECT $PARTITION.PFunc_NGD('2011-03-16')