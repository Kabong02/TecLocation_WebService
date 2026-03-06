# TecLocation Web Service

Web Service ASP.NET (ASMX) que serve como backend para o aplicativo móvel TecLocation, com gestão de professores, turmas, salas, aulas e notificações em contexto educacional.

## Requisitos

- **Visual Studio** 2013 ou superior (com suporte a .NET 4.5.2)
- **.NET Framework 4.5.2**
- **SQL Server** (banco de dados TecLocation)
- **IIS** ou **IIS Express** (para execução do projeto)

## Estrutura do projeto

```
TecLocation_WebService/
├── TecLocation_WebService/
│   ├── cls_Operacoes.asmx          # Endpoint principal do Web Service
│   ├── cls_Operacoes.asmx.cs       # Implementação dos métodos
│   ├── Web.config                  # Configuração da aplicação
│   ├── Classes/
│   │   ├── Autenticacao.cs         # Cabeçalho SOAP (autenticação)
│   │   ├── cls_conexao.cs          # Acesso ao SQL Server
│   │   ├── cls_Parametros.cs       # Parâmetros para comandos SQL
│   │   ├── Criptografia.cs         # Criptografia MD5 (senhas)
│   │   ├── DiaSemana.cs            # Utilitário dias da semana
│   │   └── Email.cs                # Envio de e-mail (SMTP)
│   ├── Template/
│   │   └── EmailTemplate.html      # Template de e-mail
│   └── Properties/
├── packages/                       # Pacotes NuGet
└── README.md
```

## Como executar

1. Abra a solução no Visual Studio (`TecLocation_WebService.sln` ou o projeto `.csproj`).
2. Restaure os pacotes NuGet: clique com o botão direito na solução → **Restaurar Pacotes NuGet** (ou `dotnet restore` / Restore no NuGet).
3. Configure a **connection string** em `TecLocation_WebService/Classes/cls_conexao.cs` (ou mova para `Web.config` e use `ConfigurationManager.ConnectionStrings`) conforme seu ambiente (servidor, banco, usuário e senha).
4. Pressione **F5** ou use **Depurar → Iniciar** para rodar no IIS Express. O endpoint padrão será algo como:  
   `http://localhost:52068/cls_Operacoes.asmx`

## API (Web Methods)

Os métodos retornam **XML comprimido (GZIP)** codificado em **Base64**. O cliente deve decodificar e descomprimir para obter o XML.

| Método | Descrição |
|--------|-----------|
| `autentica_login` | Autenticação por login e senha (senha em MD5) |
| `obtem_professores` | Lista de professores |
| `obtem_turmas` | Lista de turmas |
| `obtem_semana` | Dias da semana |
| `obtem_salas` | Lista de salas |
| `obtem_aulas` | Aulas (por professor, dia da semana e turma) |
| `obtem_especialidades` | Especialidades |
| `obtem_usuario_especialidades` | Especialidades do usuário |
| `obtem_motivos_ausencia` | Motivos de ausência |
| `obtem_notificacoes` | Notificações por usuário |
| `atualiza_notificacao` | Marca notificação como lida |
| `atualiza_sala` | Atualiza sala da aula |
| `atualiza_aula` | Atualiza aula (haverá aula, motivo ausência, descrição) |
| `atualiza_senha` | Alteração de senha |
| `solicitacao_notificacao` | Solicita notificação para uma aula |
| `verifica_atualizacao` | Verificação de atualização do app |
| `envia_email` | Envio de e-mail (ex.: recuperação de senha) |

**Namespace SOAP:** `http://www.TecLocation.com.br/`

## Configuração

- **Banco de dados:** string de conexão em `Classes/cls_conexao.cs`. Em produção, recomenda-se usar `Web.config` → `connectionStrings`.
- **E-mail (SMTP):** em `Web.config` → `appSettings`: `LoginGmail`, `SenhaGmail`, `HostSMTP`. Ajuste conforme o ambiente e evite versionar senhas em repositório.

## Dependências principais (NuGet)

- Microsoft.ApplicationInsights (Web, WindowsServer, DependencyCollector, etc.)
- Microsoft.CodeDom.Providers.DotNetCompilerPlatform
- Microsoft.Net.Compilers

## Observações de segurança

- Não versionar connection strings e senhas em repositório; usar variáveis de ambiente ou configuração por ambiente (ex.: transformações de `Web.config`).
- Em produção, considerar migrar credenciais para um cofre de segredos (ex.: Azure Key Vault, variáveis do servidor).

---

*TecLocation Web Service – backend para o aplicativo TecLocation.*
