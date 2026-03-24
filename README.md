# 🚗 Sistema de Gestión de Taller Mecánico

Aplicación web desarrollada con **ASP.NET Core MVC (.NET 8)** para gestionar clientes, vehículos y el historial de atenciones de un taller mecánico.

👉 Proyecto enfocado en modelar un flujo real de negocio, desde el registro del cliente hasta el detalle de los servicios realizados.

---

## 🚀 Demo

🔗 https://taller-mecanico-rs-api.azurewebsites.net/
** Usuario de Prueba ** => email: jerson@gmail.com     password: 123456

---

## 📌 Funcionalidades principales

* Gestión de usuarios (clientes)
* Registro de vehículos asociados a cada usuario
* Historial de atenciones por vehículo
* Registro de procedimientos realizados en cada atención
* Cálculo de costos (mano de obra y repuestos)
* Carga de imágenes (usuario y vehículo)
* Confirmación de cuenta por correo electrónico

---

## 🔄 Flujo del sistema

1. Registro de usuario
2. Asociación de uno o más vehículos
3. Registro de una atención (historia)
4. Agregado de procedimientos (detalles)

---

## 🛠️ Tecnologías utilizadas

* ASP.NET Core MVC (.NET 8)
* Entity Framework Core
* SQL Server
* ASP.NET Identity
* MailKit (envío de correos)
* Azure Blob Storage (imágenes)
* Azure App Service (deploy)

---

## 🧱 Arquitectura

Proyecto basado en el patrón **MVC (Model-View-Controller)** con uso de:

* Inyección de dependencias
* Entity Framework Core con migraciones
* Helpers para lógica auxiliar (correo, almacenamiento, conversión)

---

## ⚠️ Notas

* El sistema **no maneja pagos ni facturación**, solo registra costos
* Inicialmente desarrollado en .NET 5 y migrado a .NET 8

