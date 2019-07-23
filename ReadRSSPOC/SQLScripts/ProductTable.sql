IF OBJECT_ID('dbo.Product', 'U') IS NOT NULL
 DROP TABLE dbo.Product
 go
  
  CREATE TABLE Product(
        ID INT IDENTITY(1,1) NOT NULL,
        Brand NVARCHAR(50) NOT NULL,
        Color NVARCHAR(10) NOT NULL,
        Price SMALLMONEY NOT NULL,
        Model NVARCHAR(50) NOT NULL,
        ProductImage Image
        )
go

Truncate table Product

go

Insert into Product values('Trek','Blue','100','Large','C:\Users\ChokkaXamarin\Downloads\ecommerceproductgrid\eCommerceProductGrid\eCommerceProductGrid\GridImages\blue_bicycle.jpg')
go
Insert into Product values('Trek','Blue','50','Small','C:\Users\ChokkaXamarin\Downloads\ecommerceproductgrid\eCommerceProductGrid\eCommerceProductGrid\GridImages\blue_bicycle_small.jpg')
go
Insert into Product values('Trek','Green','100','Large','C:\Users\ChokkaXamarin\Downloads\ecommerceproductgrid\eCommerceProductGrid\eCommerceProductGrid\GridImages\green_bicycle.jpg')
go
Insert into Product values('Trek','Green','50','Small','C:\Users\ChokkaXamarin\Downloads\ecommerceproductgrid\eCommerceProductGrid\eCommerceProductGrid\GridImages\green_bicycle_small.jpg')
go
Insert into Product values('Trek','Red','100','Large','C:\Users\ChokkaXamarin\Downloads\ecommerceproductgrid\eCommerceProductGrid\eCommerceProductGrid\GridImages\green_bicycle.jpg')
go
Insert into Product values('Trek','Red','50','Small','C:\Users\ChokkaXamarin\Downloads\ecommerceproductgrid\eCommerceProductGrid\eCommerceProductGrid\GridImages\green_bicycle_small.jpg')
go



