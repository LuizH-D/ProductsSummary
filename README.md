COMO O PROGRAMA FUNCIONA:

- Lê um path do arquivo de origem dos Produtos (no qual deve conter o nome, preço e quantidade inseridos da seguinte forma: nome,preço,quantidade e cada um dos produtos devem estar em linhas diferentes) e realiza a leitura dos dados no arquivo, criando uma lista de Produtos.
1. Para ocorrer a leitura do arquivo sem erro, o arquivo deve estar nomeado de "Products.txt", pois nele existe uma lógica onde se diminui os caracteres do nome do arquivo no Path (\Products.txt) para ser criada uma nova pasta na pasta do arquivo de origem.
   
- É criada uma pasta nomeada de "Summary".
  
-Em seguida, o programa irá criar um arquivo nomeado de "Summary.csv" na pasta "Summary", contendo o nome e o valor total dos Produtos da seguinte forma: nome,valortotal(preço * quantidade).
1. Neste trecho, o programa abordará uma lógica onde caso não exista nenhum arquivo nomeado de "Summary.csv" na pasta "Summary", ele será criado. Caso exista um arquivo nomeado de "Summary.csv", o programa irá criar um novo arquivo nomeado de "Summary(quantidade de arquivo Summary*.csv na pasta).csv".

   
UM POUCO MAIS A RESPEITO DO PROJETO:

Estou criando este projeto com o intuito de praticar meu desenvolvimento com a linguagem C#. Também ressalto que o projeto não está 100%, pois a lógica de criar o arquivo final, por exemplo, ainda não está boa. Logo, toda atualização de melhora será adicionada.
