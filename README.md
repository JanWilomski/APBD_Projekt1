# APBD Projekt 1 - Uczelniana wypożyczalnia sprzętu

## Uruchomienie

Wymagania: .NET 9.0 SDK

cd APBD_Projekt1
dotnet run

## Decyzje projektowe
Podzieliłem projekt na modele odpowiadające za poszczególnych aktorów, serwisy które odpowiadają za koordynacje i działanie na modelach oraz UI które odpowiada za wyswietlanie w konsoli informacji. Na ten moment uznałem że podzielenie User przez Enum będzie prostsze ponieważ logiki z tym związanej jest mało ale przy większym programie mogłoby to nie być skalowalne rozwiązanie. Program.cs zawiera prosty scenariusz pokazujący funkcjonalność