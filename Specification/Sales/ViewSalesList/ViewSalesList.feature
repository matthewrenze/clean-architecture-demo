Feature: View Sales List
	As a sales person
	I want to view a list of sales
	So I can find a sale to review

@mytag
Scenario: View a List of Sales
	When I request a list of sales
	Then the following sales list should be displayed:
	| Id | Date       | Customer      | Employee   | Product   | Unit Price | Quantity | Total Price |
	| 1  | 2001-02-03 | Martin Fowler | Eric Evans | Spaghetti | 5.00       | 1        | 5.00        |
	| 2  | 2001-02-04 | Uncle Bob     | Greg Young | Lasagne   | 10.00      | 2        | 20.00       |
	| 3  | 2001-02-05 | Kent Beck     | Udi Dahan  | Ravioli   | 15.00      | 3        | 45.00       |