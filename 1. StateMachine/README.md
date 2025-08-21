# 🧠 Uniwersalna Maszyna Stanów (State Machine) w C#

## 📌 Opis

Ten projekt zawiera generyczną implementację maszyny stanów (`StateMachine`) w języku C#, zaprojektowaną z myślą o łatwym rozszerzaniu i ponownym wykorzystaniu. Dzięki zastosowaniu wzorców projektowych takich jak **State**, **Factory** i **Composite**, możliwe jest tworzenie złożonych hierarchii stanów, które można łatwo zarządzać i testować.

System wspiera:
- Stany główne i podrzędne (substates)
- Przełączanie stanów z zachowaniem logiki wejścia/wyjścia
- Fabrykę stanów dla łatwego zarządzania instancjami
- Możliwość rozszerzenia o logikę specyficzną dla typu kontekstu (`T`)

## 🏗️ Struktura

### 🔧 Klasa bazowa `State<T>`

- Generyczna klasa abstrakcyjna dla każdego stanu
- Obsługuje logikę wejścia (`OnEnter`), aktualizacji (`OnUpdate`) i wyjścia (`OnExit`)
- Wspiera hierarchię stanów (super/substate)
- Przełącza stany za pomocą `SwitchState`

### 🧬 Interfejsy

- `IStateMachine<T>` – definiuje maszynę stanów z aktualnym stanem
- `IStateFactory<T>` – fabryka stanów, dostarcza stan początkowy
- `IRootState` – opcjonalny interfejs dla stanów głównych z dodatkowymi metodami (np. `HandleGravity`)

## 🎮 Przykład użycia w Unity

### ⚙️ Maszyna stanów

```csharp
public class Player : MonoBehaviour, IStateMachine<Player>
{
    private PlayerStateFactory _factory;
    private State<Player> _currentState;

    public State<Player> CurrentState
    {
        get => _currentState;
        set => _currentState = value;
    }

    private void Awake()
    {
        InitializeStateMachine();
    }

    private void Update()
    {
        _currentState.UpdateStates();
    }

    public void InitializeStateMachine()
    {
        _factory = new PlayerStateFactory(this);
        _currentState = _factory.InitialState;
        _currentState.OnEnter();
    }
}
```

### 🏭 Fabryka stanów

```csharp
public class PlayerStateFactory : IStateFactory<Player>
{
    private readonly Player _context;
    private readonly Dictionary<PlayerStates, PlayerState> _states = new();

    public State<Player> InitialState => Grounded();

    public PlayerStateFactory(Player context)
    {
        _context = context;

        _states[PlayerStates.Grounded] = new PlayerGroundedState(_context, this);
        _states[PlayerStates.Idle] = new PlayerIdleState(_context, this);
    }

    public PlayerState Grounded() => _states[PlayerStates.Grounded];
    public PlayerState Idle() => _states[PlayerStates.Idle];
}

enum PlayerStates
{
    Grounded,
    Idle
}
```

### 📦 Klasa bazowa stanów

```csharp
public abstract class PlayerState : State<Player>
{
    private readonly Player _context;
    private readonly PlayerStateFactory _factory;

    protected Player Context => _context;
    protected PlayerStateFactory Factory => _factory;

    protected PlayerState(Player context, PlayerStateFactory factory)
        : base(context, factory)
    {
        _context = context;
        _factory = factory;
    }
}
```

### 🧩 Przykładowy stan główny

```csharp
public class PlayerGroundedState : PlayerState, IRootState
{
    public PlayerGroundedState(Player context, PlayerStateFactory factory)
        : base(context, factory) { }

    public override void OnEnter() { }
    public override void OnUpdate() { }
    public override void OnExit() { }

    public override void CheckSwitchStates() { }
    public override void InitializeSubState() { }

    // Implementacja metod z IRootState
    public void HandleGravity() { }
}

```

## 🚀 Zalety

✅ **Uniwersalność**: Możliwość użycia z dowolnym typem kontekstu <**T**>

✅ **Skalowalność**: Obsługa zagnieżdżonych stanów

✅ **Czytelność**: Jasna separacja odpowiedzialności

✅ **Testowalność**: Łatwe mockowanie fabryk i stanów

## 📁 Pliki

| Plik                     | Opis                                         |
|--------------------------|----------------------------------------------|
| `State.cs`               | Klasa bazowa dla stanów                      |
| `IStateMachine.cs`       | Interfejs maszyny stanów                     |
| `IStateFactory.cs`       | Interfejs fabryki stanów                     |
| `IRootState.cs`          | Interfejs dla stanów głównych                |
| `Player.cs`              | Przykład użycia w Unity                      |
| `PlayerStateFactory.cs`  | Fabryka stanów gracza                        |
| `PlayerState.cs`         | Klasa bazowa dla stanów gracza               |
| `PlayerGroundedState.cs` | Konkretny stan główny                        |
| `PlayerIdleState.cs`     | Konkretny stan podrzędny (np. bezruchu)      |

