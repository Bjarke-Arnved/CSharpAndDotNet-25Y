---
marp: true
theme: default
paginate: true
header: 'C# Records'
footer: 'C# & .NET Undervisning'
---

# Records i C#
### Uforanderlige data-typer, Value Equality og moderne syntaks

---

## Indholdsfortegnelse

1. **Hvad er en Record?**
2. **Hvorfor bruge Records? (Klasser vs. Records)**
3. **Positionel Syntaks (Positional Records)**
4. **Immutability (Uforanderlighed)**
5. **Nondestructive Mutation (`with` expression)**
6. **Value Equality (Værdisammenligning)**
7. **Record Structs (`record struct`)**
8. **Opsummering & Best Practices**

---

## 1. Hvad er en Record?

- Introduceret i **C# 9** (og udvidet i C# 10).
- En særlig reference-type (eller værditype), som er optimeret til **immutable dataholdere**.
- Genererer automatisk metoder til:
  - Værdisammenligning (`Equals`, `==`, `!=`).
  - Pæn udskrift (`ToString()`).
  - Hash-kode generering (`GetHashCode()`).
  - Dekonstruktion (`Deconstruct()`).

---

## 2. Klasser vs. Records

| Egenskab | Standard Class (`class`) | Record (`record`) |
| :--- | :--- | :--- |
| **Primært formål** | Objektorienteret adfærd & tilstand | DTOs, data-bærende objekter |
| **Standard Tilstand** | Mutable (Foranderlig) | Immutable (Uforanderlig) |
| **Sammenligning (`==`)** | Reference equality (Adresse i hukommelsen) | Value equality (Værdier af felter) |
| **Kopi med ændringer** | Manuel kopiering | `with` expression |
| **`ToString()`** | Returnerer typenavnet | Formaterer alle feltværdier |

---

## 3. Positionel Syntaks (Positional Records)

Du kan definere en hel record på én enkelt linje!

```csharp
// Opretter automatisk init-only properties, constructor og Deconstruct
public record Person(string FirstName, string LastName);

// Anvendelse:
var person = new Person("Anders", "And");
Console.WriteLine(person.FirstName); // Anders

// Pæn ToString() udskrift automatisk:
Console.WriteLine(person); 
// Output: Person { FirstName = Anders, LastName = And }
```

---

## 4. Immutability (Uforanderlighed)

Som standard er egenskaber på en positionel record **Init-Only**.

```csharp
var p = new Person("Anna", "Jensen");

// Dette giver en COMPILER FEJL:
// p.FirstName = "Maria"; 
```

**Hvorfor immutability?**
- **Trådsikkerhed (Thread safety)**: Kan sikkert deles mellem tråde uden locks.
- **Forudsigelighed**: Objekters tilstand ændrer sig ikke uventet.
- **Færre bugs**: Ingen utilsigtet sideeffekt fra andre dele af koden.

---

## 5. Nondestructive Mutation (`with` expression)

Hvordan "ændrer" man noget der er uforanderligt?  
Man opretter en **ny kopi** med de ønskede ændringer via `with` nøgleordet.

```csharp
var original = new Person("Mette", "Frederiksen");

# Opretter en kopi med ændret efternavn
var modified = original with { LastName = "Hansen" };

Console.WriteLine(original); // Person { FirstName = Mette, LastName = Frederiksen }
Console.WriteLine(modified); // Person { FirstName = Mette, LastName = Hansen }
```

---

## 6. Value Equality (Værdisammenligning)

Klasser sammenligner referencer (hukommelsesadresse).  
Records sammenligner **værdierne** af deres properties.

```csharp
// Standard klasser:
var c1 = new MyClass("Test");
var c2 = new MyClass("Test");
Console.WriteLine(c1 == c2); // False (forskellige objekter i RAM)

// Records:
var r1 = new Person("Ole", "Eriksen");
var r2 = new Person("Ole", "Eriksen");
Console.WriteLine(r1 == r2); // True! (alle værdier er ens)
```

---

## 7. Standard Property Syntaks i Records

Du behøver ikke bruge positionel syntaks. Du kan også skrive dem mere manuelt:

```csharp
public record Product
{
    public required string Name { get; init; }
    public decimal Price { get; set; } // Kan gøres mutable hvis nødvendigt
}
```

- `record` uden `struct` eller `class` angivet er som standard en **reference type** (`record class`).

---

## 8. Record Structs (C# 10+)

Hvis du har brug for værdi-type performance (stack allocation) kombineret med record-features:

```csharp
// Værditype (struct) med record funktionalitet
public readonly record struct Point(double X, double Y);

var p1 = new Point(1.0, 2.5);
var p2 = p1 with { Y = 5.0 };
```

- Standard `record struct` er **mutable**, medmindre du tilføjer `readonly`.

---

## 9. Opsummering & Best Practices

- Brug **Records** til data-objekter (DTO'er, Web API responses, event beskeder osv.).
- Brug **Standard Classes** til objekter med kompleks adfærd, metoder og ændrbar tilstand.
- Udnyt `with` udtrykket til sikker modificering af immutable data.

### Spørgsmål? 🚀
