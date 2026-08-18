# RestaurantAPI 🍽️

![.NET](https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Entity Framework](https://img.shields.io/badge/EF%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

**RestaurantAPI** es una solución robusta para el backend de gestión de pedidos en restaurantes. El sistema permite administrar mesas, platos, categorías y órdenes en tiempo real, garantizando la integridad de los datos financieros mediante el cálculo de subtotales directamente en el servidor.

## 🏗️ Arquitectura del Proyecto
El proyecto sigue los principios de **Clean Architecture**, asegurando un bajo acoplamiento y alta testeabilidad:

* **Core.Domain:** Contiene las entidades base y lógica compartida.
* **Core.Application:** Implementa la lógica de negocio, DTOs especializados, interfaces de servicio y perfiles de **AutoMapper**.
* **Infrastructure.Persistence:** Implementación del contexto de base de Datos (EF Core), Repositorios genéricos y configuraciones de Fluent API.
* **Presentation (WebApi):** Controladores RESTful con soporte para versionamiento de API.

---

## 🧩 Patrones de Diseño y Principios de Ingeniería

Para garantizar una arquitectura escalable, mantenible y de grado profesional, se han aplicado los siguientes estándares:

### Patrones de Diseño
* **Repository Pattern:** Se abstrajo la lógica de acceso a datos mediante interfaces, permitiendo que la capa de aplicación sea agnóstica al origen de los datos (SQL Server).
* **Decorator Pattern:** Utilizado para extender o modificar el comportamiento de los servicios (como la lógica de órdenes) de manera dinámica sin alterar la implementación base, facilitando el cumplimiento del principio Open/Closed.
* **Dependency Injection:** Implementado de forma nativa para desacoplar la creación de objetos de su uso, facilitando la inversión de control y las pruebas unitarias.
* **Data Transfer Object (DTO):** Empleado para el intercambio de información entre capas, protegiendo las entidades de dominio y optimizando la transferencia de datos al cliente mediante modelos especializados como `TableSummaryDto`.

### Principios SOLID Aplicados
El desarrollo se rigió bajo los principios **SOLID** para asegurar la calidad del software:

1.  **Single Responsibility (SRP):** Cada clase tiene una única razón para cambiar. Los controladores solo manejan peticiones HTTP, mientras que los servicios gestionan exclusivamente la lógica de negocio (como el cálculo de precios).
2.  **Open/Closed (OCP):** Gracias al uso de interfaces y al patrón **Decorator**, el sistema está abierto a la extensión (nuevos comportamientos) pero cerrado a la modificación de su núcleo.
3.  **Liskov Substitution (LSP):** Las clases derivadas o implementaciones de interfaces pueden sustituir a sus bases sin afectar el comportamiento del programa.
4.  **Interface Segregation (ISP):** Se definieron interfaces específicas (`IOrderService`, `ITableService`) en lugar de interfaces robustas y genéricas, evitando que las clases dependan de métodos que no utilizan.
5.  **Dependency Inversion (DIP):** Los módulos de alto nivel (Controladores) no dependen de módulos de bajo nivel (Repositorios), ambos dependen de abstracciones (Interfaces).

---

## ✨ Características Técnicas
* **Cálculo Automatizado de Subtotales:** La lógica de precios reside en el servidor; al crear una orden, el sistema consulta los precios vigentes en la DB para calcular el total, evitando manipulaciones externas.
* **Gestión de Relaciones Muchos-a-Muchos:** Implementación eficiente de la relación entre Órdenes y Platos mediante la entidad intermedia `DishOrder`.
* **Optimización de Respuestas JSON:** Uso de DTOs de resumen (`TableSummaryDto`, `OrderSummaryDto`) para eliminar referencias circulares y redundancia de datos.
* **Eager Loading Avanzado:** Configuración de `Includes` de múltiples niveles para retornar información completa (incluyendo categorías de platos y estados de mesa).

## 🚀 Instalación y Configuración

1.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/Canelo0228/RestaurantAPI.git](https://github.com/Canelo0228/RestaurantAPI.git)
    ```
2.  **Configurar Connection String:**
    En `appsettings.json` (capa WebApi), actualiza la propiedad `DefaultConnection` con tus credenciales de SQL Server.
3.  **Migraciones:**
    Ejecuta el siguiente comando en la Package Manager Console:
    ```powershell
    Update-Database
    ```
4.  **Ejecución:**
    Presiona `F5` en Visual Studio. La documentación interactiva se abrirá en `/swagger`.

## 🛠️ Mejoras Futuras
* [ ] Integración con Frontend moderno.
* [ ] Sistema de notificaciones en tiempo real con **SignalR** para cambios de estado de mesa.
* [ ] Reportes de ventas exportables a Excel/PDF.

---
**Desarrollado por Jose Canelo**
