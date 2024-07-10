# StringCalculatorTemplate

![build and test](https://github.com/AbualiYousef/String-Calculator-Task/workflows/build%20and%20test/badge.svg)

This repository contains the implementation of a String Calculator in F#. The goal of this task is to develop a simple calculator that can add numbers in a string format, following specific requirements. The project demonstrates adherence to clean code practices, SOLID principles, and the use of design patterns.

## Task Description

1. **Create a simple String calculator with a method `int Add(string numbers)`**:
   - The method can take 0, 1, or 2 numbers and will return their sum. For an empty string, it will return 0. Examples:
     - `""` returns `0`
     - `"1"` returns `1`
     - `"1,2"` returns `3`
   - Start with the simplest test case of an empty string and move to 1 and two numbers.

2. **Allow the `Add` method to handle an unknown amount of numbers**:
   - The method should be able to handle any number of comma-separated values.

3. **Allow the `Add` method to handle new lines between numbers (instead of commas)**:
   - The following input is valid: `"1\n2,3"` (will equal 6).
   - The following input is NOT valid: `"1,\n"` (no need to prove it - just clarifying).

4. **Support different delimiters**:
   - To change a delimiter, the beginning of the string will contain a separate line that looks like this: `"//[delimiter]\n[numbers…]"`. For example, `"//;\n1;2"` should return 3 where the default delimiter is `;`.
   - The first line is optional. All existing scenarios should still be supported.

5. **Calling `Add` with a negative number will throw an exception `negatives not allowed` - and the negative that was passed**:
   - If there are multiple negatives, show all of them in the exception message.

6. **Numbers bigger than 1000 should be ignored**:
   - For example, adding `2 + 1001 = 2`.

7. **Delimiters can be of any length with the following format**:
   - `"//[delimiter]\n"` for example: `"//[***]\n1***2***3"` should return 6.

8. **Allow multiple delimiters**:
   - For example: `"//[*][%]\n1*2%3"` should return 6.

9. **Ensure handling of multiple delimiters with length longer than one character**.

## Clean Code, SOLID Principles, and Design Patterns

### Clean Code

- The codebase follows the principles of clean code, making it readable, understandable, and maintainable. Functions and modules are designed with clear responsibilities.

### SOLID Principles

1. **Single Responsibility Principle (SRP)**:
   - Each module and function has a single responsibility. For example, the `NumberParser` module is only responsible for parsing numbers, while the `NumberValidator` module handles validation.

2. **Open/Closed Principle (OCP)**:
   - The code is open for extension but closed for modification. New delimiters can be added without changing the existing code.

3. **Liskov Substitution Principle (LSP)**:
   - The design ensures that objects of a superclass can be replaced with objects of a subclass without affecting the correctness of the program.

4. **Interface Segregation Principle (ISP)**:
   - The project uses specific interfaces for different delimiter parsers, ensuring that clients only depend on the methods they use.

5. **Dependency Inversion Principle (DIP)**:
   - High-level modules do not depend on low-level modules. Both depend on abstractions. This is evident in the use of the `IDelimiterParser` interface.

### Design Patterns

1. **Factory Method Pattern**:
   - The `DelimiterFactory` module uses the Factory Method pattern to create appropriate delimiter parsers based on the input format.

2. **Strategy Pattern**:
   - The `IDelimiterParser` interface and its implementations (`SingleDelimiterParser` and `MultipleDelimiterParser`) exemplify the Strategy Pattern. This pattern defines a family of algorithms (parsing strategies), encapsulates each one, and makes them interchangeable. This allows the delimiter parsing behavior to be selected at runtime.

## Resources

- [F# for Fun and Profit](http://fsharpforfunandprofit.com/)
- [Kit Eason's F# Course on Pluralsight](https://www.pluralsight.com/courses/fsharp-jumpstart)
- [F# Fundamentals on Pluralsight](https://www.pluralsight.com/courses/fsharp-fundamentals)

## Getting Started

To run the project locally, follow these steps:

1. Clone the repository:
   ```bash
   git clone https://github.com/AbualiYousef/String-Calculator-Task.git
