# prueba_2025

# Inicialización

Se necesita ir a la carpeta root del proyecto y ejecutar el comando 

`docker-compose up -d --build`

Con ello se levantaran en los siguientes puertos

### Base de datos

- User: system
- Password: password!2204
- Port: 1521


### FrontEnd
[Frontend](http://localhost:4200/solicitud/index "Frontend")

Donde ya se podrá relizar las consultas logradas.

### Backend
Si se quisiera solamente correr el backend se debe correr el comando 
Se debe cambiar en el.

`app.setting.json`

    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
        "OracleDb": "User Id=system; Password=password!2204; Data Source=localhost:1521/XE"
      }
    }
    

Dentro de el root de backend. Y correrlo con 

`dotnet watch`

Para poder utilizar el Swagger y visualizar el API. 




