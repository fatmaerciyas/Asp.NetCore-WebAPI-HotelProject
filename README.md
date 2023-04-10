# Asp.NetCore-WebAPI-HotelProject


# Asp.NetCore-WebAPI-HotelProject
I have worked with Asp.Net Core Mvc architecture in my previous projects. In this project, I used Web API technology as well as MVC architecture.
##API:
API integration refers to several applications (two or more) that are interconnected via their APIs to exchange data and perform a common function, thereby enabling interaction between applications.


The appearance of the methods available on the API side is as follows;

![swagger1](https://user-images.githubusercontent.com/55760365/230837036-7a40d789-bea5-4b84-beec-b5990e6fdd60.png)
![swagger2](https://user-images.githubusercontent.com/55760365/230837039-e47a8ca3-2919-424f-865f-f6183ab2211d.png)

And I wrote these methods for each schema
Schemes;

![schemas](https://user-images.githubusercontent.com/55760365/230837046-ecd7dcaf-976a-45ba-934e-21f04ba1701b.png)


In addition to Web API technology, I used the following technologies for the first time. I would like to briefly explain how I use them.

##Data Transfer Object and Mapping:
I used AutyoMapper and AutoMapper is a simple library that allows us to convert Entity objects into the format we want (which we will need in the UI), not as we pull them from the database in our project. DTO (Data Transfer Object) is the format model we want AutoMapper to convert.

##Rapid API
Although it has nothing to do with the project, I created a small Rapid Api project and pulled the data. RapidAPI is a platform that allows you to connect with the public API collection to help speed up your development process. In this project I tried to list only a few of the imdb data.
The data:
![Rapid](https://user-images.githubusercontent.com/55760365/230834683-d8cd4ebe-f05e-41fd-b8fb-4cbfc1bd3a47.png)

###Output is:
![RapidAPI_cikti](https://user-images.githubusercontent.com/55760365/230834694-2c7c8b13-bddf-46f9-9ea5-9a04cca89fa4.png)

It is a simple example. But I just started learning. I hope to post more comprehensive projects here in the future.

##Json Web Token
It is a security library. It offers a rolling mechanism. There are security and validation validations. In the project, I created 2 separate tokens for admin and visitor and performed the authorize process with jwt.
![jwtCreateToken](https://user-images.githubusercontent.com/55760365/230834709-80571673-c4de-438e-a067-d5c1d7472e28.png)


Besides these;
-File operations with API
-Fluent Validation
-Identity library
I also used.


##Appearance of project layers

###API Layer
![ApiLayer](https://user-images.githubusercontent.com/55760365/230834726-a7d3c213-138c-49e5-8480-6b89eb7dd108.png)


###Frontend Layer (MVC)
![Front-End](https://user-images.githubusercontent.com/55760365/230834732-288bffa3-2092-4460-bf6f-f0b29d333fdd.png)

###And other layers that I'm trying to learn
![Others](https://user-images.githubusercontent.com/55760365/230834764-b361bf3d-e8af-494c-a4eb-61e06a0b574f.png)






  
