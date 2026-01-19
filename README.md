## Instalation Instructions
Run npm i on hermes-api folder

## Run Instructions
docker run -d -p 27017:27017 --name hermes-mongo mongo:latest
set ConnectionStrings.DefaultConnection = mongodb://localhost:27017 on hermes-api/appsettings.Development.json
run dotnet watch on hermes-api folder
run npm run dev on hermes-front folder