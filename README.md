# VariacaoAtivoApi - ASP.Net Core Web API com Docker Compose e PostgreSQL
* Disponiliza um endpoint para importar o histórico de preços de ativos buscando na Api https://finance.yahoo.com/ e armazena em um banco de dados PostgreSQL.
* Disponibiliza um endpoint que calcula a variação de preços dos últimos 30 dos ativos.

## Como executar
1. Clonar projeto `git clone https://github.com/acslook/VariacaoAtivoApi.git`

2. Entrar na pasta do projeto pelo cmd e executar comando `cd VariacaoAtivoApi`

3. Criar imagem `docker-compose build`

4. Executar imagem `docker-compose up`

5. Abrir Swagger http://localhost:8000/swagger

6. Para importar o histórico de preços dos últimos 30 dias de um ativo, executar o endpoint 
`POST: FinanceYahooIntegration` passando o código do ativo

7. Para consultar a variação de preços de um ativo, executar o endpoint
`GET: /AtivoFinanceiro/{codigoAtivo}/ObterVariacaoUltimos30Dias` passando o código do ativo na rota
