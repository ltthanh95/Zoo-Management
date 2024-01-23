# Project Description
The zoo management is the program that manages the animals, staffs, customers, tickets, and items which are sale on in the shops. The staffs, which also include managers, will manage the animals, tickets, and shops. Many staffs can be in one department and they take care of many animals and shops. Moreover, they also design the public events and private events if any customers want to book the place. The animals will be taken care by staffs; they have to report the animals' status that is stored in database. Each customer can buy many tickets at the same time and they can book a place for events like birthday, wedding, picnic, etc.  We keep track the items, tickets, and private events by getting the customer's information. Customer's information, such as Name, Address, Email, and their purchases will be stored in database, the account will be store in the database with encrypted password, and staffs will get report every months for revenues from customers' purchases. 
# File Description
We use ASP NET Core to write the program for front-end and back-end. Our database is MySql WorkBench
- Whole project is store in `Zooe` folder
- Front-end is stored in `Views` folders
- Back-end is stored in `Team10` and `Controllers` folders 
- CSS-JS files, images are stored in `wwwroot` folders
- Our SQL dump is in the folder `Database Dump`
# User Roles
We have two main roles: Admin and User
- Admin will update the changes like edit and delete staffs', animals' and customers' information. Admin can create User account and other admin account. Moreover, admin can buy tickets, items and book events
- User cannot access to admin's functions. They only can create user account. They can buy tickets, booking private events and buy items.
* There are other roles that you can create and edit but our main ones are admin and user.
# Login
We have previously created accounts that allow you to enter the website:
- admin@zoo.com
- user@zoo.com
- Password for both: Zoodb10!
# Creating a new account
Our project allows anyone to register. We have a dropdown for easy convience to register under a certain role, it updates the database in realtime. 
Please note that a password **requires** at leasts 
- 6 characters
- a capital letter
- a special character



Please make sure to **CONFIRM** your account once you create it, otherwise it will not work when you sign in.
# Triggers
**Three Triggers** 
- The email cannot be duplicated.
- You can only buy a ticket for a private event if it isn't already at full capacity.
- Removes inventory from shops and prevents stock going below 0.
# Reports
- Ticket sale report
- Shop sale report
Both reports are viewable via *admin* login in the dropdown. You can view the data between selected dates as well.

