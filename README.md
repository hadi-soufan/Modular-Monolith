# Modular Monolith

## 🏗️ Architecture

This project implements a **Modular Monolith** architecture pattern, combining the benefits of modular design with the simplicity of a monolithic deployment. Each module is independently developed with clear boundaries while sharing the same process and database.

### Architectural Principles

- **Domain-Driven Design (DDD)**: Rich domain models with business logic encapsulation
- **CQRS Pattern**: Command Query Responsibility Segregation using MediatR
- **Clean Architecture**: Clear separation of concerns across layers
- **Event-Driven Communication**: Asynchronous module communication via integration events
- **Vertical Slice Architecture**: Feature-focused organization within modules

## 📦 Modules

The application is divided into four core business modules:

### 1. **Users Module**
Handles user management and authentication
- User registration and profile management
- Identity management via Keycloak
- Permission-based authorization
- User profile updates

### 2. **Events Module**
Manages event creation and lifecycle
- Event creation and publishing
- Event cancellation workflows (with Saga pattern)
- Ticket type configuration and pricing
- Event search and filtering

### 3. **Ticketing Module**
Handles ticket sales and order processing
- Shopping cart management
- Order creation and processing
- Payment processing
- Ticket issuance
- Customer management

### 4. **Attendance Module**
Manages event attendance and check-ins
- Attendee registration
- Ticket check-in functionality
- Attendance tracking
- Event-specific attendee management

## 🛠️ Technology Stack

### Backend
- **.NET 8**: LTS version of .NET
- **C# 12**: Modern C# features
- **ASP.NET Core**: Web API framework
- **Entity Framework Core**: ORM with PostgreSQL provider
- **MediatR**: In-process messaging for CQRS
- **FluentValidation**: Request validation
- **Dapper**: Lightweight ORM for queries

### Infrastructure & Messaging
- **MassTransit**: Distributed application framework
- **RabbitMQ**: Message broker for asynchronous communication
- **Redis**: Distributed caching and saga state storage
- **PostgreSQL**: Primary database

### Authentication & Authorization
- **Keycloak**: Identity and access management
- **JWT Bearer Authentication**: Stateless authentication

### Observability
- **Serilog**: Structured logging
- **Seq**: Log aggregation and analysis
- **OpenTelemetry**: Distributed tracing
- **Jaeger**: Trace visualization

### DevOps
- **Docker & Docker Compose**: Containerization
- **Health Checks**: Application health monitoring

## 🏛️ Module Structure

Each module follows a consistent layered architecture:

```
Module/
├── Domain/              # Domain entities, value objects, domain events
├── Application/         # Use cases, commands, queries, handlers
├── Infrastructure/      # Data access, external integrations
├── Presentation/        # API endpoints, DTOs
├── IntegrationEvents/   # Cross-module event contracts
└── PublicApi/          # Public contracts for other modules
```

## 🔄 Communication Patterns

### Inter-Module Communication
- **Integration Events**: Asynchronous event-based communication via RabbitMQ
- **Module Isolation**: Modules communicate only through integration events and public APIs
- **Inbox/Outbox Pattern**: Ensures reliable message delivery and idempotency

### Design Patterns
- **Repository Pattern**: Data access abstraction
- **Unit of Work**: Transaction management
- **Saga Pattern**: Distributed transaction coordination (e.g., event cancellation)
- **Idempotent Handlers**: Duplicate message handling prevention
- **Domain Events**: In-module event handling

## 🚀 Getting Started

### Prerequisites
- Docker Desktop
- . NET 8 SDK (for local development)

### Running with Docker Compose

```bash
docker-compose up -d
```

This will start all required services:
- **API**: http://localhost:5000 (HTTP) / https://localhost:5001 (HTTPS)
- **Keycloak**: http://localhost:18080 (admin/admin)
- **Seq**: http://localhost:8081
- **RabbitMQ Management**: http://localhost:15672 (guest/guest)
- **Jaeger UI**: http://localhost:16686
- **PostgreSQL**: localhost:5432
- **Redis**: localhost:6379

### Services

| Service | Container Name | Ports |
|---------|---------------|-------|
| API | Evently.Api | 5000, 5001 |
| Gateway | Evently.Gateway | 3000, 3001 |
| PostgreSQL | Evently.Database | 5432 |
| Keycloak | Evently. Identity | 18080, 19000 |
| Seq | Evently.Seq | 5341, 8081 |
| Redis | Evently.Redis | 6379 |
| Jaeger | Evently.Jaeger | 4317, 4318, 16686 |
| RabbitMQ | Evently.Queue | 5672, 15672 |

## 📊 Database Schema

Each module maintains its own database schema within the shared PostgreSQL database:
- `users` schema - Users module
- `events` schema - Events module
- `ticketing` schema - Ticketing module
- `attendance` schema - Attendance module

## 🧪 Testing

The project includes comprehensive architecture tests to enforce architectural constraints:
- Module independence validation
- Layer dependency rules
- Naming convention enforcement
- Pattern compliance checks

## 📁 Project Structure

```
Evently/
├── src/
│   ├── API/                    # API layer
│   │   ├── Evently.Api/       # Main API project
│   │   └── Evently.Gateway/   # API Gateway
│   ├── Common/                # Shared infrastructure
│   │   ├── Evently.Common. Application/
│   │   ├── Evently.Common.Domain/
│   │   ├── Evently.Common. Infrastructure/
│   │   └── Evently.Common. Presentation/
│   └── Modules/               # Business modules
│       ├── Users/
│       ├── Events/
│       ├── Ticketing/
│       └── Attendance/
└── test/
    └── Evently. ArchitectureTests/
```

## 🔑 Key Features

- **Minimal APIs**: Modern endpoint routing with ASP.NET Core
- **Background Jobs**: Quartz.NET for scheduled tasks (Outbox/Inbox processing)
- **Resilience**: Built-in retry policies and circuit breakers
- **Health Checks**: Comprehensive health monitoring for all dependencies
- **Swagger/OpenAPI**: API documentation and testing
- **Module Configuration**: Separate configuration files per module
- **Distributed Caching**: Redis-based caching with fallback to in-memory

## 🎯 Approach & Best Practices

### Code Organization
- Feature-focused vertical slices within modules
- Strict module boundaries enforced by architecture tests
- Shared kernel in Common layer for cross-cutting concerns

### Data Management
- One database, multiple schemas approach
- Each module manages its own migrations
- Outbox pattern for reliable event publishing
- Inbox pattern for idempotent event consumption

### Scalability
- Designed for future microservices migration
- Module independence enables independent scaling
- Async communication reduces coupling
- Distributed caching for performance

## 📝 License

[Your License Here]

## 👥 Contributing

[Your Contributing Guidelines Here]
