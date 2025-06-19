## Functioneel
- [ ] Ondersteun minimaal de volgende toestandsdiagram-onderdelen:
    - [X] Initial en Final states
    - [X] Simple state (met On Entry/Do/On Exit state actions)
    - [X] Compound states (deze moeten meer dan 1 niveau diep genest kunnen worden)
    - [X] Transitions (met bijhorende triggers, guards en effects). Je mag er vanuit gaan dat er
    maximal 1 guard en effect op een transition gemodelleerd kan worden.
    - [X] Self-transitions
- [X] De structuur (voor formaat zie bijlage A) van het toestandsdiagram moet ingelezen kunnen
worden uit de bestanden die aangeleverd zijn op Brightspace.
- [X] De toestandsdiagrammen moeten in de Console tekstueel kunnen worden weergegeven. Zie
bijlage C voor een mogelijke weergave maar voel je vrij om zelf iets te kiezen.
- [X] Bij incorrecte toestandsdiagrammen moet de applicatie een foutmelding geven. Er dienen
drie validators gemaakt te worden die de onderstaande fouten in het diagram kunnen
detecteren (zie bijlage B voor nadere toelichting). Bij de 2e en 3e validator kun je zelf kiezen
welke van de twee varianten je wilt bouwen.
    - [X] State met transitions die niet deterministisch zijn
    - [X] Initial state met ingaande transities òf <mark style="background: #00ced1!important">Final state met uitgaande transities</mark>
    - [X] Transitie naar een compound state i.p.v. naar een simple state binnen de compound state òf <mark style="background: #00ced1!important">Onbereikbare state</mark>

Op Brightspace zijn een aantal bestanden met incorrecte FSM-definities te downloaden. Gebruik die in jouw tests om de validators te testen. Je hoeft niet zelf extra (exotische) ongeldige FSM’s te genereren om te testen of een validator in alle gevallen goed werkt.

## Non-Functioneel
- [X] Er wordt gelet op nette code en het juiste gebruik van verschillende design patterns. Er
moeten dan ook verschillende design patterns toegepast worden en uitgelegd kunnen
worden.
- [X] De Presentatielaag (user interface) en Modellaag moeten strikt gescheiden zijn. De
presentatielaag moet dus eenvoudig kunnen worden vervangen met een andere user
interface. Deze eis geldt ook als je niet de extra requirement van een 2e user interface
implementeert.
- [x] De opdracht moet gemaakt worden in Java of C#. Andere object georiënteerde talen zijn ook
toegestaan na toestemming van jouw practicumdocent.