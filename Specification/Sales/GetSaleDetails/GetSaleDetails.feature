Feature: Get Sale Details
	As a sales person
	I want to get the details of a sale
	So that I can review the sale

Scenario: Get Sale Details
	When I request the sale details for sale 1
	Then the following sale details should be returned:
	| Id | Date       | Customer      | Employee   | Product   | Unit Price | Quantity | Total Price |
	| 1  | 2022-01-01 | Martin Fowler | Eric Evans | Spaghetti | 5.00       | 1        | 5.00        |
