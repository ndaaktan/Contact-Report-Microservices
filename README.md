# Contact-Report-Microservices

<p align="center">
  <img alt="Github top language" src="https://img.shields.io/github/languages/top/ndaaktan/Contact-Report-Microservices?color=56BEB8">

  <img alt="Github language count" src="https://img.shields.io/github/languages/count/ndaaktan/Contact-Report-Microservices?color=56BEB8">

  <img alt="Repository size" src="https://img.shields.io/github/repo-size/ndaaktan/Contact-Report-Microservices?color=56BEB8">
</p>

## :dart: About ##
<p align="left">There are two microservices in the project. One is Contact Service and the other is Report Service. Contact Service uses for contact operations, Report Service uses for report operations.
  </p>
  <p align="left">
You can use contact service for add contact, add contact information, delete contact, update contact, list contacts.
You can reach all operation at the Swagger UI.
  </p>

  <img src="https://user-images.githubusercontent.com/61392140/161567737-4d7ec289-a919-4233-a788-7201ba6faf8b.png"/>

  <p align="left">
You can send request to Report Service for statistic report. Two services are communicating with each other when you sent report request.
You can reach all operation at the Swagger UI.
  <img src="https://user-images.githubusercontent.com/61392140/161568175-3d914f51-b9f8-415b-86ec-9aadcd3ad1ff.png"/>

  </p>

## :rocket: Technologies ##

The following tools were used in this project:

 * .Net Core
 * Entity Framework
 * PostgreSQL 
 * EPPlus
 * RabbitMQ

## :checkered_flag: Starting ##
* When you start the project, database will be migrate automatically.
* You should change report and contact database connection strings;

  <img src="https://user-images.githubusercontent.com/61392140/161592935-b1295a73-baae-4a6d-a84b-7194dcbca6f0.png"/>
  <img src="https://user-images.githubusercontent.com/61392140/161593113-ce2da816-95c8-41de-a833-6c6c2efe4892.png"/>
* You should change Rabbitmq configuration
 
  <img src="https://user-images.githubusercontent.com/61392140/161593570-bd81a26c-0280-4aac-8d16-1c42b311a26e.png"/>
* You can create contact, contact information and then you can send request to CreateReport end point. This end point will start to create report asynchronously.

  <img src="https://user-images.githubusercontent.com/61392140/161594139-054889f7-5593-42b0-a03f-7e85b2515c98.png"/>
* You can list all reports and reports status by using GetAllReports end point.

  <img src="https://user-images.githubusercontent.com/61392140/161594534-fbb54f6e-9639-4d61-9802-838e4a1e986e.png"/>
* Finally, you can download report by using DownloadReport endpoint.

  <img src="https://user-images.githubusercontent.com/61392140/161594798-c68f20f9-4972-4ac5-a884-c9075b7ec094.png"/>











