## Link to heroku deployed app: 
```
https://sorinahelloworldweb.herokuapp.com/
```

## Github CI/CD 
```
The workflow of the app : https://github.com/sorinaKupan/repo1/actions/workflows/dotnet-desktop.yml
```

## Database
```
Set your own local database in the default string connection in "appsettings.json".
```

# How to run/deploy 

## How to build in docker

Build the image
```
docker build . -t sorinahelloworldweb
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

Create an app in Heroku (skip this if you already have created an app)
```
heroku create
```

Push container
```
heroku container:push -a sorinahelloworldweb web
```

Release the container
```
heroku container:release -a sorinahelloworldweb web
```