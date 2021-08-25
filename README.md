# My first line 

##How to build in docker
Build the image
```
docker build . -t imageName
```

Run the image
```
docker run -d -p 8081:80 --name sorinahelloworldweb_container sorinahelloworldweb 
```

## How to deploy to Heroku
Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a borys-internship-class web
```

Release the container
```
heroku container:release -a app-helloworld-kupan web
```