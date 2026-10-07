\# Propuesta de Diseño C4



\*\*Estudiante:\*\* Violet Gutiérrez  

\*\*Carnet:\*\* 2021-0906i  

\*\*Grupo:\*\* 5S3-SIS-S



\---



\## 4.1 Diagrama de Contexto (Nivel 1)



\*\*Propósito:\*\* Mostrar SISTESIS-UNI como una caja negra y sus interacciones con actores externos.



\*\*Actores:\*\*

\- \*\*Estudiante UNI:\*\* Somete protocolos y propuestas de tesis.

\- \*\*Docente/Tutor:\*\* Revisa, observa y aprueba tesis.

\- \*\*Administrador TIC:\*\* Gestiona usuarios, roles y parámetros.

\- \*\*SIAT UNI:\*\* Sistema de control académico central (integración).

\- \*\*Servicio de Notificaciones:\*\* SMTP institucional.



\*\*Ver diagrama:\*\* `diagrams/c4-nivel1-contexto.mmd`



\## 4.2 Diagrama de Contenedores (Nivel 2)



\*\*Propósito:\*\* Descomponer SISTESIS-UNI en contenedores desplegables.



\*\*Contenedores:\*\*

\- \*\*SPA Angular:\*\* Interfaz web para usuarios.

\- \*\*Mobile App Flutter:\*\* Consultas rápidas e intimaciones.

\- \*\*API RESTful (.NET 8):\*\* Lógica de negocio y control de acceso.

\- \*\*PostgreSQL/SQLite:\*\* Almacenamiento relacional de metadatos.

\- \*\*MinIO/S3:\*\* Almacenamiento de documentos PDF.



\*\*Ver diagrama:\*\* `diagrams/c4-nivel2-contenedores.mmd`



\## 4.3 Diagrama de Secuencia (API-First)



\*\*Propósito:\*\* Modelar el flujo de autenticación JWT y carga asíncrona.



\*\*Flujo:\*\*

1\. Estudiante ingresa credenciales.

2\. Cliente envía `POST /api/v1/auth/login`.

3\. API valida contra BD.

4\. API devuelve JWT.

5\. Cliente usa JWT para `POST /api/v1/theses`.

6\. API sube PDF a storage.

7\. API persiste metadatos.

8\. API devuelve `201 Created`.



\*\*Ver diagrama:\*\* `diagrams/secuencia-auth.mmd`



\## 4.4 Justificación Técnica



| Decisión | Alternativas | Justificación |

|----------|--------------|---------------|

| .NET 8 | Node.js, Java Spring | Tipado fuerte, ecosistema maduro, rendimiento |

| Clean Architecture | N-Tier, Hexagonal | Independencia de frameworks, testabilidad |

| JWT | Session, OAuth2 | Stateless, escalable, estándar |

| SQLite/PostgreSQL | MongoDB, MySQL | Relacional, transaccional, gratuito |

| Swagger/OpenAPI | Postman, RAML | Estándar de la industria, interactivo |

| Mermaid.js | PlantUML, Draw.io | Versionable en Git, renderizable en GitHub |



\## 4.5 Evidencia de Implementación



\*\*Swagger UI funcionando:\*\* `http://localhost:5072/swagger/index.html`



\*\*Endpoints probados:\*\*

\- ✅ `POST /api/v1/auth/login` → 200 OK + JWT

\- ✅ `POST /api/v1/theses` → 201 Created

\- ✅ `GET /api/v1/theses` → 200 OK con datos

\- ✅ `GET /api/v1/theses/{id}` → 200 OK

\- ✅ `PATCH /api/v1/theses/{id}/status` → 204 No Content



\*\*Respuesta de creación de tesis:\*\*

```json

"88922281-be01-4723-9dbb-574f931ea0a8"

