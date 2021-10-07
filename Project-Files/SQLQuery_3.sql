CREATE TABLE Customer(
    CustomerId int PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) not null,
    City VARCHAR(100),
    Address VARCHAR(100),
    Age INT CHECK(Age > 0 and Age <= 1500) NOT NULL
);

/*Alter to change column data type, add new column, or delete column
Drop to get rid of table Completely.
Truncate to keep the table structure, but get rid of all the data inside.
REMEMBER TO DELETE ALL TABLES WITH FOREIGN KEY REFERNCES TO A TABLE BEFORE DELETING THE TABLE REFERENCED
For Example: if I want to delete store I will first need to delete Orders because orders references it.*/


CREATE TABLE Product(
    ProductId int PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT null,
    Price Decimal(10,2) Not null,
    Description VARCHAR(max),
    Manufacturer VARCHAR(100)
);

/*insert into Product(Name, Price, Description, Manufacturer) values ('Rune Stone', 5.00, 'A smooth blue stone etched with an elegant green sigil that pulses at the touch. The carving bears the craftsmanship of the High elves. Smooth lines branch and curl around one another like a woven knot of emerald vines glistening at the center of pristine gemstone.', 'The Crystal Cave'),
('Wooden Staff', 119.99, 'A weighty staff hewn from cherry wood with a crystal of glass adorning the top. The rich and bloodied hue shows a vibrant warning of the energies crackling beneath the polished surface. Carvings denote the phases of the moons near the apex, wrapping the staff with shimmering silver paint. The crystal of glass splits the ambient light as you hold it aloft, casting an array of colors to dance about the floor.', 'Seaglass Sorcery'),
('Soul Gem', 10.50, 'A prismatic gemstone that feels as though alive. It hums with a radiant magic that resonates with your very soul. Inside it feels almost as if something stirs at your touch. Reaching out to grasp at your essence.', 'Stranger Stones');*/


Create TABLE Inventory(
    InventId int PRIMARY KEY Identity(1,1),
    Quantity INT not NULL,
    ProductId INT FOREIGN KEY REFERENCES Product(ProductId) on delete cascade not NULL,
    StoreId int foreign key references Store(StoreId) on delete cascade not null
);

/*insert into Inventory(StoreId, ProductId, Quantity) VALUES(1, 1, 50),
(1,2,10), 
(1,3,20),
(2,1,50),
(2,2,10),
(2,3,20);*/


Create TABLE Store(
    StoreId int Primary Key Identity(1,1),
    Name VARCHAR(100) Not null,
    Address VARCHAR(100),
    City VARCHAR(100)
);

/*insert into Store(Name, Address, City, InventId) VALUES ('The Mage''s Tower' , '23 Green Emperor Way', 'Cyrodiil City', 1),
('The Mage''s Tower', '8 Divines Way', 'Solitude', 2);*/

CREATE TABLE ItemOrder(
    OrderId int Primary Key IDENTITY(1,1),
    OrderAmount int,
    ProductId int FOREIGN KEY REFERENCES Product(ProductId) on delete cascade not NULL,
    StoreId int foreign key references Store(StoreId),
    CustomerId int FOREIGN key references Customer(CustomerId) on delete cascade not NULL
);

/*insert into ItemOrder(OrderAmount, ProductId, StoreId, CustomerId) VALUES (5, 1, 1, 1),
(1,2,1,1),
(3,3,1,2),
(2,3,1,1),
(1,2,2,2);*/



/*drop table ItemOrder;
drop table Inventory;
drop table Product;
drop table Store;*/



/*Select * from Customer;*/