Feature: Get Employees List
	As a sales person
	I want to get a list of employees
	So I can inspect the employees

Scenario: Get a List of Employees
	When I request a list of employees
	Then the following employees should be returned:
	| Id | Name          |
	| 1  | Eric Evans    |
	| 2  | Greg Young    |
	| 3  | Udi Dahan     |
