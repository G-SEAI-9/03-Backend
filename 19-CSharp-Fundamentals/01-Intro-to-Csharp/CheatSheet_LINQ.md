# LINQ CheatSheet

## Lazy – laufen erst im `foreach` oder mit `.ToList()`

Liefern ein `IEnumerable<T>` zurück und lassen sich aneinanderketten.

### Filtern & Begrenzen

| Methode | Macht                    | Beispiel                       | JS-Gegenstück  |
| ------- | ------------------------ | ------------------------------ | -------------- |
| `Where` | behält passende Elemente | `list.Where(c => c.Age >= 25)` | `.filter()`    |
| `Take`  | nimmt nur die ersten `n` | `list.Take(3)`                 | `.slice(0, 3)` |

### Umformen (Projizieren) & Kombinieren

| Methode      | Macht                                                    | Beispiel                           | JS-Gegenstück |
| ------------ | -------------------------------------------------------- | ---------------------------------- | ------------- |
| `Select`     | formt jedes Element um (Property, `new { … }`, `record`) | `list.Select(c => c.Name)`         | `.map()`      |
| `SelectMany` | macht verschachtelte Listen flach                        | `days.SelectMany(d => d.Sessions)` | `.flatMap()`  |
| `Zip`        | verbindet Listen Position für Position                   | `a.Zip(b, (x, y) => $"{x} @ {y}")` | –             |

### Sortieren

| Methode                       | Macht                                                | Beispiel                                        |
| ----------------------------- | ---------------------------------------------------- | ----------------------------------------------- |
| `OrderBy`                     | aufsteigend sortieren                                | `list.OrderBy(c => c.Age)`                      |
| `OrderByDescending`           | absteigend sortieren                                 | `list.OrderByDescending(c => c.Balance)`        |
| `ThenBy` / `ThenByDescending` | 2. Kriterium bei gleichen Werten (nie 2× `OrderBy`!) | `list.OrderBy(c => c.City).ThenBy(c => c.Name)` |

### Verbinden & Gruppieren

| Methode     | Macht                                                      | Beispiel                                                                                          |
| ----------- | ---------------------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| `GroupBy`   | teilt in Gruppen (`g.Key` + innerer Loop über `g`)         | `list.GroupBy(e => e.Department)`                                                                 |
| `Join`      | verbindet 2 Listen über gemeinsamen Key (wie SQL `JOIN`)   | `emps.Join(asg, e => e.Id, a => a.EmployeeId, (e, a) => new { e.Name, a.Project })`               |
| `GroupJoin` | wie `Join`, aber 1 Gruppe pro Element links + Liste rechts | `emps.GroupJoin(asg, e => e.Id, a => a.EmployeeId, (e, list) => new { e.Name, Projects = list })` |

---

## Sofort ausgeführt – kein `foreach` nötig

Liefern **einen Wert** oder eine **fertige Collection**. Danach endet die LINQ-Kette (außer bei `ToList`/`ToArray`).

### Aggregationen & Prüfungen

| Methode       | Liefert                           | Beispiel                              | JS-Gegenstück |
| ------------- | --------------------------------- | ------------------------------------- | ------------- |
| `Count`       | Anzahl (`int`)                    | `list.Count(c => c.City == "Berlin")` | `.length`     |
| `Sum`         | Summe                             | `list.Sum(c => c.Balance)`            | `.reduce()`   |
| `Average`     | Durchschnitt (`double`/`decimal`) | `list.Average(c => c.Age)`            | –             |
| `Min` / `Max` | kleinster / größter Wert          | `list.Max(c => c.Balance)`            | –             |
| `Any`         | `true`, wenn mind. 1 passt        | `list.Any(c => !c.Active)`            | `.some()`     |
| `All`         | `true`, wenn alle passen          | `list.All(c => c.Currency == "EUR")`  | `.every()`    |

### Einzelnes Element & Materialisieren

| Methode              | Liefert                              | Hinweis                                                 |
| -------------------- | ------------------------------------ | ------------------------------------------------------- |
| `First`              | 1. Treffer                           | ⚠️ wirft `InvalidOperationException`, wenn nichts passt |
| `FirstOrDefault`     | 1. Treffer oder `null` (bei Klassen) | sicherer – vor Zugriff auf `is null` prüfen             |
| `ToList` / `ToArray` | fertige `List<T>` / `T[]`            | friert den Stand sofort ein (Materialisierung)          |

---

## Drei Merksätze

- **Original bleibt unverändert:** LINQ mutiert die Ausgangsliste nicht.
- **Erst filtern, dann sortieren:** `.Where(…).OrderByDescending(…).Take(3).Select(…).ToList()`
- **Fokus für den Alltag:** **`Where`**, **`Select`** (DTOs) und **`Join`** brauchst du am häufigsten – auch später mit EF Core / Datenbanken.
