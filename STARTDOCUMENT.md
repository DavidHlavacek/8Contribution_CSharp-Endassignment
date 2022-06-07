# Table Of Contents

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
|Individual Contribution|`Member` + `int`|
|Total Contribution|`int`|
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

* Test cases are inside `public static void main(String[] args){}`.
* Input's logic will be verified. This validation isn't described here but can be tested and tried out nonetheless.
  * e.g: You can only assign one cell per prisoner. You can't add duplicate cells. 
    * Error message: "This prisoner already has a cell!"
  * e.g: You can't remove a non existing prisoner from a cell. Etc...
    * Error message: "This cell doesn't contain this prisoner!"
* I have granted the freedom to choose the number of prisoners a cell can hold (rather than a static number {2})

## Class Diagram

![Class Diagram](images/classdiagram.png "Second Version of the class diagram")

## Testplan

In this section the testcases will be described to test the application.

### Test Data

In the following table you'll find all the data that is needed for testing.


#### Cell

| ID            | Input                             | Code                              |
| ------------- | --------------------------------- | --------------------------------- |
| `cell1`       | spots: 2                          | `new Cell(2)`                     |
| `cell2`       | spots: 2                          | `new Cell(2)`                     |
| `cell3`       | spots: 2                          | `new Cell(2)`                     |
| `cell4`       | spots: 2                          | `new Cell(2)`                     |

#### Prisoner

| ID            | Input                                                                     | Code                                                    |
| ------------- | ------------------------------------------------------------------------- | --------------------------------------------------------|
| `prisoner1`   | name: David H<br />offence_date: 01/01/2022<br />prison_time: 2 | `new Prisoner("David H", "01/01/2022", 2);`  |
| `prisoner2`   | name: Lara B<br />offence_date: 01/01/2022<br />prison_time: 4  | `new Prisoner("Lara B", "01/01/2022", 3);`   |
| `prisoner3`   | name: Andrej L<br />offence_date: 01/01/2022<br />prison_time: 7 | `new Prisoner("Andrej L", "01/01/2022", 7);` |
| `prisoner4`   | name: Miki S<br />offence_date: 01/01/2022<br />prison_time: 3 | `new Prisoner("Miki S", "01/01/2022", 3);`   |
| `prisoner5`   | name: Terry K<br />offence_date: 01/01/2022<br />prison_time: 50  | `new Prisoner("Terry K", "01/01/2022", 50);`   |
| `test1`       | name: Test 1<br />offence_date: 01/01/2022<br />prison_time: 50 | `new Prisoner("Test 1", "01/01/2022", 50);`   |
| `test2`       | name: Test 2<br />offence_date: 01/01/2022<br />prison_time: 50 | `new Prisoner("Test 2", "01/01/2022", 50);`   |
| `lowest_time` | name: Lowest Time<br />offence_date: 01/01/2022<br />prison_time: 1 | `new Prisoner("Lowest Time", "01/01/2022", 1);`   |



#### Prison

| ID           | Input | Code          |
| ------------ | ----- | ------------- |
| `prison`     |       | `new Prison()`|

#### Attach Prisoners to Cells

| Cell         | Code                      |
| ------------ | ------------------------- |
| `cell1`      | `addPrisoner(prisoner1)`  |
| `cell2`      | `addPrisoner(prisoner2)`  |
| `cell2`      | `addPrisoner(prisoner3)`  |
| `cell3`      | `addPrisoner(prisoner4)`  |

_Note: `cell2` is full!_

<!-- #### Attach Cells to Prison  

| Prison       | Code                      |
| ------------ | ------------------------- |
| `prison`     | `addCell(cell1)`          |
| `prison`     | `addCell(cell2)`          |
| `prison`     | `addCell(cell3)`          |
| `prison`     | `addCell(cell4)`          | -->


### Test Cases

In this section the testcases will be described. Every test case should be executed with the test data as starting point.

#### #1 Get All Cells With A Free Spot

Testing the method to get all the cells with a free spot. 

|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1| `prison` | `getFreeCells()` |Empty ArrayList|
|2| `prison` | `addCell(cell1)` ||
|3| `prison` | `getFreeCells()` | ArrayList with cell `cell1` |
|4| `prison` | `addCell(cell2)` ||
|5| `prison` | `getFreeCells()` | ArrayList with cell `cell1` |
|6| `prison` | `addCell(cell4)` ||
|7| `prison` | `getFreeCells()` | ArrayList with cell `cell1` &  `cell4`|


#### #2 Get All Prisoners With Corresponding Cells

Testing the method to list in which cell are all the prisoners. 

|Step|Input   |Action                |Expected output                                                                            |
|----|--------|----------------------|-------------------------------------------------------------------------------------------|
|1|`prison`|`printFindPrisoners()`|CELL 1: <br>&nbsp;&nbsp;> David H &#124; ID: 1<br><br>> CELL 2: <br>&nbsp;&nbsp;> Lara B &#124; ID: 2<br>&nbsp;&nbsp;> Andrej L &#124; ID: 3<br><br>> CELL 4: |
|2|`prison`|`addCell(cell3)`||
|3|`prison`|`printFindPrisoners()`|> CELL 1: <br>&nbsp;&nbsp;> David H &#124; ID: 1<br><br>> CELL 2: <br>&nbsp;&nbsp;> Lara B &#124; ID: 2<br>&nbsp;&nbsp;> Andrej L &#124; ID: 3<br><br>> CELL 4: <br><br>> CELL 3: <br>&nbsp;&nbsp;> Miki S &#124; ID: 4 |


#### #3 Get Cell Of Prisoner

Testing the method to get the cell of a specific prisoner.

|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1|`prison`|`getCellOfPrisoner(prisoner5)`|null|
|2| `cell1` |`addPrisoner(prisoner5)`||
|3|`prison`|`getCellOfPrisoner(prisoner5)`|Cell `cell1`|
|4| `cell4` |`addPrisoner(prisoner5)`|"This prisoner already has a cell!"|

_Note: the method in step 4 didn't go through therefore `cell4` remains empty!_

#### #4 Get Availability Of Cell

Testing the method to see if specific cell has a free spot.

| Step | Input        | Action       | Expected output |
| ---- | ------------ | ------------ | --------------- |
| 1    | `prison`    | `getFreeCell(cell4)` | true             |
| 2    | `cell4`    | `addPrisoner(test1)` |              |
| 3    | `prison`    | `getFreeCell(cell4)` | true             |
| 4    | `cell4`    | `addPrisoner(test2)` |              |
| 5    | `prison`    | `getFreeCell(cell4)` | false             |
| 6    | `cell4`    | `removePrisoner(test2)` |              |
| 7    | `prison`    | `getFreeCell(cell4)` | true             |


#### #5 Get Next Release

Testing the method to get the prisoner who's `release_date` is the closest.

_Note: Regarding prison time left: `prisoner1` < `prisoner4` < `prisoner2` ..._

| Step | Input        | Action                 | Expected output |
| ---- | ------------ | ---------------------- | --------------- |
| 1    | `prison` | `getNextRelease()` | Prisoner `prisoner1`                |
| 2    | `cell1` | `removePrisoner(prisoner1)`          |             |
| 3    | `prison` | `getNextRelease()` | Prisoner `prisoner4`                |
| 4    | `cell1` | `addPrisoner(lowest_time)`          |             |
| 5    | `prison` | `getNextRelease()` | Prisoner `lowest_time`                |



_Note: You can always add/remove prisoners from cells that are both added and/or not added to the prison!_

[scroll to top](#table-of-contents)
