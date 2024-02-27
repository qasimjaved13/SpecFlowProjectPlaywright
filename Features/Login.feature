Feature: Login

A short summary of the feature

@smoke
Scenario: login
	Given Navigate to URL
	And Click on login button
	When Enter valid login credentials
		| Username | Password |
		| admin    | password |
	Then user should be able to login
