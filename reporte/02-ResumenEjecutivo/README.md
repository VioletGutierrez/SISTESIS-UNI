\# Resumen Ejecutivo



\*\*Estudiante:\*\* Violet Gutiérrez  

\*\*Carnet:\*\* 2021-0906i  

\*\*Grupo:\*\* 5S3-SIS-S  

\*\*Asignatura:\*\* Diseño de Sistemas en Internet  

\*\*Fecha:\*\* 6 de octubre de 2026



\---



El presente documento describe el rediseño arquitectónico del \*\*Sistema de Gestión de Tesis Monográficas (SISTESIS-UNI)\*\* de la Universidad Nacional de Ingeniería. Históricamente, el modelado de aplicaciones web académicas empleaba metodologías dirigidas por modelos como \*\*UWE (UML Web Engineering)\*\*, que si bien ofrecían abstracción para páginas dinámicas tradicionales, presentaban limitaciones significativas para arquitecturas modernas desacopladas.



La propuesta adoptada combina el \*\*C4 Model\*\* de Simon Brown con un enfoque \*\*API-First\*\* apoyado en \*\*Diagramas de Secuencia UML\*\*. Esta metodología permite una abstracción multinivel (Contexto, Contenedores, Componentes, Código) y separa claramente la vista del sistema de los flujos cronológicos de integración.



La implementación técnica utiliza \*\*.NET 8\*\* con \*\*Clean Architecture\*\*, organizada en cuatro capas: Domain, Application, Infrastructure y API. Se implementó autenticación mediante \*\*JWT\*\*, persistencia con \*\*Entity Framework Core 8\*\* sobre \*\*SQLite\*\* (desarrollo) y \*\*PostgreSQL\*\* (producción), y documentación interactiva con \*\*Swagger UI\*\*.



El resultado es un sistema mantenible, escalable y compatible con arquitecturas distribuidas, superando las limitaciones operativas de UWE en sistemas con Single Page Applications. Se proponen extensiones futuras con microservicios, GraphQL y procesamiento asíncrono mediante colas de mensajes.



\*\*Palabras clave:\*\* C4 Model, API-First, Clean Architecture, .NET 8, JWT, UWE, Microservicios, SISTESIS-UNI.

