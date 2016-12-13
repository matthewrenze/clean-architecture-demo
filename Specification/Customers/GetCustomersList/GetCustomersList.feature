Feature: Get Customers List
	As a sales person
	I want to get a list of customers
	So I can inspect the customers

Scenario: Get a List of Customers
	When I request a list of customers
	Then the following customers should be returned:
	| Id | Name          |
	| 1  | Martin Fowler |
	| 2  | Uncle Bob     |
	| 3  | Kent Beck     |
