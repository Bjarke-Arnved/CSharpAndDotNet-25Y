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
   - `FullName` (string)
   - `Nickname` (string)
   - `HogwartsHouse` (string)
   - `InterpretedBy` (string)
   - `Children` (List<string>)
   - `Image` (string)
   - `Birthdate` (string)
   - `Index` (int)

---

### Opgave 2.2: Deserialiser JSON-strengen
1. Åbn [Opgave02/Program.cs](file:///c:/dotNet/CSharpAndDotNet/Lektion01/Opgave02/Program.cs).
2. Hent JSON-strengen fra `GetPotterJson()`.
3. Brug `JsonSerializer.Deserialize<List<PotterCharacter>>(json, options)` til at konvertere JSON-strengen til en liste af objekter.
   - **Husk:** Brug `JsonSerializerOptions` med `PropertyNameCaseInsensitive = true`, da feltnavnene i JSON matcher egenskabsnavnene uanset store/små bogstaver.

---

### Opgave 2.3: Udskriv og filtrer data
Når I har deseriliseret listen, skal I løse følgende i `Program.cs`:
1. Udskriv `FullName` og `HogwartsHouse` for alle karaktererne i konsollen.
2. Udskriv alle karakterer, der tilhører kollegiet **Gryffindor**.
3. Udskriv navnene på de karakterer, der har børn (`Children.Count > 0`), samt børnenes navne.

