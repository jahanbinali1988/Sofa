Sofa language chat bot is a personal project targeted to build an open source chat bot for learning everyone a foreign language, of course it's in first steps but I made a decision to pull this project as a sample for using <strong>Domain Driven Design</strong> practices. This project is just a sample and has a lots of works to do. 

In this project I've tried to follow <strong>Domain Driven Design</strong> practices and <strong>principles</strong> -exclusively Solid- as well as implementing technologies like <strong>RabbitMq with Masstransit, Autofac, Structuremap, Dapper, EntityFrameworkCore, MongoDB, Identity Server, Microsoft ChatBot, Xunit</strong> and etc.
Hope Other developers find this project useful.

<h2>prerequisites of project:</h2>
•	Bot Framework Emulator v4<br />
•	RabbitMq 3.8.2<br />
•	MongoDb 4.2.3<br />
•	dotnet core 2.2<br />
  
<h2>Steps of running this project:</h2>
•	Open Package Manage Console and run add-migration command bellow modules.<br />
•	In Package Manager Console run Update Database command for each modules.<br />
Sofa.Identity.DependencyInjection, Sofa.CourseManagement.EntityFramework, Sofa.Teacher.EntityFramework.<br />

<h2>Project Description:</h2>
  This project has three domains; <strong>CourseManagement</strong> -As core domain-, <strong>Teacher</strong> -for chat bot functionalities- and <strong>Identity</strong>. 
  <strong>CourseMangement</strong> servces Api services for an Angular project, that its aim is inputting data from teacher’s panel to publish on <strong>Teacher</strong> Project. <strong>Teacher</strong> Project consume data from RabbitMq queue and save it on its own tables (By Ef core and MongoDB), however the main responsibility for <strong>Teacher</strong> domain is retrieving data for chat bot.
  The <strong>Identity</strong> is aimed to implement an TripleA system.
