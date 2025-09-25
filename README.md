# ESIG Projeto - Sistema de Gerenciamento de Pessoas

Este projeto foi desenvolvido em **ASP.NET WebForms (C#)** com integração ao **MySQL** para gerenciamento de pessoas, cargos e salários.

O sistema permite **cadastrar, editar, listar e excluir pessoas**, além de calcular salários com base em bônus definidos pela idade.

---

## Funcionalidades Implementadas

- Cadastro e edição de pessoas com vínculo a cargos.
- Definição automática de salário com base no cargo selecionado (campo somente leitura).
- Listagem de salários em ordem crescente por ID.
- Cálculo de bônus salarial de acordo com a idade:
  - Idade > 50 anos → bônus de 20% no salário.
  - Idade > 30 anos → bônus de 10% no salário.
- Ações na listagem:
  - **Editar** pessoa.
  - **Excluir** pessoa (com confirmação).
- Banco de dados MySQL integrado.

---

## Tecnologias Utilizadas

- **ASP.NET WebForms (C#)**
- **MySQL** (banco de dados relacional)
- **Bootstrap** (para estilização e responsividade)

---

## Estrutura do Projeto

- `Default.aspx` → Tela de cadastro/edição de pessoas.
- `Listar.aspx` → Tela de listagem de salários com ou sem cálculo de bônus.
- `PessoaRepository.cs` → Repositório para operações no banco (CRUD).
- `App_Data/Model` → (`Pessoa`, `Cargo`, `PessoaSalario`).
- `DBConexao.cs` → Classe utilitária para abrir conexão com o MySQL.

---

## Requisitos para Execução Local

1. **Ferramentas necessárias:**
   - [Visual Studio 2022](versão com suporte a ASP.NET WebForms).
   - [MySQL].

2. **Banco de dados:**
   - Crie um banco no MySQL (o arquivo do banco esta no projeto ´esig_db´).

3. **Configuração da conexão:**
   - Ajuste no arquivo `Web.config` conforme seu ambiente local:
     ```xml
     <connectionStrings>
	       <add name="MySqlConnection"
		       connectionString="Server=localhost;Database=esig_db;Uid=root;Pwd=senha;"
		       providerName="MySql.Data.MySqlClient" />
      </connectionStrings>
     ```

4. **Execução:**
   - Abra o projeto no Visual Studio.
   - Compile e execute (IIS Express ou servidor local do Visual Studio).
   - Acesse no navegador:
     ```
     http://localhost:xxxxx
     ```
   - Utilize a tela de **Criar/Editar Pessoas** para criar pessoas e depois vá para **Listar Pessoas** para visualizar os dados e salários.

---

## Observações

- O campo de salário **não pode ser editado manualmente**; ele é definido automaticamente de acordo com o cargo escolhido.
- Por algum motivo a importação da planilha no banco não funcionou 100%, das 3 mil pessoas apenas 115 foram importadas corretamente
