# Schedule - Narzędzie do konwersji grafiku pracy do formatu CSV

## O projekcie
**Schedule** to aplikacja, którą stworzyłem w C# na platformie .NET 6, korzystając z Windows Forms. Projekt powstał z potrzeby automatyzacji powtarzalnych zadań związanych z zarządzaniem harmonogramami i ich konwersją do formatu CSV, który można łatwo zaimportować do Google Calendar.

Głównym celem było stworzenie narzędzia, które oszczędza czas, eliminuje błędy ręcznego przepisywania i pozwala mi rozwijać umiejętności programistyczne w praktycznym kontekście.

## Co potrafi aplikacja?
- **Automatyzacja**: Wprowadzasz dane w określonym formacie, a aplikacja generuje gotowy plik CSV do importu.
- **Obsługa różnych typów wydarzeń**: Od standardowych zmian, przez dyżury, aż po bardziej specyficzne wydarzenia, jak krwiodawstwo czy szkolenia BHP.
- **Walidacja danych**: Aplikacja sprawdza poprawność wprowadzonych informacji, co minimalizuje ryzyko błędów.
- **Nowoczesne podejście do dat i godzin**: Wykorzystuję typy `DateOnly` i `TimeOnly`, które są dostępne w .NET 6, aby precyzyjnie zarządzać czasem.

## Dlaczego ten projekt?
Ten projekt to coś więcej niż tylko narzędzie. To mój sposób na:
- **Rozwój umiejętności**: Praca z C#, .NET 6 i Windows Forms pozwoliła mi lepiej zrozumieć tworzenie aplikacji desktopowych.
- **Naukę testowania**: W projekcie zaimplementowałem testy jednostkowe przy użyciu xUnit, co pomogło mi zrozumieć, jak pisać solidny i niezawodny kod.
- **Automatyzację codziennych zadań**: Lubię automatyzować powtarzalne czynności, a ten projekt jest tego świetnym przykładem.


## Moje umiejętności w praktyce
Podczas pracy nad tym projektem:
- **Zrozumiałem, jak projektować aplikacje desktopowe**: Windows Forms to świetne narzędzie do tworzenia prostych interfejsów użytkownika.
- **Opanowałem testy jednostkowe**: Dzięki xUnit nauczyłem się pisać testy, które sprawdzają poprawność działania aplikacji.
- **Pracowałem z nowoczesnymi funkcjami C#**: Wykorzystałem typy `DateOnly` i `TimeOnly`, które są idealne do zarządzania datami i godzinami.
- **Rozwinąłem umiejętność analizy danych**: Implementacja logiki parsowania harmonogramów wymagała dokładności i przemyślanego podejścia.

## Przykładowe funkcje
- **HandlerPDC**: Obsługuje wydarzenia związane z podciąganiem, ustawiając odpowiedni opis i czas.
- **HandlerSWL1 i HandlerSWL2**: Obsługują złożone harmonogramy z wieloma liniami.
- **HandlerBlood**: Zadanie krwiodawstwo.


## Podsumowanie
**Schedule** to projekt, który łączy moje zamiłowanie do automatyzacji z chęcią nauki i rozwoju. Jest to narzędzie, które faktycznie wykorzystuję w codziennym życiu, a jednocześnie świetny poligon doświadczalny do rozwijania umiejętności programistycznych.
