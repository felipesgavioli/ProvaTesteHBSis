BANDO DE DADOS
--- Criar uma nova database chamada "ProvaHBSis"
--- Na pasta script contem o script inicial de criação das tabelas


SITE 
----- Configar multiple startup projects:
------- Clicar com o botão direito em cima da solution "ProjetoProvaHBSis" opção "Properties"
----------- Vai aparecer uma telinha : selecionar a opção "Multiple startup projects"
----------------- marcar os projetos ProvaHBSis.Api e ProvaHBSis.Web como o action "Start"

----- Após o build irá carregar os package do nuget que são necessários para executar o projeto

----- Acertar a string de conexao os projetos API para o nome do servidor que foi criado o database no passo acima
altera o Id e senha do servidor na string abaixo
ex: <add name="ProvaHBSis" connectionString="Data Source=*****Nome do servidor ********;Initial Catalog=ProvaHBSiss;Persist Security Info=True;User ID=sa;password=manager" providerName="System.Data.SqlClient" />

******************************************
Não é necessario criar um usuário na base via insert into, no sistema no menu acima no canto direito contem o "cadastre-se"
********************************************
