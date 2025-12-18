# dotnet-learning

Repozytorium zawiera materiały, ćwiczenia oraz projekty realizowane w ramach nauki platformy **.NET** i języka **C#**. Dokumentacja śledzi postępy w nauce programowania obiektowego, technologii webowych oraz baz danych.

## Technologie i Narzędzia
* **Język:** C#
* **Platforma:** .NET Core / .NET 5+
* **Bazy danych:** Entity Framework Core (ORM)
* **Architektura:** MVC, Web API, Razor Pages

---

## Plan Laboratoriów i Status Realizacji

Poniższa tabela przedstawia program kursu oraz aktualny stan wykonania poszczególnych modułów.

| Laboratorium | Tematyka | Status |
| :--- | :--- | :--- |
| **Lab 1** | Aplikacja konsolowa w C# (Paradygmat obiektowy) | ![Zakończone](https://img.shields.io/badge/Status-Zakończone-success) |
| **Lab 2** | Przetwarzanie danych za pomocą LINQ | ![Zakończone](https://img.shields.io/badge/Status-Zakończone-success) |
| **Lab 3** | Aplikacja internetowa w architekturze MVC | ![Zakończone](https://img.shields.io/badge/Status-Zakończone-success) |
| **Lab 4** | Aplikacja internetowa - podejście Razor Pages | ![W planach](https://img.shields.io/badge/Status-W_planach-lightgrey) |
| **Lab 5** | Obsługa bazy danych oraz mechanizm ORM | ![Zakończone](https://img.shields.io/badge/Status-Zakończone-success) |
| **Lab 6** | Walidacja danych użytkownika po stronie aplikacji | ![W planach](https://img.shields.io/badge/Status-W_planach-lightgrey) |
| **Lab 7** | Tworzenie aplikacji w podejściu "Database First" | ![Zakończone](https://img.shields.io/badge/Status-Zakończone-success) |
| **Lab 8** | Tworzenie usług typu Web API | ![Zakończone](https://img.shields.io/badge/Status-Zakończone-success) |
| **Lab 9** | Uwierzytelnianie w aplikacji typu API | ![W planach](https://img.shields.io/badge/Status-W_planach-lightgrey) |
| **Lab 10** | Testowanie aplikacji Web API | ![W planach](https://img.shields.io/badge/Status-W_planach-lightgrey) |

---

## Przegląd kluczowych zagadnień

### Programowanie Obiektowe i LINQ (Lab 1-2)
Skupienie na podstawach języka C#, strukturach danych oraz efektywnym przeszukiwaniu kolekcji przy użyciu Language Integrated Query.

### Web Development (Lab 3-4)
Implementacja logiki po stronie serwera z wykorzystaniem wzorca Model-View-Controller oraz uproszczonego modelu Razor Pages.



### Bazy Danych (Lab 5, 7)
Wykorzystanie Entity Framework Core do komunikacji z bazami danych, w tym mapowanie tabel na klasy (Code First) oraz generowanie modeli z istniejących baz (Database First).

### Web API i Bezpieczeństwo (Lab 8-10)
Budowa usług RESTful, ich zabezpieczanie oraz weryfikacja poprawności działania poprzez testy automatyczne.

---

## Instrukcja uruchomienia i przygotowania środowiska

### 1. Wymagania wstępne
Aby uruchomić projekty, na Twoim komputerze muszą być zainstalowane:
* **.NET SDK** (zalecana wersja 6.0 lub nowsza).
* **IDE**: Visual Studio 2022, JetBrains Rider lub VS Code z rozszerzeniem C# Dev Kit.
* **Baza danych**: SQL Server Express (LocalDB) lub SQLite.

### 2. Pobieranie projektu
Sklonuj repozytorium na swój dysk lokalny:
git clone [https://github.com/TwojLogin/dotnet-learning.git](https://github.com/TwojLogin/dotnet-learning.git)
cd dotnet-learning

### 3. Przygotowanie narzędzi EF Core
Jeśli projekt wymaga migracji bazy danych, upewnij się, że masz zainstalowane narzędzia globalne:

Bash

dotnet tool install --global dotnet-ef

### 4. Uruchomienie wybranego laboratorium
Każdy folder to oddzielny projekt. Aby go uruchomić, wykonaj następujące kroki (przykład dla Lab 3):

Bash

# Wejdź do folderu wybranego laboratorium
cd Lab3

# Przywróć zależności NuGet
dotnet restore

# (Opcjonalnie) Zaktualizuj bazę danych, jeśli projekt korzysta z EF Core
dotnet ef database update

# Uruchom aplikację
dotnet run

### 5. Dostęp do aplikacji
Aplikacje Web: Po uruchomieniu konsola wyświetli adres (zazwyczaj https://localhost:5001 lub https://localhost:7001).
Web API: Dokumentacja techniczna (Swagger) jest zazwyczaj dostępna pod adresem https://localhost:PORT/swagger.
