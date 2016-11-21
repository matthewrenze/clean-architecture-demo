Feature: View Sale Details
	As a sales person
	I want to view the details of a sale
	So that I can review the sale

Scenario: View Sale Details
	When I request the sale details for sale 1
	Then the following results should be displayed:
	| Id | Date       | Customer      | Employee   | Product   | Unit Price | Quantity | Total Price |
	| 1  | 2001-02-03 | Martin Fowler | Eric Evans | Spaghetti | 5.00       | 1        | 5.00       |
