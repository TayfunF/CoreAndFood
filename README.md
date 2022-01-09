# CoreAndFood Proje Tanımı : 
- Yiyecek ve İçeceklerin olduğu , mysql db de bilgilerin tutulduğu admin paneli olan bir e-ticaret sitesi yapımı.
- Bu projede Sadece Repository Desing Patern kullanarak geliştirme yaptım.


https://user-images.githubusercontent.com/39940749/148678394-71739578-7801-4302-8d4e-f8e73df3e9e7.mp4

*********************************************************************************************************

- Kullandığım Nuget Paketler :
   + 1-) Microsoft.EntityFrameCore
   + 2-) Microsoft.EntityFrameCore.Design
   + 3-) Microsoft.EntityFrameCore.Tools
   + 4-) Pomelo.EntityFrameCore
   + 5-) X.PagedList.Mvc.Core
   + 6-) Microsoft.AspNetCore.Mvc.Razor.RunTimeComplication
   + 7-) Microsoft.VisualStudio.Web.CodeGeneration.Design

*********************************************************************************************************
 
- Kullandığım Veritabanı Ve İsmi :
   + 1-) MySql (Localhost phpMyAdmin)
   + 2-) DbCoreFood 

*********************************************************************************************************

- Kullandığım Veritabanındaki Sütunlar : 
   + 1-) categories {FoodID [Auto Increment,PK],Name,Description,Price,ImageURL,Stock,CategoryID}
   + 2-) foods      {CategoryID [Auto Increment,PK],CategoryName,CategoryDescription,Status}
   + 3-) admins     {AdminID [Auto Increment,PK],UserName,Password}

*********************************************************************************************************

 Projemde Kullandığım Sayfalar Vb. :
 
- PM Console Kullandım [ Migration işlemi yaptım (DB için)]
 
- Pagination (Sayfalama) yapısı kulandım 
   
- Html helper kullandım

- Razor yapısı kullandım

- Genel olarak Asp.net 2.1 & 3.0 kulladım. (Bazı yerlerde 5.0 da kulandım).

- appsettings.json içerisine eklemeler yaptım

- Startup içerisine eklemeler yaptım

- Dependecy Injection işlemi kullandım. (Context yani db işlemeri için vs)

- Generic Repository kulladım

- Statik Google Chart (Circle & Column) kullandım

- Menü Yani side bar kısmı için 

- View Component yapısı kullandım (Asp.Net MVC tarafında ki partial view in aynısı)
