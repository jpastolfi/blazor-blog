using blazor_blog.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blazor_blog.Data;

public class BlogContext : DbContext
{
  public BlogContext(DbContextOptions<BlogContext> options) : base(options)
  { }
  private int GenerateRandomNumber(int min, int max)
  {
    Random random = new();
    return random.Next(min, max);
  }

  public DbSet<Category> Categories { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<BlogPost> BlogPosts { get; set; }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      var server = Environment.GetEnvironmentVariable("DBSERVER") ?? "localhost";
      var password = Environment.GetEnvironmentVariable("DBPASSWORD");
      var database = Environment.GetEnvironmentVariable("DBHOST");
      /* var connectionString = $"Server={server};Database={database};User=SA;Password={password};TrustServerCertificate=True"; */
      var connectionString = $"Server={server};Database=blazor_blog;User=SA;Password=BlazingBlog1234!;TrustServerCertificate=True";
      optionsBuilder.UseSqlServer(connectionString);
    }
#if DEBUG
    optionsBuilder.LogTo(Console.WriteLine);
#endif
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    try
    {

      modelBuilder.Entity<User>()
        .HasData(
          new User
          {
            UserId = 1,
            Email = "visitor@blog.com",
            FirstName = "Tech",
            LastName = "Lead",
            Salt = "text",
            Hash = "Banana"
          }
        );
      modelBuilder.Entity<Category>()
        .HasData(
          new Category
          {
            Id = 1,
            Name = "Azure",
            Slug = "azure"
          },
          new Category
          {
            Id = 2,
            Name = "Entity Framework",
            Slug = "entity-framework"
          },
          new Category
          {
            Id = 3,
            Name = "Blazor",
            Slug = "blazor"
          },
          new Category
          {
            Id = 4,
            Name = "Artificial Intelligence",
            Slug = "artificial-intelligence"
          },
          new Category
          {
            Id = 5,
            Name = "JavaScript",
            Slug = "javascript"
          }
        );
      modelBuilder.Entity<BlogPost>()
        .HasData(
          new BlogPost
          {
            Id = 1,
            UserId = 1,
            CategoryId = 1,
            Title = "Unleash the Cloud's Potential: Your Guide to Microsoft Azure",
            Introduction = "Dive into the world of cloud computing with Microsoft Azure, a comprehensive platform offering a vast array of services to empower businesses of all sizes.",
            Content = "As the need for scalability, security, and flexibility grows in today's digital landscape, cloud computing has become an essential tool for businesses. Microsoft Azure stands tall as a frontrunner in this domain, offering a comprehensive suite of services that cater to diverse needs. From building and deploying web applications and mobile backends to managing databases, storage, and virtual machines, Azure provides a robust platform for businesses to innovate and thrive. Whether you're a seasoned developer or just starting your cloud journey, Azure offers a plethora of tools and resources to get you started. Leverage Azure DevOps for streamlined development and deployment, utilize Azure Functions for serverless computing, and tap into powerful cognitive services like speech recognition and facial recognition to add intelligence to your applications. With a pay-as-you-go pricing model and a global network of data centers, Azure ensures scalability and cost-effectiveness for your projects. So, embrace the power of the cloud and embark on your innovation journey with Microsoft Azure.",
            Slug = "azure",
            CreatedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(10, 100)),
            PublishedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(0, 9)),
            IsPublished = true,
            /* Category = new Category
            {
              Name = "Azure",
              Slug = "azure"
            }, */
          },
      new BlogPost
      {
        Id = 2,
        UserId = 1,
        CategoryId = 1,
        Title = "Azure for Developers: Simplifying Your Development Journey",
        Introduction = "Streamline your development process and focus on building innovative solutions with Azure's robust set of tools and services tailored specifically for developers.",
        Content = "In today's fast-paced development environment, efficiency and developer experience are paramount. Microsoft Azure recognizes this need and provides a plethora of features designed to empower developers. Azure DevOps, a suite of services encompassing tools for continuous integration and deployment (CI/CD), version control, and project management, streamlines your development workflow and fosters collaboration. Azure Functions, a serverless compute platform, allows you to build and deploy code without managing servers, freeing you to focus on core functionalities. Additionally, Azure offers a wide range of cognitive services, pre-built AI models that enable you to easily integrate intelligence into your applications, such as adding sentiment analysis to customer reviews or incorporating image recognition capabilities. Furthermore, Azure provides access to powerful databases like Azure SQL Database and Azure Cosmos DB, catering to diverse data storage and management needs. With its vast ecosystem of tools, services, and documentation, Microsoft Azure empowers developers to focus on",
        Slug = "azure",
        CreatedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(10, 100)),
        PublishedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(0, 9)),
        IsPublished = true,
        /* Category = new Category
        {
          Name = "Azure",
          Slug = "azure"
        } */
      },
      new BlogPost
      {
        Id = 3,
        UserId = 1,
        CategoryId = 3,
        Title = "Reimagine Web Development: Explore the Power of Blazor",
        Introduction = "Experience a new paradigm in web development with Blazor, a framework that allows you to build interactive web UIs using C# and familiar web technologies.",
        Content = "The web development landscape is constantly evolving, and Blazor emerges as a revolutionary framework that challenges traditional approaches. Unlike traditional web development, which often relies on JavaScript for interactivity, Blazor empowers you to leverage the power and familiarity of C# to create dynamic web user interfaces (UIs). This single codebase approach eliminates the need to switch between languages and frameworks, streamlining the development process and reducing complexity. Blazor applications run on the server, ensuring real-time updates and seamless user experiences. Additionally, Blazor seamlessly integrates with existing web technologies like HTML, CSS, and JavaScript, allowing you to leverage your existing skillset while exploring new possibilities. Whether you're building single-page applications (SPAs) or complex web interfaces, Blazor offers a powerful and efficient way to create rich and engaging user experiences, blurring the lines between web and desktop applications.",
        Slug = "blazor",
        CreatedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(10, 100)),
        PublishedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(0, 9)),
        IsPublished = true,
        /* Category = new Category
        {
          Name = "Blazor",
          Slug = "blazor"
        } */
      },
      new BlogPost
      {
        Id = 4,
        UserId = 1,
        CategoryId = 3,
        Title = "Blazor: Building Rich and Engaging User Interfaces",
        Introduction = "Go beyond static web pages and craft dynamic and interactive user experiences with Blazor, a framework that empowers developers to create real-time web applications using C#.",
        Content = "As user expectations for web applications evolve, the need for dynamic and engaging experiences becomes increasingly important. Blazor empowers developers to address this need by providing a framework for building rich and interactive web UIs. Unlike traditional web pages that rely solely on server-side rendering, Blazor applications leverage a combination of server-side and client-side rendering, resulting in real-time updates and a more responsive user experience. This approach allows developers to create features like data binding, where changes in the UI automatically reflect in the underlying data, and routing, enabling seamless navigation between different sections of the application. Blazor also supports event handling, allowing developers to respond to user interactions and create dynamic web experiences. With its focus on C# and familiar web technologies, Blazor offers a smooth learning curve for developers with experience in .NET and web development, while also opening doors for those seeking to explore new avenues in web UI creation. By leveraging the capabilities of Blazor, developers can craft user interfaces that are not only visually appealing but also highly interactive and engaging.",
        Slug = "blazor",
        CreatedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(10, 100)),
        PublishedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(0, 9)),
        IsPublished = true,
        /* Category = new Category
        {
          Name = "Blazor",
          Slug = "blazor"
        } */
      },
      new BlogPost
      {
        Id = 5,
        UserId = 1,
        CategoryId = 2,
        Title = "Simplify Data Access with Entity Framework: Bridge the Gap Between Code and Databases",
        Introduction = " Streamline your data access layer and bridge the gap between code and databases with Entity Framework (EF), a powerful object-relational mapper (ORM).",
        Content = "In the ever-evolving world of software development, efficient data management is crucial for building robust and scalable applications. Entity Framework (EF) emerges as a powerful tool that simplifies the often complex relationship between code and databases. This object-relational mapper (ORM) acts as a bridge, allowing developers to work with data using familiar object-oriented concepts instead of directly writing SQL queries. By mapping database tables to classes and properties, EF enables developers to perform CRUD (Create, Read, Update, Delete) operations and complex queries with ease. Additionally, EF handles the underlying complexities of database interactions, such as connection management and mapping data types, freeing developers to focus on the core functionalities of their applications. With features like automatic code generation and change tracking, EF empowers developers to streamline data access logic and reduce development time. Whether you're building a simple web application or a complex enterprise system, Entity Framework offers a robust and efficient approach to managing your data access layer.",
        Slug = "entity-framework",
        CreatedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(10, 100)),
        PublishedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(0, 9)),
        IsPublished = true,
        /* Category = new Category
        {
          Name = "Entity Framework",
          Slug = "entity-framework"
        } */
      },
      new BlogPost
      {
        Id = 6,
        UserId = 1,
        CategoryId = 2,
        Title = "Entity Framework: Efficient Data Management for Modern Applications",
        Introduction = "Ensure robust and efficient data management for your modern applications with the capabilities of Entity Framework (EF).",
        Content = "As the volume and complexity of data continue to grow, ensuring efficient and robust data manipulation becomes paramount for modern applications. Entity Framework (EF) stands tall as a valuable tool in this regard, empowering developers to perform various data operations with ease and efficiency. Beyond the basic CRUD operations, EF allows developers to write complex queries using LINQ (Language Integrated Query), a familiar syntax that resembles writing queries in C#. This approach simplifies data manipulation and promotes code readability. Furthermore, EF facilitates working with relationships between data entities, enabling you to model and manage complex data structures effectively. With features like lazy loading, eager loading, and caching, EF optimizes data retrieval and reduces database calls, leading to improved application performance. Additionally, EF integrates seamlessly with various database providers, offering flexibility and adaptability to different database technologies. By leveraging the capabilities of Entity Framework, developers can ensure efficient data management, write cleaner and more maintainable code, and ultimately build high-performing applications that can handle the demands of today's data-driven world.",
        Slug = "entity-framework",
        CreatedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(10, 100)),
        PublishedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(0, 9)),
        IsPublished = true,
        /* Category = new Category
        {
          Name = "Entity Framework",
          Slug = "entity-framework"
        } */
      },
      new BlogPost
      {
        Id = 7,
        UserId = 1,
        CategoryId = 4,
        Title = "The Rise of Artificial Intelligence: Transforming Industries and Redefining Possibilities",
        Introduction = "Witness the transformative power of artificial intelligence (AI) as it reshapes industries and redefines possibilities across various domains.",
        Content = "Artificial intelligence (AI) has rapidly emerged from the realm of science fiction and is now transforming various aspects of our lives. Witnessing its exponential growth, it's evident that AI is no longer just a future prospect, but a present reality impacting numerous industries and redefining possibilities across various domains. From automating mundane tasks and enhancing efficiency to generating creative content and even making predictions, AI is revolutionizing how we work, live, and interact with the world around us. At the core of AI lies machine learning (ML), a subfield that allows computers to learn and improve without explicit programming. By analyzing vast amounts of data, ML algorithms can identify patterns, make predictions, and even make decisions based on the learned insights. This capability fuels various AI applications, such as facial recognition in security systems, personalized recommendations in online shopping platforms, and chatbots offering customer support. As AI continues to evolve, its potential to address complex challenges, improve decision-making, and foster innovation is immense. It's crucial to stay informed and adapt to this rapidly evolving landscape to leverage the power of AI and navigate its potential ethical considerations as well.",
        Slug = "artificial-intelligence",
        CreatedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(10, 100)),
        PublishedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(0, 9)),
        IsPublished = true,
        /* Category = new Category
        {
          Name = "Artificial Intelligence",
          Slug = "artificial-intelligence"
        } */
      },
      new BlogPost
      {
        Id = 8,
        UserId = 1,
        CategoryId = 4,
        Title = "Learning from Data: Unlocking the Potential of Machine Learning to Drive Innovation",
        Introduction = "Delve into the world of machine learning (ML), a subfield of artificial intelligence (AI) that unlocks potential for innovation by enabling computers to learn and improve from data.",
        Content = "Machine learning(ML) stands as a cornerstone of artificial intelligence(AI), empowering computers to learn and improve from data without explicit programming.This transformative technology has the potential to unlock a vast array of possibilities across diverse industries.At the heart of ML lies the ability to analyze vast amounts of data, identify patterns, and make predictions based on the learned insights. Imagine the possibilities – from personalized medicine that tailors treatment plans to individual needs to self-driving cars that navigate complex traffic scenarios based on real-time data. This capability fuels various applications, such as fraud detection in financial institutions, spam filtering in email systems, and product recommendations in e-commerce platforms. As the volume and complexity of data continue to grow, ML plays a crucial role in extracting valuable insights and driving innovation. By leveraging various ML algorithms like decision trees, neural networks, and support vector machines, researchers and developers can tackle complex challenges and create intelligent systems that can adapt and learn over time. However, it's important to acknowledge the ethical considerations surrounding data privacy, bias, and fairness in ML algorithms. By fostering responsible development practices and open dialogue, we can harness the power of machine learning to drive positive change and shape a future where AI benefits all.",
        Slug = "artificial-intelligence",
        CreatedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(10, 100)),
        PublishedOn = DateTime.Now - TimeSpan.FromDays(GenerateRandomNumber(0, 9)),
        IsPublished = true,
        /* Category = new Category
        {
          Name = "Artificial Intelligence",
          Slug = "artificial-intelligence"
        } */
      });
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }
  }
}