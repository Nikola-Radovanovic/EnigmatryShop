# EnigmatryShop
Web shop application
--------------------

Before starting the application, set 3 projects to run simultaneously in the following order
--------------------------------------------------------------------------------------------
- Shop.WebApi
- Vendor.WebApi
- Shop.Client

Things that need to be implemented
----------------------------------
- Create database
- Connect database with class library project
- Improve BuyArticle method with deduction quantity of articles in stock
- Improve Recent Articles list
- Fix dependency injection on Index page on Shop.Client project

Vendor.WebApi Refactoring
-------------------------
The Vendor.Web Api project is created as an third-party provider mock and therefore the project structure is not what it should be,
as the case with Shop.WebApi project, beacause the logic in Vendor.WebApi is only consumed by Shop.WebApi.
