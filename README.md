# Controle de Estoque · Inventory Control · Control de Inventario

[![Versão](https://img.shields.io/badge/vers%C3%A3o-1.0.0-blue)](https://github.com/john-dalton-27/ControleDeEstoque/releases)
[![Plataforma](https://img.shields.io/badge/platform-Windows-lightgrey)](https://dotnet.microsoft.com/en-us/apps/desktop)
[![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet)](https://learn.microsoft.com/dotnet/)

---

## 📌 Sobre o Projeto | About the Project | Sobre el Proyecto

**PT-BR:**  
Sistema desktop para controle de estoque, desenvolvido com C#, Windows Forms e SQLite. Permite gerenciar produtos com entrada, saída, busca e visualização detalhada.

**EN:**  
Desktop inventory management system built with C#, Windows Forms, and SQLite. Supports product registration, stock movement, search, and display.

**ES:**  
Sistema de escritorio para control de inventario desarrollado en C#, Windows Forms y SQLite. Permite gestionar productos, entradas, salidas y búsquedas.

---

## 🚀 Download

📦 [Clique aqui para baixar o instalador (.msi)](https://github.com/john-dalton-27/ControleDeEstoque/releases/download/v1.0/Inventory.msi)

> Não é necessário instalar banco de dados ou dependências extras. O sistema cria o arquivo automaticamente no primeiro uso.

---

## 🛠️ Tecnologias

- **Linguagem:** C# (.NET 8.0)
- **Interface:** Windows Forms
- **Banco de Dados:** SQLite
- **Instalador:** Advanced Installer
- **Compatibilidade:** Windows 10/11 (x64)

---

## ⚙️ Funcionalidades

- Cadastro e listagem de produtos
- Controle de entrada e saída de estoque
- Busca dinâmica por ID, nome, quantidade ou preço
- Banco de dados local criado automaticamente (`AppData`)
- Interface adaptável a redimensionamento de tela

---

## 📂 Estrutura do Projeto

ControleDeEstoque/
- bin/
- DatabaseHelper.cs
- DataView.cs
- ProductRegistration.cs
- SaleDialog.cs
- Program.cs
- README.md


---

## 📁 Local de armazenamento do banco

O arquivo `inventory.db` é criado automaticamente em:
C:\Users\SEU_USUARIO\AppData\Roaming\ControleDeEstoque\


---

## 🔧 Como executar localmente

```bash
git clone https://github.com/john-dalton-27/ControleDeEstoque.git
```
1- Abra com o Visual Studio 2022

2- Compile no modo Release

3- Execute o ControleDeEstoque.exe via IDE ou pasta de saída (bin\Release\net8.0-windows\publish)

## 👤 Autor
[John Dalton](https://github.com/john-dalton-27)

Unity Game Developer & C# Programmer.
