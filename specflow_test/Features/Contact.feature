Feature: Contact

  Scenario: Create an contact
    Given id is '1'
    And first name is 'Felipe'
    And last name is 'Costa'
    And email is 'felipe.paltrinieri@vtex.com'
    And phone number is '123456'
    When save this contact
    Then Contact's table size must be '1'
    
  Scenario: Remove an contact
    Given exists an contact with id '1'
    When delete contact with id '1'
    Then Contact's table size must be '0'