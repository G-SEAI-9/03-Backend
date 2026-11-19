# Field, Property oder Methode?

**Schau, was direkt nach dem Namen steht:**

| Nach dem Namen                                    | Das ist …              | Beispiel                                     |
| ------------------------------------------------- | ---------------------- | -------------------------------------------- |
| `;` oder `= …;`                                   | **Field**              | `private readonly List<string> _items = [];` |
| `{ get; set; }`                                   | **Auto-Property**      | `public Guid Id { get; } = Guid.NewGuid();`  |
| `=> …` oder `{ get { … } }`                       | **Property mit Logik** | `public int Count => _items.Count;`          |
| `( … )`, Name = Klassenname, **kein** Rückgabetyp | **Konstruktor**        | `public Basket(string owner) { … }`          |
| `( … )`                                           | **Methode**            | `public void Add(string item) { … }`         |

## Beim Aufruf

```cs
new Basket("Kim") // Konstruktor → mit new
basket.Count      // Field oder Property → keine Klammern
basket.Add("A")   // Methode → immer Klammern
```

Field oder Property? → **Hover** in VS Code.

## Wofür?

- **Field** → interne Daten, `private`, `_camelCase`
- **Property** → Daten nach außen, `PascalCase`
- **Konstruktor** → Objekt bei `new` startklar machen
- **Methode** → etwas tun (`Add`, `Remove`, `Calculate…`)

## Wer darf zugreifen?

| Modifier    | Zugriff aus …                    |
| ----------- | -------------------------------- |
| `public`    | überall                          |
| `internal`  | demselben Projekt                |
| `protected` | eigener Klasse + **Unterklassen** |
| `private`   | nur eigener Klasse (Standard)    |

## Methoden bei Vererbung

| Schlüsselwort | Body?               | Unterklasse …          |
| ------------- | ------------------- | ---------------------- |
| `abstract`    | nein, endet mit `;` | **muss** überschreiben |
| `virtual`     | ja, `{ … }`         | **kann** überschreiben |
| `override`    | ja, `{ … }`         | überschreibt hier      |

```cs
public abstract void Attack();      // nur in einer abstract class
public virtual void Heal() { … }
public override void Attack() { … } // in der Unterklasse
```

## Achtung: `=>` ist nicht `=`

```cs
public List<string> A => []; // jeder Zugriff: NEUE Liste
public List<string> B { get; } = []; // einmal angelegt
```
