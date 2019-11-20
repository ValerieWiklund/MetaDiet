dotnet publish -c Release
docker build -t "keepr" ./bin/Release/netcoreapp3.0/publish
docker tag "keepr" registry.heroku.com/keepr-vw/web
docker push registry.heroku.com/keepr-vw/web
heroku container:release web -a keepr-vw
