# PROG7311POE
Read Me File-Abdullah Essack-ST10083933

I created a stock management website for a brick‐and‐mortar store. We had to develop a prototype web application using Visual Studio and C#. To create the web app we needed to download a few apps such as visual studio and Microsoft SQL server management studio. We needed visual studio to create the website design and implement the app features and we used Microsoft SQL server management studio to create the database for the website to store information. Firstly we had to create our register and login page. Secondly we had to create a asp.net core web app(mvc) on visual studio. We then had to declare our strings and variables for users, farmers and products under the models folder. We then created a DbContext class in which we declared our models. Then we created our tables for users, farmers and products by using migration and updating the database. We then created our controller and views to add the code for the design and functionality of the website. Once we finished that we had to make some changes to include roles when registering and also for users to access user-specific information. Once we finished all of that then our app was ready to run. To run the app you click on the green run button on visual studio. Once the user runs the app the first thing the user will be asked to do is to sign-in or register if he/she has not created a account. If the user does not sign-in then they will not be able to acces the product and farmers page. To register a user will have to add information like first name, last name, email, password and also choose their role which will either be farmer or employee.To login you just have to enter your email and password. When a user registers a new account the details of the user gets added to the database. If a employee logs in they will be able to add new farmers to the website and database and also they will also be able to view the list of all the products ever supplied by a specific farmer. A logged‐in employee will also be able to filter the displayed list of products supplied by a specific farmer according to the date range or product type. A logged-in employee can also add new roles like admin or manager if they want to. When a employee adds a new farmer to the webiste then the farmers details gets saved on the database. A logged-in farmer can add a new product to the website store and database. To create a new product the farmer will have to add the product name, quantity, date and their name. The new product will also be saved in the database. A farmer will only be able to see their own products and not the products of other farmers. They can update, delete, view and create new products for their user. All farmers will not be able to access the farmer and role page on the website as they are not allowed to create new farmers or roles. A logged-in employee will be able to access most pages as they are allowed to create new farmers, roles and also view and search for products and farmersor roles. If a farmer tries to access a page that they do not have authority to it will say access denied. This app which i created is very cool and easy to use. It's a simple but effective website which you will get used to and enjoy in no time. Farmers will love this website as it helps them with products and stock-management. I really enjoyed creating this app and i hope many people benefit from it, learn from it and make use of it as i also learnt a lot when creating this app.

Prerequisites
Before you proceed, make sure you have the following tools and dependencies installed:


Visual Studio (version X.X or higher)
.NET Framework (version X.X or higher)
SQL Server (version X.X or higher)

Usage
Once the prototype web application is running, follow these steps to use its features:

Register a Farmer or Employee Account:

Click on the "Register" link on the login page.
Fill in the required details and select the appropriate user role (Farmer or Employee).
Click "Register" to create a new account.
Login to the Application:
![login](https://github.com/VCDBN/prog7311-part-2-AbdullahEssack1/assets/101723389/683bd56c-afd1-42cb-a6fb-27e2b7c4c802)

Enter your credentials (username and password) on the login page.
Click "Login" to access the user-specific information.
Add a Farmer or Product:

If you are logged in as an Employee, navigate to the "Add Farmer" page.
Fill in the farmer's details in the provided form and click "Save" to add the farmer to the database.
![add farmer](https://github.com/VCDBN/prog7311-part-2-AbdullahEssack1/assets/101723389/9cfd1d65-4647-4675-b64a-d9e0c03cbb57)

If you are logged in as a Farmer, navigate to the "Add Product" page.
![add product](https://github.com/VCDBN/prog7311-part-2-AbdullahEssack1/assets/101723389/59c4a96a-2d5a-4fea-90b0-3f7749133fad)

Fill in the product details in the provided form and click "Save" to add the product to your profile.
View Farmer's Products:

If you are logged in as an Employee, navigate to the "View Products" page.
Select a specific farmer from the list to view all the products supplied by that farmer.
Use the available filters (date range, product type) to refine the displayed list.
Logout:

To log out from the application, click on the "Logout" link or button.
