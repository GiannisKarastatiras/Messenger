# Messenger
Console Application 

Messenger simulation in C#. The user have to sign in with username and password, if the user is the admin has a different menu than the simple user. Depends on the concession (Role) in the system, the display distincts from user to user and the user has the ability to perform some (or all) the CRUD operations. This application has the functionality to create txt log that stores every message, in a specific folder path.

Note: This project is database first approach model. In the beginning you have to create the database with two tables. The first refers to the attributes of the user (all the details) and the second for the username and password. The username must be foreign key to the first table. You have to assign Roles. There 5 roles: First is the admin who has the ability to perform all the CRUD operations and then all the others.In DB for the Roles you have to put in numbers 1 to 5.
