# Orange Paranoia API

**Orange Paranoia** is a versatile API and NuGet package that provides random information on a wide variety of topics. Whether you need basic random values (such as numbers, dates, and strings) or themed name generators for Star Wars characters (Jedi, Sith, Droide), this project has you covered.

---

## Table of Contents

* [Overview](#overview)
* [Endpoint Groups](#endpoint-groups)

  * [Answers](#answers)
  * [Cards](#cards)
  * [Numbers](#numbers)
  * [Dates](#dates)
  * [Progressions](#progressions)
  * [Utility](#utility)
  * [Arrays](#arrays)
  * [Star Wars](#star-wars)
* [Usage](#usage)
* [License](#license)

---

## Overview

The Orange Paranoia API exposes several endpoint groups, each providing a specific set of functionalities for generating random or themed data. These endpoints are organized to make it easy to request the type of data you need.

This project is maintained at [https://github.com/pasta0126/OrangeParanoia](https://github.com/pasta0126/OrangeParanoia) and is available as a NuGet package for easy integration in .NET applications.

---

## Endpoint Groups

### Answers

Endpoints in the **Answers** group generate random responses for decision-making and fun queries.

* **GET /answer/magic8ball**
  Returns a random Magic 8-Ball style answer as plain text.

* **GET /answer/yesno**
  Returns a random Yes/No answer as plain text.

* **GET /answer/truefalse**
  Returns a random True/False answer as plain text.

---

### Cards

Endpoints in the **Cards** group generate random card selections from various decks.

* **GET /card/tarot**
  Returns a list of randomly selected Tarot cards (including the card number and name) in English.
  **Query Parameter:**

  * `count` (integer): Number of cards to return (minimum 1, maximum deck size).

* **GET /card/poker**
  Returns a list of randomly selected Poker cards in English.
  **Query Parameter:**

  * `count` (integer)

* **GET /card/spanish**
  Returns a list of randomly selected Spanish deck cards in Spanish.
  **Query Parameter:**

  * `count` (integer)

---

### Numbers

Endpoints in the **Numbers** group generate random numerical values of different types.

* **GET /number/random/int**
  Returns a random integer. Optionally accepts `min` and `max` query parameters.

* **GET /number/random/decimal**
  Returns a random decimal. Optionally accepts `min`, `max`.

* **GET /number/random/double**
  Returns a random double. Optionally accepts `min`, `max`.

* **GET /number/random/float**
  Returns a random float. Optionally accepts `min`, `max`.

* **GET /number/random/decimal-range**
  Returns a random decimal within a specified range with configurable precision.
  **Query Parameters:** `min`, `max`, `decimals`.

---

### Dates

Endpoints in the **Dates** group provide random date and time values.

* **GET /date/future**
  Returns a random future date. Optional `format` (default: `yyyy-MM-dd`).

* **GET /date/past**
  Returns a random past date. Optional `format`.

* **GET /time/future**
  Returns a random future time. Optional `format` (default: `HH:mm:ss`).

* **GET /time/past**
  Returns a random past time. Optional `format`.

* **GET /datetime/future**
  Returns a random future date-time. Optional `format` (default: sortable pattern).

* **GET /datetime/past**
  Returns a random past date-time. Optional `format`.

Each endpoint validates `format` and returns `400 Bad Request` if invalid.

---

### Progressions

The **Progressions** group provides endpoints for generating various mathematical sequences.

* **GET /progression/fibonacci**
* **GET /progression/jacobsthal**
* **GET /progression/lucas**
* **GET /progression/pell**
* **GET /progression/hofstadterq**
* **GET /progression/logisticmap**
* **GET /progression/exotic**

Each returns the sequence value for an input integer `n`.

---

### Utility

The **Utility** group includes endpoints for generating random color values.

* **GET /utility/hexcolor**
* **GET /utility/hexcolor2**
* **GET /utility/rgbcolor**
* **GET /utility/rgba**
  **Query Parameter:** `alpha` for opacity.

---

### Arrays

* **POST /array/random**
  Accepts a JSON array in the body and returns one randomly selected element. Returns `400` if array is null/empty.

---

### Star Wars

The **Star Wars** group provides name generators for Jedi, Sith, and Droids:

#### Jedi

* **GET /starwars/jedi/classic**
  **Query:** `firstName`, `lastName`, `motherName`, `birthCity`
  Generate using 3 letters of last name + 2 of first + 2 of mother + 3 of city.

* **GET /starwars/jedi/realform**
  **Query:** same parameters
  Generate using 3 of first name + 2 of last + 2 of mother + 3 of city.

* **GET /starwars/jedi/2332**
  **Query:** same parameters
  Generate using 2 of first + 3 of last + 3 of mother + 2 of city.

* **GET /starwars/jedi/fromends**
  **Query:** same parameters
  Generate using last 2 of first + last 3 of last + last 2 of mother + last 3 of city.

* **GET /starwars/jedi/astrology**
  **Query:** `firstName`, `lastName`, `birthCity`, `zodiacSign`, `zodiacElement`
  Generate using initials of sign/element mixed with letters from name and city.

#### Sith

* **GET /starwars/sith/classic**
  **Query:** `petName`, `streetName`

* **GET /starwars/sith/method1**
  **Query:** `realName`, `emotion`, `virtue`

* **GET /starwars/sith/method2**
  **Query:** `ambition`, `realName`, `weakness`, `parentName`

* **GET /starwars/sith/method3**
  **Query:** `realName`, `emotion`

#### Droid

* **GET /starwars/droid/astromech**
  **Query:** `birthMonth` (1–12), `birthDay` (1–31)
  Returns `R{month}-{day}`.

* **GET /starwars/droid/protocol**
  **Query:** `firstName`, `age`
  Returns `{Initial}-{age%10}PO`.

* **GET /starwars/droid/random**
  **Query:** `firstName`, `lastName`
  Returns `{F}{L}-{random3digits}`.

* **GET /starwars/droid/fullserial**
  **Query:** `seriesPrefix`
  Returns `{prefix}-{GUID}`.

* **GET /starwars/droid/short**
  **Query:** `seriesPrefix`
  Returns `{prefix}-{first2ofGUID}`.

---

## Usage

To use the API, call the desired endpoint using HTTP client (Postman, curl, browser). Swagger UI is available at `/swagger` for interactive testing and documentation.

Include the NuGet package `OrangeParanoia` in your .NET project to access the same generators in code:

```xml
<PackageReference Include="OrangeParanoia" Version="*" />
```

---

## License

This project is licensed under [The Unlicense](https://unlicense.org/).
