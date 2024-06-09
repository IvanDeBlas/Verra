# Word Concatenation Exercise

This is a console application implemented in .NET Core that processes a word list and finds all the 6-letter words that can be obtained by concatenating two other words from the list.

## Problem Statement

Given a list of words, the task is to find all the 6-letter words that can be formed by concatenating two other words from the list. For example, if the word "albums" is in the list, it can be formed by concatenating the words "al" and "bums".

## Approach

The application follows the following approach to solve the problem efficiently:

1. **Word List**: The word list is defined either in the code or can be read from a file.
2. **HashSet for Fast Lookups**: The word list is stored in a HashSet for fast lookups.
3. **Word Concatenation**: For each 6-letter word in the list, the program iterates over all possible positions to split the word into two parts. It then checks if both parts exist in the HashSet.
4. **Printing Results**: If both parts exist in the HashSet, the program prints the concatenation along with the two parts.


# Fraud Detection Exercise

This is a fraud detection exercise that revolves around identifying fraudulent orders based on certain conditions. The exercise involves developing a program that can analyze a set of orders and determine which ones are fraudulent according to the specified conditions.

## Problem Description

In this problem, we are provided with a set of orders, each containing details such as email address, postal address, offer ID, credit card number, etc. An order is considered fraudulent if it meets any of the following conditions:

1. Two orders have the same email address and the same offer ID but different credit card information, regardless of the street address.
2. Two orders have the same Address/City/State/Zip and the same offer ID but different credit card information, regardless of the email address.

The goal is to develop a program that can identify fraudulent orders based on these conditions and generate a list of fraudulent order IDs.

## Proposed Solution

The proposed solution to this problem involves developing a program in C# that processes the provided set of orders and determines fraudulent orders according to the specified conditions. The program uses a dictionary-based approach to keep track of unique combinations of email address, postal address, and credit card number associated with each offer. It then checks for duplicates in these combinations and determines if the orders are fraudulent based on the given conditions.

The `Program.cs` file contains the source code of the program, which includes methods for normalizing the email address, postal address, and credit card number. The `DetectFraudulentOrders` method is responsible for detecting fraudulent orders based on the specified conditions.

## Usage

To run the program:
1. Replace the contents of the `data/orders.txt` file with the list of orders you want to analyze.
2. Execute the program by compiling and running the `Program.cs` file.

Ensure that the input data is provided in the specified format to obtain accurate results.

