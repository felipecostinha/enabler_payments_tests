Feature: Order

  Scenario: Create an provider
    Given id is '1'
    And name is 'ProviderTest'
    When save this provider

    Create an payment
    Given id is '1'
    Given value is '9'
    Given status is 'Started'
    Given providerId is '1'
    When save this payment

    Then Contact's table size must be '1's
