Feature: Print all table value for W3School portal

Read table data for W3school and print them 
@tag1
Scenario: Print table data
	Given User is on the given URL page
	When User get table data from given page
	Then User is able to print all the table data
