using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace blazor_blog.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Introduction = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    PublishedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, "Azure", "azure" },
                    { 2, "Entity Framework", "entity-framework" },
                    { 3, "Blazor", "blazor" },
                    { 4, "Artificial Intelligence", "artificial-intelligence" },
                    { 5, "JavaScript", "javascript" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "Hash", "LastName", "Salt" },
                values: new object[] { 1, "visitor@blog.com", "Tech", "Banana", "Lead", "text" });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedOn", "Introduction", "IsPublished", "ModifiedOn", "PublishedOn", "Slug", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "As the need for scalability, security, and flexibility grows in today's digital landscape, cloud computing has become an essential tool for businesses. Microsoft Azure stands tall as a frontrunner in this domain, offering a comprehensive suite of services that cater to diverse needs. From building and deploying web applications and mobile backends to managing databases, storage, and virtual machines, Azure provides a robust platform for businesses to innovate and thrive. Whether you're a seasoned developer or just starting your cloud journey, Azure offers a plethora of tools and resources to get you started. Leverage Azure DevOps for streamlined development and deployment, utilize Azure Functions for serverless computing, and tap into powerful cognitive services like speech recognition and facial recognition to add intelligence to your applications. With a pay-as-you-go pricing model and a global network of data centers, Azure ensures scalability and cost-effectiveness for your projects. So, embrace the power of the cloud and embark on your innovation journey with Microsoft Azure.", new DateTime(2024, 1, 10, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1200), "Dive into the world of cloud computing with Microsoft Azure, a comprehensive platform offering a vast array of services to empower businesses of all sizes.", true, null, new DateTime(2024, 2, 21, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1280), "azure", "Unleash the Cloud's Potential: Your Guide to Microsoft Azure", 1 },
                    { 2, 1, "In today's fast-paced development environment, efficiency and developer experience are paramount. Microsoft Azure recognizes this need and provides a plethora of features designed to empower developers. Azure DevOps, a suite of services encompassing tools for continuous integration and deployment (CI/CD), version control, and project management, streamlines your development workflow and fosters collaboration. Azure Functions, a serverless compute platform, allows you to build and deploy code without managing servers, freeing you to focus on core functionalities. Additionally, Azure offers a wide range of cognitive services, pre-built AI models that enable you to easily integrate intelligence into your applications, such as adding sentiment analysis to customer reviews or incorporating image recognition capabilities. Furthermore, Azure provides access to powerful databases like Azure SQL Database and Azure Cosmos DB, catering to diverse data storage and management needs. With its vast ecosystem of tools, services, and documentation, Microsoft Azure empowers developers to focus on", new DateTime(2023, 12, 4, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1290), "Streamline your development process and focus on building innovative solutions with Azure's robust set of tools and services tailored specifically for developers.", true, null, new DateTime(2024, 2, 22, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1290), "azure", "Azure for Developers: Simplifying Your Development Journey", 1 },
                    { 3, 3, "The web development landscape is constantly evolving, and Blazor emerges as a revolutionary framework that challenges traditional approaches. Unlike traditional web development, which often relies on JavaScript for interactivity, Blazor empowers you to leverage the power and familiarity of C# to create dynamic web user interfaces (UIs). This single codebase approach eliminates the need to switch between languages and frameworks, streamlining the development process and reducing complexity. Blazor applications run on the server, ensuring real-time updates and seamless user experiences. Additionally, Blazor seamlessly integrates with existing web technologies like HTML, CSS, and JavaScript, allowing you to leverage your existing skillset while exploring new possibilities. Whether you're building single-page applications (SPAs) or complex web interfaces, Blazor offers a powerful and efficient way to create rich and engaging user experiences, blurring the lines between web and desktop applications.", new DateTime(2023, 12, 24, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1300), "Experience a new paradigm in web development with Blazor, a framework that allows you to build interactive web UIs using C# and familiar web technologies.", true, null, new DateTime(2024, 2, 25, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1300), "blazor", "Reimagine Web Development: Explore the Power of Blazor", 1 },
                    { 4, 3, "As user expectations for web applications evolve, the need for dynamic and engaging experiences becomes increasingly important. Blazor empowers developers to address this need by providing a framework for building rich and interactive web UIs. Unlike traditional web pages that rely solely on server-side rendering, Blazor applications leverage a combination of server-side and client-side rendering, resulting in real-time updates and a more responsive user experience. This approach allows developers to create features like data binding, where changes in the UI automatically reflect in the underlying data, and routing, enabling seamless navigation between different sections of the application. Blazor also supports event handling, allowing developers to respond to user interactions and create dynamic web experiences. With its focus on C# and familiar web technologies, Blazor offers a smooth learning curve for developers with experience in .NET and web development, while also opening doors for those seeking to explore new avenues in web UI creation. By leveraging the capabilities of Blazor, developers can craft user interfaces that are not only visually appealing but also highly interactive and engaging.", new DateTime(2024, 1, 3, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1310), "Go beyond static web pages and craft dynamic and interactive user experiences with Blazor, a framework that empowers developers to create real-time web applications using C#.", true, null, new DateTime(2024, 2, 21, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1310), "blazor", "Blazor: Building Rich and Engaging User Interfaces", 1 },
                    { 5, 2, "In the ever-evolving world of software development, efficient data management is crucial for building robust and scalable applications. Entity Framework (EF) emerges as a powerful tool that simplifies the often complex relationship between code and databases. This object-relational mapper (ORM) acts as a bridge, allowing developers to work with data using familiar object-oriented concepts instead of directly writing SQL queries. By mapping database tables to classes and properties, EF enables developers to perform CRUD (Create, Read, Update, Delete) operations and complex queries with ease. Additionally, EF handles the underlying complexities of database interactions, such as connection management and mapping data types, freeing developers to focus on the core functionalities of their applications. With features like automatic code generation and change tracking, EF empowers developers to streamline data access logic and reduce development time. Whether you're building a simple web application or a complex enterprise system, Entity Framework offers a robust and efficient approach to managing your data access layer.", new DateTime(2023, 12, 29, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1310), " Streamline your data access layer and bridge the gap between code and databases with Entity Framework (EF), a powerful object-relational mapper (ORM).", true, null, new DateTime(2024, 2, 27, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1320), "entity-framework", "Simplify Data Access with Entity Framework: Bridge the Gap Between Code and Databases", 1 },
                    { 6, 2, "As the volume and complexity of data continue to grow, ensuring efficient and robust data manipulation becomes paramount for modern applications. Entity Framework (EF) stands tall as a valuable tool in this regard, empowering developers to perform various data operations with ease and efficiency. Beyond the basic CRUD operations, EF allows developers to write complex queries using LINQ (Language Integrated Query), a familiar syntax that resembles writing queries in C#. This approach simplifies data manipulation and promotes code readability. Furthermore, EF facilitates working with relationships between data entities, enabling you to model and manage complex data structures effectively. With features like lazy loading, eager loading, and caching, EF optimizes data retrieval and reduces database calls, leading to improved application performance. Additionally, EF integrates seamlessly with various database providers, offering flexibility and adaptability to different database technologies. By leveraging the capabilities of Entity Framework, developers can ensure efficient data management, write cleaner and more maintainable code, and ultimately build high-performing applications that can handle the demands of today's data-driven world.", new DateTime(2023, 12, 3, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1320), "Ensure robust and efficient data management for your modern applications with the capabilities of Entity Framework (EF).", true, null, new DateTime(2024, 2, 20, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1330), "entity-framework", "Entity Framework: Efficient Data Management for Modern Applications", 1 },
                    { 7, 4, "Artificial intelligence (AI) has rapidly emerged from the realm of science fiction and is now transforming various aspects of our lives. Witnessing its exponential growth, it's evident that AI is no longer just a future prospect, but a present reality impacting numerous industries and redefining possibilities across various domains. From automating mundane tasks and enhancing efficiency to generating creative content and even making predictions, AI is revolutionizing how we work, live, and interact with the world around us. At the core of AI lies machine learning (ML), a subfield that allows computers to learn and improve without explicit programming. By analyzing vast amounts of data, ML algorithms can identify patterns, make predictions, and even make decisions based on the learned insights. This capability fuels various AI applications, such as facial recognition in security systems, personalized recommendations in online shopping platforms, and chatbots offering customer support. As AI continues to evolve, its potential to address complex challenges, improve decision-making, and foster innovation is immense. It's crucial to stay informed and adapt to this rapidly evolving landscape to leverage the power of AI and navigate its potential ethical considerations as well.", new DateTime(2023, 12, 24, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1330), "Witness the transformative power of artificial intelligence (AI) as it reshapes industries and redefines possibilities across various domains.", true, null, new DateTime(2024, 2, 27, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1340), "artificial-intelligence", "The Rise of Artificial Intelligence: Transforming Industries and Redefining Possibilities", 1 },
                    { 8, 4, "Machine learning(ML) stands as a cornerstone of artificial intelligence(AI), empowering computers to learn and improve from data without explicit programming.This transformative technology has the potential to unlock a vast array of possibilities across diverse industries.At the heart of ML lies the ability to analyze vast amounts of data, identify patterns, and make predictions based on the learned insights. Imagine the possibilities – from personalized medicine that tailors treatment plans to individual needs to self-driving cars that navigate complex traffic scenarios based on real-time data. This capability fuels various applications, such as fraud detection in financial institutions, spam filtering in email systems, and product recommendations in e-commerce platforms. As the volume and complexity of data continue to grow, ML plays a crucial role in extracting valuable insights and driving innovation. By leveraging various ML algorithms like decision trees, neural networks, and support vector machines, researchers and developers can tackle complex challenges and create intelligent systems that can adapt and learn over time. However, it's important to acknowledge the ethical considerations surrounding data privacy, bias, and fairness in ML algorithms. By fostering responsible development practices and open dialogue, we can harness the power of machine learning to drive positive change and shape a future where AI benefits all.", new DateTime(2024, 2, 11, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1340), "Delve into the world of machine learning (ML), a subfield of artificial intelligence (AI) that unlocks potential for innovation by enabling computers to learn and improve from data.", true, null, new DateTime(2024, 2, 20, 14, 30, 49, 498, DateTimeKind.Local).AddTicks(1340), "artificial-intelligence", "Learning from Data: Unlocking the Potential of Machine Learning to Drive Innovation", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_CategoryId",
                table: "BlogPosts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_UserId",
                table: "BlogPosts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
