# Orange Paranoia API

**Orange Paranoia** is a versatile API and NuGet package that provides random information on a wide variety of topics. Whether you need basic random values (such as numbers, dates, and strings) or complete/partial data models—with both completely random data and logically related parameters—this project has you covered.

---

## Table of Contents

- [Overview](#overview)
- [Endpoint Groups](#endpoint-groups)
  - [Numbers](#numbers)
  - [Dates](#dates)
  - [Progressions](#progressions)
  - [Utility](#utility)
  - [Arrays](#arrays)
- [Usage](#usage)
- [License](#license)

---

## Overview

The Orange Paranoia API exposes several endpoint groups, each providing a specific set of functionalities for generating random data. These endpoints are organized to make it easy to request the type of data you need.

---

## Endpoint Groups

### Numbers

Endpoints in the **Numbers** group generate random numerical values of different types, such as integers, decimals, doubles, and floats. You can also generate random decimals within a specified range and precision.

- **GET /number/random/int**: Returns a random integer. Optionally accepts minimum and maximum values.
- **GET /number/random/decimal**: Returns a random decimal number. Optionally accepts minimum and maximum values.
- **GET /number/random/double**: Returns a random double. Optionally accepts minimum and maximum values.
- **GET /number/random/float**: Returns a random float. Optionally accepts minimum and maximum values.
- **GET /number/random/decimal-range**: Returns a random decimal number within a specified range with configurable precision. Query parameters include `min`, `max`, and `precision`.

---

### Dates

Endpoints in the **Dates** group provide random date and time values. They are divided into subgroups for dates, times, and date-times, and support optional format masks to customize the output.

- **GET /date/future**: Returns a random future date. Accepts an optional format mask (default: "yyyy-MM-dd").
- **GET /date/past**: Returns a random past date. Accepts an optional format mask.
- **GET /time/future**: Returns a random future time. Accepts an optional format mask (default: "HH:mm:ss").
- **GET /time/past**: Returns a random past time. Accepts an optional format mask.
- **GET /datetime/future**: Returns a random future date-time. Accepts an optional format mask (default: universal sortable pattern).
- **GET /datetime/past**: Returns a random past date-time. Accepts an optional format mask.

Each endpoint validates the provided format mask and returns an error if the mask is invalid.

---

### Progressions

The **Progressions** group provides endpoints for generating various numerical sequences and mathematical progressions. These endpoints use memoization and can handle complex calculations.

- **GET /progression/fibonacci**: Returns the Fibonacci number for the given input.
- **GET /progression/jacobsthal**: Returns the Jacobsthal number for the given input.
- **GET /progression/lucas**: Returns the Lucas number for the given input.
- **GET /progression/pell**: Returns the Pell number for the given input.
- **GET /progression/hofstadterq**: Returns the Hofstadter Q number for the given input.
- **GET /progression/logisticmap**: Returns a value from the logistic map function after `n` iterations.
- **GET /progression/exotic**: Returns the value of an "exotic" progression for the given input.

These endpoints allow you to explore different mathematical sequences and understand their behavior with random input parameters.

---

### Utility

The **Utility** group includes endpoints for generating random color values in various formats, which are useful for web development and design.

- **GET /utility/hexcolor**: Returns a random hex color based on an input string.
- **GET /utility/hexcolor2**: Returns another variant of a random hex color using a different hash algorithm.
- **GET /utility/rgbcolor**: Returns a random RGB color value.
- **GET /utility/rgba**: Returns a random RGBA color value. Accepts an optional `alpha` parameter for opacity.

These endpoints leverage different hashing methods to generate consistent and random color values.

---

### Arrays

The **Arrays** group provides an endpoint to select a random element from an array. This is useful when you need to pick a random item from a list of items.

- **GET /array/random**: Accepts an array of elements (e.g., strings) in the request body and returns one randomly selected element. If the array is empty or null, it returns a default value.

---

## Usage

To use the API, simply call the desired endpoint using your preferred HTTP client (e.g., Postman, curl, or directly through a browser for GET requests). Each endpoint is documented in Swagger, where you can also see the available query parameters and expected responses.

The API groups endpoints by functionality, making it easy to find and integrate the features you need into your project.

---

## License

This project is licensed under [The Unlicense](https://unlicense.org/).

---

Feel free to explore and integrate the Orange Paranoia API into your projects to generate random data efficiently and effectively!

