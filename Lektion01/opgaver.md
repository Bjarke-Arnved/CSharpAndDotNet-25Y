# Opgaver: Lektion 01

## Opgave 1: Serialisering med JsonSerializer og Records

I denne opgave skal I arbejde med JSON-serialisering i C# ved hjælp af `System.Text.Json.JsonSerializer`.
Formålet er at tage eksisterende C#-objekter og konvertere (serialisere) dem til JSON-strenge, som udskrives i konsollen.

I mappen `Opgave01/model` finder I følgende `record` modeller:
- `Item(string Name, decimal Price)` - Repræsenterer en enkelt vare.
- `OrderLine(Item Item, int Quantity)` - Repræsenterer en ordrelinje med en vare og et antal.
- `Order(List<OrderLine> Lines)` - Repræsenterer en ordre bestående af en liste af ordrelinjer.

Åbn [Program.cs](file:///c:/dotNet/CSharpAndDotNet/Lektion01/Opgave01/Program.cs), hvor der er oprettet tre hjælpemetoder som returnerer C#-objekter: `GetItem()`, `GetOrder()` og `GetOrders()`.

---

### Opgave 1.1: Serialiser et enkelt objekt (`Item`)
1. Hent `Item`-objektet fra `GetItem()`.
2. Brug `JsonSerializer.Serialize(item)` til at konvertere objektet til en JSON-streng.
3. Udskriv den genererede JSON-streng i konsollen.

---

### Opgave 1.2: Serialiser et sammensat objekt (`Order`) med pæn formatering
1. Hent `Order`-objektet fra `GetOrder()`.
2. Serialiser `Order`-objektet til en JSON-streng.
3. Brug `JsonSerializerOptions` med `WriteIndented = true`, så JSON-strengen bliver formateret pænt med indrykninger og linjeskift.
4. Udskriv den formaterede JSON-streng i konsollen.

---

### Opgave 1.3: Serialiser en liste af objekter (`List<Order>`)
1. Hent listen af ordrer (`List<Order>`) fra `GetOrders()`.
2. Serialiser listen af ordrer til en JSON-streng (gerne med indrykninger `WriteIndented = true`).
3. Udskriv den samlede JSON-streng i konsollen.

---

### Hjælp & Eksempel (Opgave 1)
Husk at I kan bruge `JsonSerializerOptions` til at tilpasse formatet af den genererede JSON:

```csharp
var options = new JsonSerializerOptions
{
    WriteIndented = true // Gør JSON pæn og læsbar med indrykninger
};

string jsonString = JsonSerializer.Serialize(myObject, options);
Console.WriteLine(jsonString);
```

---

## Opgave 2: Deserialisering af Harry Potter data

I denne opgave skal I arbejde med JSON-deserialisering. I skal konvertere en JSON-streng med Harry Potter karakterer til C#-objekter og udskrive/filtrere dataene.

JSON-dataene hentes via metoden `GetPotterJson()` i [Opgave02/Program.cs](file:///c:/dotNet/CSharpAndDotNet/Lektion01/Opgave02/Program.cs).

Mappen `Opgave02/model` er oprettet til at indeholde de domænemodeller (klasser eller records), I skal bruge.

---

### Opgave 2.1: Opret en model til karaktererne
1. Undersøg strukturen af JSON-dataene i `GetPotterJson()` i [Opgave02/Program.cs](file:///c:/dotNet/CSharpAndDotNet/Lektion01/Opgave02/Program.cs).
2. Opret en ny `record` eller `class` (f.eks. `PotterCharacter`) i mappen `Opgave02/model`.
3. Tilføj egenskaber, der matcher feltnavnene i JSON:

---

### Opgave 2.2: Deserialiser JSON-strengen
1. Åbn [Opgave02/Program.cs](file:///c:/dotNet/CSharpAndDotNet/Lektion01/Opgave02/Program.cs).
2. Hent JSON-strengen fra `GetPotterJson()`.
3. Brug `JsonSerializer.Deserialize<List<PotterCharacter>>(json, options)` til at konvertere JSON-strengen til en liste af objekter.
   - **Husk:** Brug `JsonSerializerOptions` med `PropertyNameCaseInsensitive = true`, så feltnavnene i JSON matcher egenskabsnavnene uanset store/små bogstaver.

---

### Opgave 2.3: Udskriv og filtrer data
Når I har deseriliseret listen, skal I løse følgende i `Program.cs`:
1. Udskriv `FullName` og `HogwartsHouse` for alle karaktererne i konsollen.
2. Udskriv alle karakterer, der tilhører kollegiet **Gryffindor**.
3. Udskriv navnene på de karakterer, der har børn (`Children.Count > 0`), samt børnenes navne.

---

## Opgave 3: Bankkonto & Validering (Properties)

I denne opgave skal I øve jer i at bruge forskellige typer af properties (`get`, `set`, `init`, private setters og beregnede egenskaber).

### Opgavebeskrivelse:
1. Opret en klasse `BankAccount` med følgende egenskaber:
   - `AccountNumber` (string): En `init`-only property (må kun sættes ved oprettelse).
   - `Owner` (string): Property med `get` og `set`. Sørg for at kaste en `ArgumentException`, hvis værdien er tomt eller `null`.
   - `Balance` (decimal): Skal have `get` og `private set` — saldoen må **ikke** kunne ændres direkte udefra.
   - `IsOverdrawn` (bool): En beregnet property (`get => Balance < 0;`), som returnerer `true`, hvis saldoen er i minus.
   - `FormattedBalance` (string): En beregnet property, der returnerer saldoen formateret som valuta (f.eks. `"1.250,00 DKK"`).
2. Tilføj metoderne `Deposit(decimal amount)` og `Withdraw(decimal amount)` til at indsætte og hæve penge på kontoen.
3. Test klassen ved at oprette en konto, foretage indbetalinger og udbetalinger, og udskrive kontoens status.

---

## Opgave 4: Produkt- og Ordrehåndtering (Records & `with`-expressions)

I denne opgave skal I arbejde med uforanderlige (immutable) `record` typer, non-destructive mutation med `with`-udtryk og deconstruction.

### Opgavebeskrivelse:
1. Opret en positional record `Product`:
   ```csharp
   public record Product(string Id, string Name, decimal Price, string Category);
   ```
2. I jeres `Program.cs`:
   - Opret et par produkter (f.eks. en bærbar computer, en mus, osv.).
   - **Opdatering med `with`:** Opret en ny udgave af et produkt med tilbudspris ved at bruge `with`-syntaksen (f.eks. `var discounted = product with { Price = 199.95m };`). Udskriv både det originale produkt og det nye produkt for at verificere, at det oprindelige produkt ikke har ændret sig.
   - **Deconstruction:** Brug deconstruction til at udpakke navnet og prisen direkte fra recorden:
     ```csharp
     var (id, name, price, category) = product;
     Console.WriteLine($"Vare: {name}, Pris: {price}");
     ```

---

## Opgave 5: Geografiske Punkter & Sammenligning (Value vs. Reference Equality)

I denne opgave skal I undersøge den fundamentale forskel på **Reference Equality** (Klasser) og **Value Equality** (Records).

### Opgavebeskrivelse:
1. Opret en almindelig klasse `GeoPointClass` med egenskaberne `Latitude` og `Longitude`.
2. Opret en positional record `GeoPointRecord(double Latitude, double Longitude)`.
3. I `Program.cs`:
   - Opret to identiske instanser af klassen:
     ```csharp
     var c1 = new GeoPointClass { Latitude = 56.15, Longitude = 10.20 };
     var c2 = new GeoPointClass { Latitude = 56.15, Longitude = 10.20 };
     ```
   - Opret to identiske instanser af recorden:
     ```csharp
     var r1 = new GeoPointRecord(56.15, 10.20);
     var r2 = new GeoPointRecord(56.15, 10.20);
     ```
4. Sammenlign `c1 == c2` og `r1 == r2` og udskriv resultaterne i konsollen. Forklar hvorfor `c1 == c2` giver `false` mens `r1 == r2` giver `true`.
5. Udskriv både klasse-objektet og record-objektet med `Console.WriteLine()` og observer forskellen i deres automatisk genererede `ToString()` output.


