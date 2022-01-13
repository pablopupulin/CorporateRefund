# CorporateRefund

## Projeto para Solution Sprint 3 do MBA de Engenharia de Software na Fiap ON

Foram utilizadas as seguintes tecnologias: 
### BackEnd

> C# (Linguagem de programação);<br/>
> .net6 (Framework de persistência de dados);<br/>
> MongoDB (banco);<br/>
> Docker;<br/>
### Parte Mobile

> Kotlin (Linguagem de programação);<br/>
> Room (Framework de persistência de dados);<br/>
> Glide (Para deixar a escala em cinza);<br/>
> ML Kit (biblioteca de machine learning);<br/>
> SQLite (banco interno);<br/>
> Retrofit (REST);<br/>

## Descrição do serviço:<br/> 

1 - Recebe os dados ML-kit-Text-Recognition;<br/> 
2 - Sereliza os dados;<br/> 
3 - Salva os dados importantes (estabelecimento, o consumidor, os produtos comprados e o valor total) no MongoDB;<br/> 
4 - Devolve as informações quando solicitado;<br/> 

## Pré requisito para testar localmente

> visual studio 2022+;<br/> 
> .net6;<br/>
> Docker;<br/>

## Execução do projeto

1 - Executar o comando "Docker-composer up" na pasta raiz do projeto;<br/>
2 - Abrir o arquivo CorporateRefund no visual studio executar a aplicação (F5);<br/>
3 - O browser vai abrir a URL http://localhost:5000/swagger;<br/>
4 - Pode prosseguir com todos os testes;<br/>

## Link do projeto Mobile

https://github.com/MatheusLima1/ML-kit-Text-Recognition