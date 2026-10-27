# Explicit interface implementation

Read **sections 9.4**, "**Explicit Interface Implementation**" (page 646), and **9.1.4.3**, "**Multiple Inheritance**" (page 634), in the book: A class can implement any number of interfaces.

Both `IZaehler` and `IMesser` require a `Wert()` method, but they mean different things. Although `Sensor` fulfills both contracts with a single public `Wert()` method, it cannot distinguish between them. Open `Sensor.cs`:

1. `Sensor`: **Explicitly** implement both members with the interface name prefixed and without access modifiers: `int IZaehler.Wert() => 1;` and `int IMesser.Wert() => 2;`. After that, there is no longer an `s.Wert()`; the call can only be made via an interface reference (`((IZaehler)s).Wert()` or `(s as IMesser).Wert()`).
2. `Geraet`: A public (implicit) implementation returns 1 and also serves `IZaehler`; an explicit implementation for `IMesser` returns 2.

In `Program.cs`, you'll notice that `s.Wert()` no longer compiles after the refactoring.
