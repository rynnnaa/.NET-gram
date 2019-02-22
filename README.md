# .NET-gram

### Azure Deployment

Website: 

This is a web application that holds posts of images and details. It contains a Home page that shows all of the posts created, a landing page for each post that shows all the details of the post, the ability to edit the details of a post, and the capability to add and delete posts.  It utilizes the Microsoft Razor pages architectural pattern and integrates the repository design pattern.  

## Usage

The user lands on the home page which displays all posts

![all posts]()

Users can contribute a new post by clicking the "add new post" link

![add posts]()

In order to make a new post, upload an image, write a title and caption, then click "save"

![upload]()

A user may select a specific post to edit

![select for edit]()

The edit page allows users to change the image, title, and caption of the post

![edit post]()

## Technologies Used

Visual Studio, GitHub, Microsoft.AspNetCore, Microsoft.EntityFramework, Razor Pages, Bootstrap, Azure Blob Storage

## Architectural Design

The database contains a single entity with ID, Title, Caption, and URL

