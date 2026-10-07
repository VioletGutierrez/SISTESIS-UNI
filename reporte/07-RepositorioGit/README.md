\---INICIO---



SISTESIS-UNI

Sistema de Gestión de Tesis Monográficas — Universidad Nacional de Ingeniería (UNI).



Rediseño arquitectónico con C4 Model + API-First.



Autora: Violet Gutiérrez (2021-0906i) — Grupo 5S3-SIS-S

Asignatura: Diseño de Sistemas en Internet

Fecha: 6 de octubre de 2026



📚 Documentación

Sección	Enlace

Carátula	reporte/01-Caratula

Resumen Ejecutivo	reporte/02-ResumenEjecutivo

Análisis Crítico	reporte/03-AnalisisCritico

Propuesta C4	reporte/04-PropuestaC4

Especificación OpenAPI	reporte/05-OpenAPI

Conclusiones	reporte/06-Conclusiones

Repositorio Git	reporte/07-RepositorioGit

📐 Diagramas Mermaid

Diagrama	Enlace

C4 Nivel 1 — Contexto	diagrams/c4-nivel1-contexto.mmd

C4 Nivel 2 — Contenedores	diagrams/c4-nivel2-contenedores.mmd

Secuencia Auth JWT	diagrams/secuencia-auth.mmd

Ejercicio 1 — Error 413	diagrams/ejercicio1-error413.mmd

Ejercicio 2 — Anti-plagio	diagrams/ejercicio2-antiphagio.mmd

💻 Código Fuente

Proyecto	Enlace

API (Controllers)	src/SistesisUni.Api

Dominio (Entidades)	src/SistesisUni.Core.Domain

Aplicación (DTOs)	src/SistesisUni.Core.Application

Infraestructura (EF Core + JWT)	src/SistesisUni.Infrastructure

🛠️ Tecnologías

Backend: ASP.NET Core 8 / C#



Arquitectura: Clean Architecture (4 capas)



Base de Datos: SQLite (dev) / PostgreSQL (prod)



Autenticación: JWT Bearer



ORM: Entity Framework Core 8



Documentación API: Swagger / OpenAPI 3.0



Diagramas: Mermaid.js



Control de Versiones: Git + GitHub



🚀 Cómo Ejecutar

bash

git clone https://github.com/VioletGutierrez/SISTESIS-UNI.git

cd SISTESIS-UNI

dotnet restore

dotnet build

cd src/SistesisUni.Api

dotnet run

Abrir en el navegador: http://localhost:5072/swagger



Credenciales de prueba:



Username: vguti



Password: uni2026



Repositorio: https://github.com/VioletGutierrez/SISTESIS-UNI



\---FIN---

