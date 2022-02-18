﻿Feature: Cash Class Unit Testing 
 
@unit 
Scenario: Multipy Cash by Value 
 Given Cash CHF 2  
 When Multipy by 0 
 Then Cash Value is 0


@unit 
Scenario: Multipy Cash by -1 
 Given Cash CHF 2  
 When Multipy by -1 
 Then Cash Value is -2

Scenario Outline: Multipy Cash by Value negative test
Given Cash CHF 5
When Multipy by <multiplyFirst>
When Multipy by <multiplySecond>
Then Cash Value is <result>
Examples:
| multiplyFirst | multiplySecond | result |
| 123 | 5 | 25 |
| 546 | 23 | 115 |