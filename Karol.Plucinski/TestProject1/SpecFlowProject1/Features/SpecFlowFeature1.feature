Feature: Cash Class Unit Testing

@smoke
Scenario: Multipy Cash by 0
Given Cash CHF 2
When Multipy by 0
Then Cash Value is 0

@smoke
Scenario: Multipy Cash by -999
Given Cash CHF 2
When Multipy by -999
Then Cash Value is -1998

Scenario Outline: Multipy Cash by Value negative test
Given Cash CHF 5
When Multipy by <multiplyFirst>
And Multipy by <multiplySecond>
Then Cash Value is <result>
Examples:
| multiplyFirst | multiplySecond | result |
| 123 | 5 | 23 |
| 546 | 23 | 324 |



