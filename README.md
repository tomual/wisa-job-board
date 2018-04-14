# wisa-job-board
Job board and application site

Written in C# using ASP.NET MVC 5

![Screenshot](http://tomual.com/images/blog/ss%20(2018-03-20%20at%2007.18.14).png)

## Features

* Staff authentication
* Application with file upload
* Job post, edit, delete

## Installation

1. Place files in server
2. Run migrations
3. User/Register to create user account
4. Modify Web.config
```
    <add key="DisableRegistration" value="true"/>
    <add key="CompanyName" value="Acme Sounds Inc"/>
    <add key="CompanyWebsite" value="http://google.com"/>
    <add key="Logo" value="logo.svg"/>
```

## Screenshots

![Job Page](http://tomual.com/images/blog/ss%20(2018-03-20%20at%2007.28.46).png)

![Application Form](http://tomual.com/images/blog/ss%20(2018-03-20%20at%2007.30.43).png)

![View Applicant](http://tomual.com/images/blog/ss%20(2018-03-20%20at%2008.47.38).png)
