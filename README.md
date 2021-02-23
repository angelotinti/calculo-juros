# Calculadora de Juros

Projeto para efetuar cálculo de juros com taxa de juros fixa em 1% e valores inical e tempo em meses providos pelo usuário.

# Subindo o projeto

Após efetuar o clone do projeto, basta executar o seguinte comando:

    docker-compose up --build -d

# Testando o projeto
Após o projeto estar no ar, você poderá acessar os seguintes endereços:

**TaxaJuros**
 - http://localhost:5001/swagger
 - http://localhost:5001/api/taxa-juros

**CalculaJuros**
 - http://localhost:5000/swagger
 - http://localhost:5000/api/calcula-juros
 - http://localhost:5000/api/show-me-the-code

# Exemplo
Ao efetuar a seguinte chamada:
>http://localhost:5000/api/calcula-juros?valorInicial=100&tempoEmMeses=12

O navegador deve apresentar a resposta:
>112.68
