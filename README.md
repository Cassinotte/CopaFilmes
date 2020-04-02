# Copa Filmes
Copa Filmes - Teste Técnico 

# Introdução 

Este projeto tem como objetivo demostrar minhas habilidades sobre o desenvolvimento de uma aplicação completa WEB, utilizando-se:

1.	Back-end: AspNet Core
2.  Front-end: Angular2+

Aplicação consiste em uma seleção de 8 filmees pelo usuario e o resultado final para o usuario do primeiro e segundo vencedor conforme criterio pre-determinado.

# Informações Iniciais

### Ambiente desenvolvimento

#### IDE (Integrated Development Environment )
* Visual Studio 2019  - Version 16.5.1
* Visual Studio Code - Version 1.43.2

#### Dependência

* [NodeJs](https://nodejs.org/en/)
* [AngularCLI](https://cli.angular.io/)
* [SDK Net Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

#### Configuração 

* Configuração da URL da API de busca dos filmes e configurado no back-end no arquivo appsettings, no solução CopaFilmeWeb, como exemplificado abaixo: 

```
{
  "ApiLamb": {
    "Url": "http://copafilmes.azurewebsites.net/api"
  }
}

```
* Configuração do arquivo config.dev.json ou config.deploy.json no front-end referente a configuração da URL da API ( caminho src/assets/config )

```
{
  "ApiBackend": "http://localhost/CopaFilmeWeb",
  "MaxFilmes" : 8
}


```

Obs. o back-end fiz a publicação direto no IIS atraves do Visual Studio, atraves da propriedade da solucao CopaWebFilme, conforme print abaixo:

![alt text](https://github.com/Cassinotte/CopaFilmes/blob/master/image/Configuracao%20IIS.PNG)

# Execucao - Demostração

Swagger - Back-End

![alt text](https://github.com/Cassinotte/CopaFilmes/blob/master/image/Swagger.PNG)

![alt text](https://github.com/Cassinotte/CopaFilmes/blob/master/image/Swagger%202.PNG)

Angular - Front-End

![alt text](https://github.com/Cassinotte/CopaFilmes/blob/master/image/Tela%201.PNG)

![alt text](https://github.com/Cassinotte/CopaFilmes/blob/master/image/Tela%202.PNG)

![alt text](https://github.com/Cassinotte/CopaFilmes/blob/master/image/Tela%203.PNG)

# Teste Unitario e Teste Automatizado

#### Abaixo demostração do Teste Unitario ( localizado na solução CopaFilme.TestUnit ):

![alt text](https://github.com/Cassinotte/CopaFilmes/blob/master/image/Teste%20Unitario.PNG)

![alt text](https://github.com/Cassinotte/CopaFilmes/blob/master/image/Teste%20Unitario%202.PNG)

#### Abaixo demostração do Teste Automatizado ( localizado na solução CopaFilme.TesteAutomatizado :


![alt text](https://github.com/Cassinotte/CopaFilmes/blob/master/image/Teste%20Automatizado.PNG)

![alt text](https://github.com/Cassinotte/CopaFilmes/blob/master/image/Teste%20Automatizado%202.PNG)

# Autor projeto
Eduardo Aparecido Cassinotte 
ea.cassinotte@hotmail.com
ea.cassinotte@gmail.com
