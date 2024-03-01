# blazor-blog

**Blazor Blog** is a full-stack application simulating a blog website. Users, categories, and blog posts are managed and stored in an Azure SQL database. The application leverages Docker containers for deployment, with separate containers for the database and the front-end/back-end combined.

### Features

* **Category Management:** Users with admin privileges can create, edit, and delete categories.
* **Blog Post Management:** Users with admin privileges can create, edit, and delete blog posts. 
* **Authorization:** 
    * **Visitor:** Visitors can view published blog posts and navigate through the existing categories, filtering if needed.
    * **Administrator:** Administrators have full access to manage users, categories, and blog posts. With admin privileges you can create, edit and delete categories and blog posts. The paths to the authorized pages are only going to show up in the navigation top bar once you are logged in. If you try to access the url by pasting the link (e.g. /admin/manage-categories) without the authorization to do so, you'll receive a message saying that you are not allowed to view that page.

### Technologies

* **Front-end:** Blazor
* **Back-end:** ASP.NET Core
* **Database:** Azure SQL Database
* **Deployment:** Docker
* **ORM:** Entity Framework Core
* **Styling:** Bootstrap
* **Authorization:** ASP.NET Core Identity

### Running the project
1. **Clone the repository:**

```bash
git clone https://github.com/jpastolfi/blazor-blog
```

2. **Navigate to the project directory:**

```bash
cd blazor-blog
```

3. **Build the project and run the application:**

```bash
docker-compose up -d --build
```

This will start the application and the database container. 

Before using the application you have to run the migrations with the following commands:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

After this you can access the application at http://localhost:8080/.

### Usage

1. **Register or log in:** Navigate to http://localhost:5000/ and register for a new account or log in with an existing one.
2. **Browse blog posts:** Registered users can view all blog posts, while visitors can only see published posts.
3. **Create and manage blog posts:** Registered users can create new blog posts, edit their existing posts, and delete them.
4. **Manage categories (admin only):** Administrators can create, edit, and delete categories.

**Note:** Only registered users can create blog posts and manage their own posts. Admins have full access to manage all aspects of the blog, including users, categories, and blog posts.

### Contributing

We welcome contributions to this project! Please see the CONTRIBUTING.md file for guidelines on how to contribute.

### License

This project is licensed under the MIT License. See the LICENSE file for details.

### Additional Information

* This application is a work in progress and may contain bugs or incomplete features.
* The application is designed for demonstration purposes and might require further configuration or adjustments for production use.
