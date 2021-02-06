# U8: API

### Tecnologías
- .NET Core v3.1 -> Requiere tener instalado el SDK (https://dotnet.microsoft.com/download)
- PostgreSQL v12
- Es requerido la Extension de PostgreSQL -> Npgsql

### Clonar el Proyecto 
- `https://github.com/zaidcodes/Diseno-e-impleme-ntaci-n-de-un-servicio-web-sd-ucab.git`

### Pasos para correr la API de forma local
1. Correr los archivos.sql dentro de la carpeta BBDD en postgressql
2. Cambiar las conexiones de la DB en Data/GeneralContext.cs y appsettings.json
3. Dentro de GeneralContext.cs settear las variables "_instance" y "_cadena"
4. cd DistribuidosApi
5. Ejecutar los comandos `dotnet build` Sirve para instalar todas las dependecias necesarias el proyecto<br/>
6. Finalmente `dotnet run` Construye el proyecto y lo ejecuta<br/>
