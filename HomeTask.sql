CREATE TABLE Products(id INT PRIMARY KEY, name VARCHAR(255) NOT NULL);
CREATE TABLE Category(id INT PRIMARY KEY, name VARCHAR(255) NOT NULL);
CREATE TABLE ProductCategory(productId INT NOT NULL, categoryId INT NOT NULL);

INSERT INTO Products VALUES(1, 'Стол'), (2, 'Кресло'), (3, 'Холодильник'), (4, 'Телевизор') 
, (5, 'Телефон'), (6, 'NotFound');
INSERT INTO Category VALUES(1, 'Мебель'), (2, 'Товары для кухни') , (3, 'Электроника');
INSERT INTO ProductCategory VALUES(1, 1),(1, 2),(2, 1),(3, 2),(3, 3),(4, 3),(5, 3);

SELECT p.name as Name, c.name as Category
FROM Products p
    FULL JOIN ProductCategory pc ON p.id = pc.productId
    LEFT JOIN Category c ON c.id = pc.categoryId
ORDER BY p.name;