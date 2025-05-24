# TaskMasterAPI 🧠✅

API RESTful desenvolvida em **.NET 7** para gerenciamento de tarefas. O projeto segue a arquitetura de camadas (Controller → Service → Repository), conta com **testes automatizados**, **CI com GitHub Actions**, e suporte a **Docker** para facilitar o deploy e a execução local.

---

## Funcionalidades ⚙️

- [x] Criar, listar, atualizar e excluir tarefas
- [x] Validações de dados e mensagens de erro claras
- [x] Organização em camadas (Controller, Services, Repositories, Interfaces)
- [x] Testes automatizados com xUnit
- [x] CI com GitHub Actions
- [x] Suporte completo a Docker
- [x] Boas práticas com `.gitignore`, `appsettings.json`, etc

---

## Estrutura do Projeto 📁

\```bash
TaskMasterAPI/
├── Controllers/           # Endpoints da API
├── Models/                # Entidades e modelos de dados
├── Interfaces/            # Interfaces para serviços e repositórios
├── Services/              # Regras de negócio
├── Repositories/          # Lógica de acesso a dados
├── Tests/                 # Testes com xUnit
├── .github/workflows/     # Pipeline CI
├── Dockerfile             # Imagem da API
├── appsettings.json       # Configurações da aplicação
└── TaskMasterAPI.csproj   # Arquivo de projeto
\```

---

## Como Rodar com Docker 🐳

### Build da imagem:
\```bash
docker build -t taskmaster-api .
\```

### Subir o container:
\```bash
docker run -d -p 5000:80 taskmaster-api
\```

A API estará disponível em:  
[http://localhost:5000](http://localhost:5000)

---

## Executando os Testes ✅

\```bash
dotnet test
\```

---

## CI/CD com GitHub Actions 🚀

Este projeto utiliza **GitHub Actions** para rodar testes automatizados a cada `push` no repositório.

Arquivo da pipeline:  
`.github/workflows/dotnet.yml`

---

## Requisições Exemplo com cURL 🧪

### Criar uma nova tarefa:
\```bash
curl -X POST http://localhost:5000/api/tasks \
     -H "Content-Type: application/json" \
     -d '{"title": "Estudar C#", "description": "Aprender mais sobre APIs", "isCompleted": false}'
\```

---

## Contribuindo 🤝

Contribuições são bem-vindas! Sinta-se à vontade para abrir **issues** ou **pull requests**.

---

## Licença 📄

Este projeto está licenciado sob a [MIT License](LICENSE).

---

## Autor ✍️

**Jonas (ifeson-jonas)**  
Desenvolvedor Back-End apaixonado por .NET, C# e boas práticas de software.  
[GitHub](https://github.com/ifeson-jonas)

