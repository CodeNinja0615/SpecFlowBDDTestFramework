Feature: EndToEndFlow
  As a user, I want to log in, add products to the cart, and complete the purchase successfully.

  @Inline
  Scenario: Verify End-to-End purchase flow with inline values
    Given I log in with username "rahulshettyacademy" and password "learning"
    When I add "iphone X" and "Blackberry" to the cart
    And I proceed to checkout
    Then I should see the selected products in the checkout page
    And I should see a success message upon purchase

  @Smoke
  Scenario Outline: Verify End-to-End purchase flow
    Given I log in with username "<username>" and password "<password>"
    When I add "<product1>" and "<product2>" to the cart
    And I proceed to checkout
    Then I should see the selected products in the checkout page
    And I should see a success message upon purchase

    Examples:
      | username           | password | product1 | product2   |
      | rahulshettyacademy | learning | iphone X | Blackberry |
      | rahulshettyacademy | learning | iphone X | Blackberry |
