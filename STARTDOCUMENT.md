# Table Of Contents

- [Table Of Contents](#table-of-contents)
- [Startdocument for 8. Contribution](#startdocument-for-8-contribution)
  * [Problem Description](#problem-description)
    + [Input & Output](#input---output)
      - [Input](#input)
      - [Output](#output)
      - [Calculations](#calculations)
      - [Remarks](#remarks)
  * [Class Diagram](#class-diagram)
  * [Testplan](#testplan)
    + [Test Data](#test-data)
      - [Member](#member)
    + [Test Cases](#test-cases)
      - [#1 Get Individual Contribution](#-1-get-individual-contribution)
      - [#2 Get Total Contribution](#-2-get-total-contribution)
      - [#3 Get Average Number of Yeats of Membership](#-3-get-average-number-of-yeats-of-membership)
      - [#4 Get Youngest Member](#-4-get-youngest-member)

# Startdocument for 8. Contribution

Startdocument of **David Hlavacek**. Student number **5094879**.

## Problem Description

The following rules are operated to calculate the annual contribution to a
sports club: Senior members pay € 150,-, junior members pay € 75,-. Senior
members are people aged 18 or above. Playing members also pay a € 45,-
association contribution. People who have been members for more than 7
years are given a 5% discount on the club contribution.
A program must be developed in which the name, date of birth and date of
joining the club (format ddmmyyy) of each member can be entered, and also
whether the member is a playing or non-playing member. The contribution
of each member must be calculated and shown. The cumulative total contribution, the average number of years of membership and the youngest member
must also be shown. 

### Input & Output

In this section the in- and output of the application will be described.

#### Input

In the table below all the input are described.

|Case|Type|Conditions|
|----|----|----------|
|Name|`string`|not empty|
|Date of Birth|`Date`|dd/mm/yyyy|
|Date of joining The Club|`Date`|dd/mm/yyyy|
|Playing or Non-Playing|`Boolean`|`True` or `False`|

#### Output

|Case|Type|
|----|----|
|Individual Contribution|`Member` + `float`|
|Total Contribution|`float`|
|Average Years of Membership|`Float`|
|Youngest Member|`Member`|

#### Calculations

| Case              | Calculation                        |
| ----------------- | ---------------------------------- |
|Individual Contribution|Calculate the contribution for an individual member.|
|Total Contribution|Calculate the total contribution for each member.|
|Average Years of Membership|Calculate the average number of years of membership.|
|Youngest Member|Calculate the youngest member.|

#### Remarks

In the diagram I decided to display only the essential methods to the user.

## Class Diagram

![Class Diagram](images/classdiagram.png)

## Testplan

In this section the testcases will be described to test the application.

### Test Data

In the following table you'll find all the data that is needed for testing.


#### Member

| ID            | Input                             | 
| ------------- | --------------------------------- | 
| `member1`       | name: David1 H<br />birthDate: 21/09/2001<br />joinDate: 07/06/2020<br />isPlaying: true| 
-> Senior: 150 + isPlaying|true: 45 + <7y: no Discount = 195
| `member1`       | name: David1 H<br />birthDate: 21/09/2001<br />joinDate: 07/06/2020<br />isPlaying: false| 
-> Senior: 150 + isPlaying|false: 0 + <7y: no Discount = 150
| `member2`       | name: Lara1<br />birthDate: 21/07/2003<br />joinDate: 07/07/2014<br />isPlaying: true|
-> Senior: 150 + isPlaying|true: 45 + <7y: yes Discount = 195 - 5% = 185.25
| `member2`       | name: Lara2<br />birthDate: 21/08/2003<br />joinDate: 07/07/2014<br />isPlaying: false| 
-> Senior: 150 + isPlaying|false: 0 + <7y: yes Discount = 150 - 5% = 142.5
| `member3`       | name: Albert1<br />birthDate: 22/09/2006<br />joinDate: 07/06/2019<br />isPlaying: true| 
-> Junior: 75 + isPlaying|true: 45 + <7y: no Discount = 120
| `member3`       | name: Albert2<br />birthDate: 22/10/2006<br />joinDate: 07/06/2019<br />isPlaying: false| 
-> Junior: 75 + isPlaying|false: 0 + <7y: no Discount = 75 
| `member4`       | name: Marcel1<br />birthDate: 15/09/2006<br />joinDate: 07/06/2014<br />isPlaying: true| 
-> Junior: 75 + isPlaying|true: 45 + <7y: yes Discount = 120 - 5% = 114
| `member4`       | name: Marcel2<br />birthDate: 15/10/2006<br />joinDate: 07/06/2014<br />isPlaying: false| 
-> Junior: 75 + isPlaying|false: 0 + <7y: yes Discount = 75 - 5% = 71.25

### Test Cases

In this section the testcases will be described. Every test case should be executed with the test data as starting point.

| \4.Input                                     | \4.Output                                                                   | 
| ----------------------------------------- | ------------------------------------------------------------------------ | 
| Name | birthDate | joinDate | isPlaying   | Contribution | Total Contribution | Youngest Member | Average Membership |


#### #1 Get Individual Contribution

The contribution of each member must be calculated and shown.

|Expected output|
|---------------|
|David1 - 195|
|David2 - 150|
|Lara1 - 185.25|
|Lara2 - 142.5|
|Albert1 - 120|
|Albert2 - 75|
|Marcel1 - 114|
|Marcel2 - 71.25|

#### #2 Get Total Contribution

Get the cumulative total contribution.

|Expected output|
|---------------|
|1053|

#### #3 Get Average Number of Years of Membership

Get the average number of years of membership.

|Expected output|
|---------------|
|Changes depending on day...|

#### #4 Get Youngest Member

Calculate the youngest member.

| Expected output |
| --------------- |
|Marcel2|

[scroll to top](#table-of-contents)
