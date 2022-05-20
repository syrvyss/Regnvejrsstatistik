## What is Regnvejrsstatistik?

Regnvejrsstatistik is a simple open rain downpour statistical calculator.

## Design goals and choices made

`Statistics` is deliberately a non-static class, to allow for further expansion in the future such as reinitialization of data values by the user.

## Contributing

* New features are only to be added using new branch called `feature/THIS_IS_A_NEW_FEATURE`
* `feature` brances are only to be merged into `develop`
* `develop` is never to be edited directly, except in case of syntax errors or other similar cases.
* `develop` is only to be merged into `master` when thorough testing has been made and all unit tests pass.

## How to run

### Base project
```sh
# Run in ./Program
dotnet run
```

### Unit tests
```sh
dotnet test
```

## How to use

```sh
How many data values to initialize? (usize): x
Enter 3 Rain downpur datavalues (double+space+double):
1.3 60.4 6.99

Write out (Average: 0), (Min: 1), (Max: 2), (Median: 3), (Values: 4), (Exit: 5): 
0

22.896666666666665
```

## Libraries used

* **System**: Required by C#
* **System.Linq**: Easier string and array manipulation
* **System.Collections.Generic**: Lists