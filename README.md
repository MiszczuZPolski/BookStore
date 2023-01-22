# BookStore
Liczba obecności 100%

# Wzorzec projektowy Kompozyt
Wzorzec projektowy Kompozyt jest wzorcem, który pozwala na traktowanie pojedynczych obiektów i ich grupy jednakowo. Wzorzec ten jest przydatny, gdy chcemy budować składane struktury obiektów, takie jak drzewa czy grafy.

W .NET Core możemy wykorzystać ten wzorzec do budowy różnorodnych struktur danych, takich jak drzewa katalogów i plików, hierarchie elementów interfejsu użytkownika lub struktury elementów biznesowych. Przykładowo, możemy utworzyć klasę "Katalog" i "Plik", które dziedziczą po abstrakcyjnej klasie "Element", a następnie tworzyć drzewo z tych obiektów, traktując katalogi jak "gałęzie" a pliki jako "liście".

# Wzorzec projektowy Strategia
Wzorzec projektowy Strategia jest wzorcem pozwalającym na dynamiczne określenie i zmianę zachowania obiektu. Wzorzec ten polega na oddzieleniu różnych algorytmów lub strategii działania od obiektów, które je wykorzystują. Dzięki temu możemy łatwo zmienić zachowanie obiektu bez potrzeby modyfikowania jego kodu.

W .NET Core, strategia może być wykorzystana do implementacji różnych algorytmów sortowania, strategii wykonywania różnych operacji na danych, czy też różnych strategii walidacji danych. Możemy utworzyć interfejs lub abstrakcyjną klasę "Strategia" z metodą "Wykonaj()" a następnie utworzyć konkretne implementacje tego interfejsu dla różnych strategii. Obiekt, który ma korzystać z tej strategii, będzie przechowywał referencję do obiektu implementującego interfejs i będzie go wywoływał, aby wykonać działanie.
