# Rubrik — Lichtschalter (Zusatzaufgabe, nur für die Betreuung)

- Kernidee: Anbieter und Abonnent kennen sich nur über das Ereignis; die
  Lampe meldet sich im Konstruktor an und muss sich bewusst abmelden.
- Typische Fehler: `Abkoppeln` meldet nur eines der beiden Ereignisse ab;
  Ereignis wird vor dem Umkehren von `IstAn` ausgelöst (Abonnenten sehen
  den alten Zustand); `Umschalten` ohne `?.`.
- Die Vorgabe mit öffentlichen Feldern verhält sich fast gleich, ist aber kein
  Ereignis (von außen aufrufbar); ein Test prüft das per Reflexion.
- Nachfrage: Wer hält wen am Leben, solange die Lampe nicht abgekoppelt ist?

Modellantwort: `solution/`.
