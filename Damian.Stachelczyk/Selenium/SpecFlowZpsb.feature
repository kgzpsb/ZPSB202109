Feature: SpecFlowZpsb

@mytag
Scenario: I enter zpsb.pl and try to reset password to edziekanat
Given I enter dziekanat.zpsb.pl and I click on students
When I click on reset password, provide wrong email and I click reset
Then An error message appears