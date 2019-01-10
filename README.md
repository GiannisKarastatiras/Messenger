# Messenger
Console Application 

Messenger simulation in C#. The user has to sign in with his username and password. If the user is the admin, he has a different menu than the simple user. Depending on a user's Role in the system, the menu differs and it offers each role the ability to perform some (or all) CRUD operations. This application has the ability to create a log text file in a specified path. Every message is stored in this file.

Note: This project is a database first approach model. In the beginning you have to create two tables in the database. The first refers to the attributes of the user (all details) and the second is used for username and password storage. The username field must be included in the first table as a foreign key. Secondly, you have to create users and assign a role to each user. There are 5 available roles. The first one is the admin who has the ability to perform all CRUD operations and then there are other simpler roles. In the DB the roles are represented by an integer ( numbers 1 to 5 ).
