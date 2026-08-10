---
marp: true
theme: default
paginate: true
header: '.NET Økosystemet'
footer: 'C# & .NET Undervisning'
---

# Introduktion til .NET Økosystemet
### Et overblik over platformen, arkitekturen og værktøjerne

---

## Indholdsfortegnelse

1. **Hvad er .NET?**
2. **Historien og Evolutionen** (.NET Framework vs .NET Core vs .NET 5+)
3. **Kernekomponenter** (CLR, BCL, JIT, GC)
4. **Programmeringssprog** (C#, F#, VB.NET)
5. **Applikationstyper & Frameworks** (Web, Desktop, Cloud, Mobil)
6. **Værktøjer & Pakkehåndtering** (NuGet, CLI, IDEs)
7. **Resume & Spørgsmål**

---

## 1. Hvad er .NET?

- Et **open-source**, **cross-platform** udviklingsframework skabt af Microsoft.
- Bruges til at bygge mange forskellige typer applikationer:
  - Web, Mobil, Desktop, Gaming, IoT, Cloud og AI.
- Stærkt typed med **Garbage Collection (GC)**.
- Giver mulighed for høj ydeevne (performance) og sikkerhed.

---

## 2. .Net Historie

- **2002**: .NET Framework 1.0 *(Kun Windows)*
- **2016**: .NET Core 1.0 *(Cross-platform & Open Source)*
- **2020**: .NET 5 *(Samling af økosystemet)*
- **2023**: .NET 8 *(LTS - Høj performance & Cloud-native)*
- **2026**: .NET 10 *(Seneste version)*

---

- **.NET Framework (Windows Only)**: Den oprindelige legacy version.
- **.NET Core**: Genfortolkningen – hurtig, modulær og tværplatform (Windows, Linux, macOS).
- **Modern .NET (.NET 5+)**: Den fælles platform i dag.

---



## 3.1 Vigtige Begreber i Runtime

- **CIL / IL (Common Intermediate Language)**:
  - Bytecode som alle .NET sprog kompileres til.
- **CLR (Common Language Runtime)**:
  - Virtuel maskine/execution engine, der afvikler IL.
- **JIT (Just-In-Time Compiler)**:
  - Oversætter IL til maskinkode lige før kørsel.
- **BCL (Base Class Library)**:
  - Standardbibliotek med indbyggede typer (`String`, `List<T>`, `HttpClient`, `File`, osv.).

---

## 4. Sprog i .NET Økosystemet

- **C#**:
  - Det primære og mest populære sprog.
  - Objektorienteret, stærkt typet, moderne og i konstant udvikling (nuv. C# 12/13).
- **F#**:
  - Et funktionelt-først sprog til datatunge, matematiske og komplekse domæner.
- **VB.NET (Visual Basic)**:
  - Objektorienteret sprog med en mere læsbar/verbal syntaks (primært legacy).

---

## 5.1 ASP.NET Core & Blazor

- **ASP.NET Core Web API**:
  - Byg lyn hurtige RESTful og gRPC web services.
- **ASP.NET Core MVC & Razor Pages**:
  - Traditionel server-side rendering af HTML.
- **Blazor**:
  - Byg interaktive Single Page Applications (SPA) med **C# i stedet for JavaScript** (via WebAssembly eller Server-side).

---

## 6. Værktøjer & Økosystem

- **Pakkehåndtering**:
  - **NuGet**: Det officielle pakkearkiv til .NET (svarende til npm i Node.js eller PyPI i Python).
- **IDEs & Redaktører**:
  - **Visual Studio**: Fuld-skala IDE til Windows.
  - **Visual Studio Code**: Letvægts-editor med C# Dev Kit extension.
  - **JetBrains Rider**: Populært tværplatform IDE.
- **CLI (Command Line Interface)**:
  - `dotnet new`, `dotnet build`, `dotnet run`, `dotnet test`, `dotnet publish`.

---

## 7. Eksempel: Enkel C# CLI Workflow

Standard kommandoer i terminalen:

```bash
# Opret en ny konsol-applikation
dotnet new console -n MinApp

# Gå til mappen
cd MinApp

# Tilføj en NuGet pakke (f.eks. Newtonsoft.Json)
dotnet add package Newtonsoft.Json

# Kør applikationen
dotnet run
```

---

## Opsummering

- **.NET** er en moderne, hurtig og tværplatform udviklingsplatform.
- **C#** er hovedsproget, som kompileres til **IL** og afvikles i **CLR**.
- Du kan bygge **alt**: Web, Cloud, Mobil, Desktop og Spil.
- Stort og stærkt open-source økosystem støttet af Microsoft.
