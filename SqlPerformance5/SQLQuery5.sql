
--join vs subquery performance

--select 
--   usertable.userid,
--   (select name from nametable where userid = usertable.userid) as name 
--from usertable 
--where active = 1


--select 
--   usertable.userid,
--   nametable.name 
--from usertable 
--left join nametable on nametable.userid = usertable.userid 
--where usertable.active = 1


-- union vs union all


SELECT * FROM HumanResources.Employee
UNION ALL
SELECT * FROM HumanResources.Employee
UNION ALL
SELECT * FROM HumanResources.Employee

SELECT * FROM HumanResources.Employee
UNION
SELECT * FROM HumanResources.Employee
UNION
SELECT * FROM HumanResources.Employee

-- select * vs select

SELECT HumanResources.Employee.JobTitle FROM HumanResources.Employee
UNION ALL
SELECT HumanResources.Employee.JobTitle FROM HumanResources.Employee
UNION ALL
SELECT HumanResources.Employee.JobTitle FROM HumanResources.Employee

SELECT * FROM HumanResources.Employee
UNION ALL
SELECT * FROM HumanResources.Employee
UNION ALL
SELECT * FROM HumanResources.Employee


-- if exit vs count(*)

IF (SELECT COUNT(*) FROM sales.salesorderdetail 
WHERE ModifiedDate = '20010701 00:00:00.000' ) > 0

    Print 'Yes'

IF EXISTS (SELECT * FROM sales.salesorderdetail WHERE ModifiedDate = '20010701 00:00:00.000') 
    Print 'Yes'



	

