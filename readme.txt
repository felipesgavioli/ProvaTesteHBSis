BANDO DE DADOS
--- Criar uma nova database chamada "ProvaHBSis"
--- Na pasta script contem o script inicial de cria��o das tabelas


SITE 
----- Configar multiple startup projects:
------- Clicar com o bot�o direito em cima da solution "ProjetoProvaHBSis" op��o "Properties"
----------- Vai aparecer uma telinha : selecionar a op��o "Multiple startup projects"
----------------- marcar os projetos ProvaHBSis.Api e ProvaHBSis.Web como o action "Start"

----- Ap�s o build ir� carregar os package do nuget que s�o necess�rios para executar o projeto

----- Acertar a string de conexao os projetos API para o nome do servidor que foi criado o database no passo acima
altera o Id e senha do servidor na string abaixo
ex: <add name="ProvaHBSis" connectionString="Data Source=*****Nome do servidor ********;Initial Catalog=ProvaHBSiss;Persist Security Info=True;User ID=sa;password=manager" providerName="System.Data.SqlClient" />

******************************************
N�o � necessario criar um usu�rio na base via insert into, no sistema no menu acima no canto direito contem o "cadastre-se"
********************************************
