Feature: Get Sales List
	As a sales person
	I want to get a list of sales
	So I can find a sale to review

@mytag
Scenario: Get a List of Sales
	When I request a list of sales
	Then the following sales list should be returned:
	| Id | Date       | Customer      | Employee   | Product   | Unit Price | Quantity | Total Price |
	| 1  | 2022-01-01 | Martin Fowler | Eric Evans | Spaghetti | 5.00       | 1        | 5.00        |
	| 2  | 2022-01-02 | Uncle Bob     | Greg Young | Lasagne   | 10.00      | 2        | 20.00       |
	| 3  | 2022-01-03 | Kent Beck     | Udi Dahan  | Ravioli   | 15.00      | 3        | 45.00       |