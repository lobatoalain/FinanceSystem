**Desenvolvedor**

Nome: Alain Rosewelt Silva Lobato

E-mail: nialalobato@gmail.com

GitHub: https://github.com/lobatoalain

LinkedIn: https://www.linkedin.com/in/alainlobato


**Ferramentas Utilizadas**

.NET 8.0: Framework principal utilizado para desenvolver a API e o frontend.

SQL Server: Banco de dados relacional utilizado para armazenar as informações das notas fiscais.

Docker: Utilizado para containerizar a aplicação, garantindo que ela rode de forma consistente em qualquer ambiente.

Bootstrap: Framework CSS utilizado para estilizar as páginas web.

Visual Studio: IDE utilizada para desenvolvimento do projeto.

**Instruções de Setup e Uso**

**1. Clonar o Repositório**

Clone o repositório do GitHub para sua máquina local:

git clone https://github.com/lobatoalain/FinanceSystem.git

**2. Configuração do Banco de Dados**

Execute o script SQL para criar o banco de dados e as tabelas necessárias:

-- Script com os comandos está no arquivo setup.sql na raiz do projeto

**3. Configuração do Ambiente**

Configure as strings de conexão no arquivo appsettings.Development.json de acordo com o seu ambiente de desenvolvimento.

**4. Build e Deploy com Docker**

Navegue até a pasta raiz do projeto e execute os seguintes comandos para construir e rodar os containers:

docker-compose build
docker-compose up

**5. Acessar as Aplicações**

Após subir os containers, você poderá acessar as aplicações nos seguintes endereços:

API: https://localhost:7042/swagger
WebApp: https://localhost:7057

**6.  Desligar os Containers**

Para parar e remover os containers criados, utilize o seguinte comando:

docker-compose down
