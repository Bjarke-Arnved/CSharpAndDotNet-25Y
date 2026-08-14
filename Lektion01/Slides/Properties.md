---
marp: true
theme: default
paginate: true
header: 'C# Properties'
footer: 'C# & .NET'
---

# Properties i C#
### Indkapsling, data-validering og moderne syntaks

---

## Indholdsfortegnelse

1. **Hvad er en Property?**
2. **Hvorfor bruge Properties? (Indkapsling)**
3. **Auto-implemented Properties**
4. **Full Properties med Backing Fields**
5. **Access Modifiers (get/set adgangs-styring)**
6. **Init-Only Properties (`init`)**
7. **Expression-Bodied Properties**
8. **Required Properties (`required`)**
9. **Opsummering**

---

## 1. Hvad er en Property?

- En **Property** (egenskab) kombinerer et **felt (field)** med **metoder (getters/setters)**.
- Giver mulighed for at læse, skrive eller beregne værdien af et privat felt.
- Burde bruges frem for offentlige felter (`public fields`) for at overholde god OOP-skik.

```csharp
// Offentligt felt (DÅRLIG stil)
public int Age;

// Property (GOD stil)
public int Age { get; set; }
```

---

## 2. Hvorfor Properties? (Indkapsling)

**Datastrøm ved indkapsling:**
`Klient / Ekstern Kode` ➔ `Property (get / set)` ➔ `Private Backing Field (_age)`

---

**Fordele ved indkapsling:**
- **Datavalidering**: Forhindrer ugyldige tilstande (f.eks. negativ alder).
- **Read-Only / Write-Only**: Styrer adgang til data.
- **Fleksibilitet**: Du kan ændre intern logik uden at ødelægge ekstern kode.

---

## 3. Auto-implemented Properties

Brug denne syntaks, når der ikke kræves ekstra validering eller logik.

```csharp
public class Person
{
    // C# opretter automatisk et skjult "backing field" bag kulisserne
    public string Name { get; set; }
    
    // Default værdi kan sættes direkte
    public int Age { get; set; } = 18;
}
```

---

## 4. Full Properties (med Backing Field)

Når du har brug for validering, bruger du et eksplicit **backing field** (privat variabel).

```csharp
public class Person
{
    private int _age; // Private backing field

    public int Age
    {
        get 
        { 
            return _age; 
        }
        set 
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Alder kan ikke være negativ");
            _age = value;
        }
    }
}
```

---

## 5. Access Modifiers i get / set

Du kan begrænse skriveadgang ved at sætte en access modifier på `set`.

```csharp
public class BankAccount
{
    // Alle kan læse saldoen, men kun koden inde i klassen kan ændre den
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
            Balance += amount;
    }
}
```

---

## 6. Read-Only & Init-Only (`init`)

### Read-Only (kun `get`)
```csharp
public class Person
{
    // Kan kun sættes i constructoren eller via initialisering
    public string Id { get; }
    
    public Person(string id) => Id = id;
}
```
---

### Init-Only (C# 9+)
Tillader tildeling under **Object Initialization**, men kan ikke ændres bagefter.

```csharp
public class Car
{
    public string LicensePlate { get; init; }
}

// Anvendelse:
var car = new Car { LicensePlate = "AB 12 345" };
// car.LicensePlate = "XY 98 765"; // COMPILER FEJL!
```

---

## 7. Expression-Bodied Properties

Noget kode kan skrives meget kort med lambda-syntaks (`=>`).

### Beregnet property (Computed property):
```csharp
public class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }

    // Genereres dynamisk hver gang den tilgås (Read-only)
    public double Area => Width * Height;
}
```

---

### Kort get/set syntaks:
```csharp
private string _name;
public string Name
{
    get => _name;
    set => _name = value ?? "Ukendt";
}
```

---

## 8. Required Properties (C# 11+)

Bruges til at gennemtvinge, at en property **skal** sættes ved instantiering.

```csharp
public class Student
{
    public required string StudentId { get; init; }
    public string Name { get; set; }
}

// Gyldigt:
var student = new Student { StudentId = "S12345", Name = "Anna" };

// FEJL! 'StudentId' mangler:
// var student = new Student { Name = "Anna" };
```

---

## 9. Sammenligningsoversigt

| Type | Syntaks | Hvornår bruges det? |
| :--- | :--- | :--- |
| **Auto Property** | `{ get; set; }` | Standard for simple data-holdere |
| **Full Property** | `{ get { ... } set { ... } }` | Ved behov for validering / logik |
| **Private Set** | `{ get; private set; }` | Ekstern read, intern write |
| **Init Only** | `{ get; init; }` | Immutabilitet efter oprettelse |
| **Computed** | `=> expression;` | Afledte/beregnede værdier |
| **Required** | `required { get; set; }` | Obligatorisk sæt ved oprettelse |

---

## Opsummering

- Brug **Properties** frem for offentlige felter for at opnå god indkapsling.
- Brug **Auto-implemented Properties** som udgangspunkt.
- Skift til **Full Properties** når du har brug for validering i `set` eller logik i `get`.
- Udnyt moderne C# features som `init`, `=>` og `required` for mere sikker og ren kode.

### Spørgsmål? 🚀
