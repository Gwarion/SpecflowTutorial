Feature: Employee


Scenario: Employee GetFullName with no information missing
Given The following Employee
| FirstName | LastName |
| Geoffrey  | Warion   |
When I call the method GetfullName
Then No exception occurs
And I get the FullName Geoffrey Warion

Scenario Outline: Employee GetFullName with missing informations
Given An Employee with the firstname '<FirstName>' and the lastname '<LastName>'
When I call the method GetfullName
Then An exception of type '<ExceptionType>' occurs
Examples: 
| FirstName | LastName | ExceptionType         |
| Geoffrey  |          | ArgumentNullException |
|           | Warion   | ArgumentNullException |
|           |          | ArgumentNullException |

Scenario Outline: Can not fire an employee
Given An Employee with the status '<Status>' and the rank '<Rank>'
When I call the method Fire
Then An exception of type '<ExceptionType>' occurs
Examples: 
| Rank    | Status | ExceptionType                 |
| CEO     | Hired  | CannotFireCEOException        |
| Manager | Fired  | EmployeeAlreadyFiredException |