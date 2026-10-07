# Conclusiones y Trabajo Futuro

**Estudiante:** Violet Gutiérrez  
**Carnet:** 2021-0906i  
**Grupo:** 5S3-SIS-S

---

## 6.1 Conclusiones

El rediseño arquitectónico de SISTESIS-UNI mediante el C4 Model + API-First demuestra ser superior a UWE para las necesidades actuales:

1. Abstracción multinivel: Los 4 niveles del C4 Model permiten comunicar la arquitectura a diferentes audiencias.
2. Desacoplamiento real: La separación frontend/backend mediante APIs RESTful permite evolucionar cada componente independientemente.
3. Documentación viva: Swagger UI genera documentación interactiva siempre actualizada.
4. Seguridad moderna: JWT proporciona autenticación stateless, ideal para SPAs y aplicaciones móviles.
5. Escalabilidad: Clean Architecture facilita la migración a microservicios cuando sea necesario.

## 6.2 Evaluación del Uso de Microservicios

Se evaluó la migración a microservicios y se concluyó que:

- Ventajas: Escalabilidad horizontal, despliegue independiente, tecnología heterogénea.
- Desventajas: Mayor complejidad operativa, necesidad de service mesh, latencia de red.
- Decisión: Mantener monolito modular en Clean Architecture para MVP. Evaluar microservicios cuando:
  - El tráfico supere 10,000 req/s.
  - El equipo supere 5 desarrolladores.
  - Se requiera escalar componentes específicos.

## 6.3 Evaluación de GraphQL

Se evaluó GraphQL como alternativa a REST:

- Ventajas: Cliente pide exactamente los datos que necesita, reducción de over-fetching.
- Desventajas: Complejidad en caché, mayor superficie de ataque, curva de aprendizaje.
- Decisión: Mantener REST para MVP. Evaluar GraphQL en:
  - El frontend móvil (menor consumo de datos).
  - Consultas complejas con múltiples entidades.

## 6.4 Trabajo Futuro

| # | Tarea | Prioridad |
|---|-------|-----------|
| 1 | Implementar microservicio anti-plagio (Python/FastAPI + RabbitMQ) | Alta |
| 2 | Migrar a PostgreSQL para producción | Alta |
| 3 | Implementar refresh tokens | Media |
| 4 | Agregar validaciones con FluentValidation | Media |
| 5 | Implementar paginación en GET /theses | Media |
| 6 | Logging estructurado con Serilog | Media |
| 7 | Tests unitarios con xUnit | Media |
| 8 | Docker Compose para desarrollo | Baja |
| 9 | CI/CD con GitHub Actions | Baja |
| 10 | Migrar a GraphQL para móvil | Baja |

## 6.5 Referencias

- Brown, S. (2018). The C4 Model for Software Architecture.
- Microsoft. (2024). Clean Architecture with ASP.NET Core.
- Fowler, M. (2002). Patterns of Enterprise Application Architecture.
- Fielding, R. (2000). Architectural Styles and the Design of Network-based Software Architectures.
- Universidad Nacional de Ingeniería. (2026). Guía de Diseño de Sistemas en Internet.

---

**Fin del reporte.**