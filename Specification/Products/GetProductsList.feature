Feature: Get Products List
	As a sales person
	I want to get a list of products
	So I can inspect the products

Scenario: Get a List of Products
	When I request a list of products
	Then the following products should be returned:
	| Id | Name      | Unit Price |
	| 1  | Spaghetti | 5.00       |
	| 2  | Lasagne   | 10.00      |
	| 3  | Ravioli   | 15.00      |
