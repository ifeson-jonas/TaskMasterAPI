# TaskMasterAPI 🧠📋

API RESTful feita em C# com .NET 8, usando Entity Framework Core, LINQ e arquitetura em camadas. Projeto criado para estudo prático de CRUD e boas práticas em back-end.

![CI](https://github.com/ifeson-jonas/TaskMasterAPI/actions/workflows/dotnet.yml/badge.svg)

---

## 🎥 Demonstração

<div align="center">
  <img src="docs/demo.gif" alt="Demonstração da API" width="700"/>
</div>

---

## 🚀 Tecnologias

- C# / .NET 8
- Entity Framework Core
- LINQ
- xUnit (testes)
- GitHub Actions (CI/CD)
- Docker (em progresso)
- PostgreSQL ou SQL Server (configurável via appsettings)

---

## 📂 Estrutura do Projeto

\`\`\`bash
TaskMasterAPI/
├── Controllers/          # Controladores REST
├── Data/                 # Contexto EF Core e configuração do banco
├── Models/               # Entidades do domínio
├── Interfaces/           # Interfaces para repositórios e serviços
├── Repositories/         # Implementação do acesso a dados
├── Services/             # Regras de negócio
├── Migrations/           # Migrações EF Core
├── Tests/                # Projetos de testes unitários
├── appsettings.json      # Configurações da aplicação
└── Program.cs            # Ponto de entrada da aplicação
\`\`\`

---

## ⚙️ Como rodar localmente

1. Clone o repositório:
   \`\`\`bash
   git clone https://github.com/ifeson-jonas/TaskMasterAPI.git
   cd TaskMasterAPI
   \`\`\`

2. Restaure os pacotes:
   \`\`\`bash
   dotnet restore TaskMasterSolution.sln
   \`\`\`

3. Compile o projeto:
   \`\`\`bash
   dotnet build TaskMasterSolution.sln --no-restore
   \`\`\`

4. Execute a aplicação:
   \`\`\`bash
   dotnet run --project TaskMasterAPI.csproj
   \`\`\`

5. Acesse no navegador:
   \`\`\`
   http://localhost:5000
   \`\`\`

---

## 🧪 Testes

Execute os testes unitários com:

\`\`\`bash
dotnet test TaskMasterSolution.sln
\`\`\`

---

## 🐳 Docker

Para usar o Docker (em progresso), crie sua imagem e rode o container:

\`\`\`bash
docker build -t taskmasterapi .
docker run -p 5000:5000 taskmasterapi
\`\`\`

---

## ⚙️ Configuração

Configure a string de conexão no \`appsettings.json\` ou via variável ambiente:

\`\`\`json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TaskMaster;User Id=sa;Password=your_password;"
  }
}
\`\`\`

---

## 🔗 Links úteis

- Repositório: https://github.com/ifeson-jonas/TaskMasterAPI
- Documentação oficial .NET: https://docs.microsoft.com/dotnet/
- Entity Framework Core: https://docs.microsoft.com/ef/core/

---

## 🤝 Contribuições

Contribuições são bem-vindas! Faça um fork, crie sua branch e envie pull request.

---

## 📄 Licença

MIT License


