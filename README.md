# ShoppingApp

Usernames and passwords for tests:

jamesreid - applebeans12 //client

eliza29 - bluemoon! //client

jsantos - mypass123 //client

mtaylor - goudacheese10 //admin


---------------------------
Required features:

We have implement a log in and log out authentication. Usernames cannot be duplicated, therefore each user must have a unique username. Special characters or spaces are not
allowed in usernames but numbers are valid. If users attempt to add spaces or special characters in their username, the sign up button will be disabled until they type a valid username. On the other hand, passwords can contain special characters. We have created sample users in our SSMS in which one user is an admin.


All of our data (users and products) are stored persistenly in a database. Products are updated regularly as clients purchase products and admins change the inventory. With regards to passwords, the salt and hash of the password are stored in the database and accessed only when a user logs in.


Optional features:

We decided to implement a sign up feature in which users can create an account. This feature is strictly for clients, so accounts created through the sign up window will have
client features. We decided that admin users would be created internally, therefore there is no option to sign up as an admin. However, if a user is indeed an admin, they will have additional features and accessibility, such as changing prices, adding/removing products, updating product quantities as well as having access to user info.


Remaining bugs:

A bug that remains is when a user logs in with a wrong username or password, the username remains in the textfield. We have created a method to clear the textboxes and the Properties, however the username remains in the textbox although the password box clears out.

