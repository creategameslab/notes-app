# notes-app
Simple angular 14, NET 7.0 Core simple note app.

The project will run out of the box from the build client folder under wwwroot. In order to build from scratch or modify the Angular application the following commands will be helpful:

1. npm install 
2. npm install" WorkingDirectory=".\\Client" 
3. ng build --configuration production --output-hashing none" WorkingDirectory=".\\Client" 

or for development ng build --watch --output-hashing none

This was created from an empty core project and the angular cli was used to generate the app inside the folder.

The app uses memory to store notes for testing but it could be swap with EF, sqllite, or any other data store. To generate a few entires use http://localhost:5264/api/notes/seed.

A few shortcuts were taken in the interest of saving time. For example note editing uses the same component, and a single service was used to glue events.

Why not React?

While I have worked with React, I spend the last year working with angular and in order to build this in a few hours it was the best options.

API supports

api/notes     -> [get] all notes
api/note/id   -> [get] note by id
api/note/id   -> [delete] remove note
api/note      -> [post] add a note
api/note/id   -> [patch] update a note by id

![App Preview](https://github.com/creategameslab/notes-app/blob/main/SimpleApp.gif)
