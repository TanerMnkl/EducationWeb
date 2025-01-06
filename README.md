# Education Website

This project is an education-focused website developed using **C#**, **.NET Core**, **MVC**, **HTML**, **CSS**, **Bootstrap**, and **JavaScript**. Below are the key features and details about the application.

## Features

### Roles and Authentication

1. There are two roles in the application:
   - **Admin**
   - **User**
2. Users can register and log in to access the features of the website.
3. Admin login credentials (default):
   - **Username:** Admin
   - **Password:** Qwe123
4. Password recovery is available. If a user forgets their password, an email will be sent when they use the "Forgot Password" option.

### Homepage

1. The homepage displays a sidebar on the left containing **categories**.
2. Products are displayed as cards, each with a "Add to Cart" button.
3. Clicking on a product’s image shows its detailed features.

### Shopping Cart

1. Users must be logged in to add products to the cart.
2. Once a product is added to the cart, the application redirects to the **Cart Page**.
3. From the cart, users can proceed to the **Checkout Page**.
4. The checkout process takes users to a payment confirmation section.

### User Account

1. After logging in, users can click their username in the top-right corner to view and edit their account details.

### Admin Panel

1. Admins can view all **orders** in the admin dashboard.
2. Admins can manage the following entities via tables:
   - **Categories**
   - **Instructors**
   - **Courses**
3. Admins have full CRUD (Create, Read, Update, Delete) functionality for categories, instructors, and courses.

## Installation and Setup

1. Clone the repository to your local machine.
2. Open the project in Visual Studio.
3. Configure the database connection in the `appsettings.json` file. The project uses **MS SQL Server** for the database.
4. Run the database migrations to set up the necessary tables.
5. Build and run the application.

## Dependency Injection

- The project makes use of **Dependency Injection** to manage service lifetimes and resolve dependencies throughout the application.

## How to Use

- **Admin Access:** Use the default admin credentials to log in and access the admin panel.
- **User Access:** Register as a user to log in and access features like adding products to the cart and managing your account.
- **Forgot Password:** Use the "Forgot Password" feature to receive an email for password recovery.

## Project Details

- **Frontend:** HTML, CSS, Bootstrap, JavaScript
- **Backend:** C#, .NET Core MVC
- **Database:** MS SQL Server, Entity Framework Core


