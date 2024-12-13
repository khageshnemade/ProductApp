# ProductApp
## Create New Web App in ASP .Net
then add Connection string in appsetting.json add Servername DatabaseName in connection string 
```  "ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=Nimap;Trusted_Connection=True;MultipleActiveResultSets=true"
 }
```

### Add following data in sql this is raw data for checking purpose
```
INSERT INTO [dbo].[Categories] ( [CategoryName]) 
VALUES 
(N'Books'),
(N'Electronics'),
(N'Furniture'),
(N'Clothing'),
(N'Sports'),
(N'Toys'),
(N'Groceries'),
(N'Automotive'),
(N'Music'),
(N'Beauty');

```


```
INSERT INTO [dbo].[Categories] ([CategoryId], [CategoryName]) 
VALUES 
INSERT INTO [dbo].[Products] ([ProductName], [CategoryId]) 
VALUES 
-- Books
(N'Harry Potter', 1),
(N'The Hobbit', 1),
(N'1984', 1),
(N'To Kill a Mockingbird', 1),
(N'The Great Gatsby', 1),
(N'Moby Dick', 1),
(N'War and Peace', 1),
(N'Pride and Prejudice', 1),
(N'Jane Eyre', 1),
(N'Ulysses', 1),

-- Electronics
(N'iPhone 14', 2),
(N'Samsung Galaxy S23', 2),
(N'Sony Headphones', 2),
(N'Dell Laptop', 2),
(N'MacBook Pro', 2),
(N'Apple Watch', 2),
(N'GoPro Hero', 2),
(N'Canon DSLR', 2),
(N'Amazon Echo', 2),
(N'Fitbit Versa', 2),

-- Furniture
(N'Dining Table', 3),
(N'Office Chair', 3),
(N'Sofa Set', 3),
(N'Bookshelf', 3),
(N'Coffee Table', 3),
(N'Wardrobe', 3),
(N'Bed Frame', 3),
(N'Study Desk', 3),
(N'TV Stand', 3),
(N'Recliner', 3),

-- Clothing
(N'Leather Jacket', 4),
(N'Cotton Shirt', 4),
(N'Denim Jeans', 4),
(N'Summer Dress', 4),
(N'Woolen Sweater', 4),
(N'Trendy Blazer', 4),
(N'Casual Trousers', 4),
(N'Formal Shirt', 4),
(N'Printed T-Shirt', 4),
(N'Winter Coat', 4),

-- Sports
(N'Football', 5),
(N'Basketball', 5),
(N'Tennis Racket', 5),
(N'Cricket Bat', 5),
(N'Baseball Glove', 5),
(N'Golf Clubs', 5),
(N'Running Shoes', 5),
(N'Hiking Backpack', 5),
(N'Swimming Goggles', 5),
(N'Canoe Paddle', 5),

-- Toys
(N'Barbie Doll', 6),
(N'Lego Set', 6),
(N'Toy Car', 6),
(N'Action Figure', 6),
(N'Teddy Bear', 6),
(N'PlayStation Console', 6),
(N'Board Game', 6),
(N'Scooter', 6),
(N'RC Helicopter', 6),
(N'Puzzle Cube', 6),

-- Groceries
(N'Whole Wheat Bread', 7),
(N'Organic Eggs', 7),
(N'Fresh Apples', 7),
(N'Rice Pack', 7),
(N'Spices Box', 7),
(N'Cooking Oil', 7),
(N'Bottled Water', 7),
(N'Cheese Block', 7),
(N'Frozen Pizza', 7),
(N'Chocolates', 7),

-- Automotive
(N'Car Tires', 8),
(N'Motor Oil', 8),
(N'Car Battery', 8),
(N'Spark Plug', 8),
(N'Brake Pads', 8),
(N'Headlights', 8),
(N'Steering Cover', 8),
(N'Alloy Wheels', 8),
(N'Floor Mats', 8),
(N'Air Freshener', 8),

-- Music
(N'Acoustic Guitar', 9),
(N'Violin', 9),
(N'Drum Set', 9),
(N'Piano Keyboard', 9),
(N'Saxophone', 9),
(N'Electric Guitar', 9),
(N'Trumpet', 9),
(N'Flute', 9),
(N'DJ Controller', 9),
(N'Microphone', 9),

-- Beauty
(N'Face Cream', 10),
(N'Eye Shadow Palette', 10),
(N'Lipstick', 10),
(N'Foundation', 10),
(N'Hair Conditioner', 10),
(N'Perfume', 10),
(N'Nail Polish', 10),
(N'Makeup Brush Set', 10),
(N'Face Mask', 10),
(N'Moisturizer', 10);


```
## Following are the running images of the this site
### 1.Product List
![Screenshot (8)](https://github.com/user-attachments/assets/15e9f92e-bb87-4c9f-98ef-609d012b340a)

### 2.Add Product
![Screenshot 2024-12-13 144725](https://github.com/user-attachments/assets/10c0bd97-c076-4918-9129-1a0701234915)

### 3.Edit Product
![Screenshot 2024-12-13 144823](https://github.com/user-attachments/assets/239c9234-23ef-486e-b8dc-efbca291f09c)

### 4.Delete Product
![Screenshot 2024-12-13 144810](https://github.com/user-attachments/assets/616f2eb0-f219-4680-9754-dfb6f3519b81)



### 5.Add Category
![Screenshot 2024-12-13 144759](https://github.com/user-attachments/assets/fd225411-eadc-4092-bbba-c2e87f243993)

### 6.Category List 
![Screenshot 2024-12-13 144743](https://github.com/user-attachments/assets/9a9d2669-2b71-49af-a751-4fe320be1eee)

### 5.Edit Category
![image](https://github.com/user-attachments/assets/40ea041e-1371-4173-90f6-faa1b24ed025)

### 5.Delete Category
![image](https://github.com/user-attachments/assets/8bdfff2c-029e-426a-be80-3181d8cd61a1)




