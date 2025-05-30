
# LojaDoManoel API

## Sobre

API em .NET 8 para gerenciamento de pedidos e empacotamento de produtos, usando SQL Server como banco de dados, tudo rodando via Docker.

---

## Pré-requisitos

- Docker instalado ([https://www.docker.com/get-started](https://www.docker.com/get-started))
- Docker Compose (normalmente já vem com Docker)

---

## Como rodar

1. Clone o repositório

```bash
git clone https://github.com/clayton-oly/LojaDoManoel.git
cd LojaDoManoel.git
```

2. Suba os containers com Docker Compose

```bash
docker-compose up --build
```

Isso vai:

- Subir o container do SQL Server
- Subir o container da API .NET
- Aplicar as migrations no banco automaticamente

---

## Acessando a API

- A API estará disponível em: `http://localhost:5000`
- Para usar o Swagger (documentação interativa), acesse:  
`http://localhost:5000/swagger/index.html`

---

## Configurações

- A conexão com o banco está configurada no `docker-compose.yml` via variável de ambiente:

```yaml
ConnectionStrings__DefaultConnection=Server=sqlserver,1433;Database=LojaManoelDB;User Id=sa;Password=LojaManoel@2025;TrustServerCertificate=true;
```

- Para alterar, edite essa variável no `docker-compose.yml`

---

## Serviços

- `sqlserver`: Container com SQL Server 2019
- `api`: Container da API .NET 8

---

## Comandos úteis

- Parar os containers:

```bash
docker-compose down
```

- Rodar a API sem rebuild (se já tiver feito build):

```bash
docker-compose up
```

---
