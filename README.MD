# 💻 ProjectManager 💻
Project Manager é um webapp para gerenciamento de projetos desenvolvido para a disciplina de tópicos avançados de sistemas de informação!

## 🔧 Instalação 🔧
Para rodar a aplicação front end utilize o gerenciador de pacotes MVN, navegue até o diretório 'ProjectManager' e utilize o comando abaixo

```bash
mvn install 
```
Para rodar a API se faz necessário a instalação das dependências citadas no tópico abaixo, realizado automaticamente pela IDE visual Studio ou então excute o comando abaixo dentro do diretório "ProjectManager-WebApi"


```bash
dotnet restore
```

## 🧩 Stack usada 🧩

* Back End
    * C# 
    * DotNet (3.1.402)
    * Entity Framework (3.1.9)

* Front End
    * Angular 10
    * Highcharts
    * Rxjs
    * Ngx-bootstrap



## ⚡ Utilização ⚡
Para subir o projeto utilize os comandos a seguir dentro dos diretórios raiz do front end e back end respectivamente.

```
ng serve
dotnet watch run
```


O front end vai subir na porta 4200 e o back end na porta 5000, então verifique antes se tais portas estão livres.
