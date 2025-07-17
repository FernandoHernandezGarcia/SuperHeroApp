# 🦸‍♂️ SuperHeroApp – CRUD con integración a PokeAPI

Aplicación web desarrollada en ASP.NET Core que permite gestionar una lista de superhéroes con funcionalidades completas de crear, editar, eliminar y visualizar. La interfaz está estilizada con componentes de Telerik/Kendo UI. Además, se integra una API pública externa (PokeAPI) para mostrar datos dinámicos de Pokémon en una vista separada.

---

## 📋 Requisitos del sistema

- [.NET SDK 8.0+]
- PostGRESQL o SQL Server (para la base de datos)
- Visual Studio 2022 o superior (con soporte para ASP.NET Core MVC)
- Navegador moderno (Chrome, Edge, Firefox, etc.)
- Conexión a internet para consumir la PokeAPI

---

## ⚙️ Instrucciones para configurar y ejecutar la aplicación

1. **Abrir el proyecto en Visual Studio.**

2. **Configurar la cadena de conexión:**

   Abre el archivo `appsettings.json` y reemplaza el valor de `DefaultConnection` con tu cadena local. Ejemplo:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SuperHeroDb;Trusted_Connection=True;"
   }Aplicar migraciones para inicializar la base de datos:

3. Abre la consola de administración de paquetes en Visual Studio y ejecuta:
Ejecutar la aplicación:dotnet ef database update


4.Presiona F5 en Visual Studio o el botón “Start”.

Se abrirá la página principal en el navegador.

5.Autenticación:

Regístrate como nuevo usuario.

Luego de iniciar sesión, el menú ocultará las opciones de “Login” y “Register”, mostrando solo “Logout”.

6.CRUD funcional:

Crea, edita y elimina superhéroes.

Formularios estilizados con inputs centrados y placeholders consistentes.

Validación cliente-servidor con mensajes de error visibles.

🔗 Cómo probar el consumo de la API externa (PokeAPI)
La aplicación consume datos desde https://pokeapi.co, una API pública de Pokémon.

¿Cómo acceder?
Loguearse

Haz clic en el botón "Ver Pokémon" .

La vista /Pokemon/Index mostrará una grilla con los 20 primeros Pokémon:

Nombre

Tipo

Sprite oficial
¿Cómo funciona?
PokemonController.cs realiza peticiones HTTP con HttpClient.

Se parsean los resultados con Newtonsoft.Json.Linq.

Se pasan a la vista y se renderizan en un Grid de Kendo UI con binding local.

CAPTURAS DE PANTALLA
### 🦸‍♂️ Lista de SuperHéroes  
![SuperHéroes](screenshots/superheroes-list.png)

### ➕ Crear nuevo héroe  
![Formulario Crear](./screenshots/Create.png)
### ✏️ Editar héroe  
![Editar Héroe](./screenshots/Edit.png)

### 🗑️ Eliminar héroe  
![Eliminar Héroe](./screenshots/Delete.png)

### 🐾 Pokémon vía PokeAPI  
![Pokémon Grid](./screenshots/pokemon-grid.png)

### ❌ Validación de Login  
![Login Error](./screenshots/login.png)

### 📝 Registro de usuario  
![Registro](./screenshots/register-form.png)

### ❌ Validación de Registro  
![Registro Error](./screenshots/register.png)



