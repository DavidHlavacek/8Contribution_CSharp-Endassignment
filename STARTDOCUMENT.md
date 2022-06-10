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
  * [Test Cases](#test-cases)
      
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

## Test Cases

In this section the testcases will be described.

<table>
		<tr>
			<td colspan="4">Input                                     </td>
			<td colspan="4">Output                                                                   </td>
		</tr>
		<tr>
			<td> Name </td>
			<td> birthDate </td>
			<td> joinDate </td>
			<td> isPlaying   </td>
			<td> Contribution </td>
			<td> Total Contribution </td>
			<td> Youngest Member </td>
			<td> Average Membership </td>
		</tr>
		<tr>
			<td>David1 </td>
			<td>21/09/2001 </td>
			<td>07/06/2020 </td>
			<td> true</td>
			<td> 195</td>
			<td> 195</td>
			<td> David1</td>
			<td> -</td>
		</tr>
		<tr>
			<td>David2 </td>
			<td>21/09/2000 </td>
			<td>07/06/2020 </td>
			<td> false</td>
			<td> 150</td>
			<td> 345</td>
			<td> David1</td>
			<td> -</td>
		</tr>
		<tr>
			<td>Lara1 </td>
			<td>21/07/2003 </td>
			<td>07/07/2014 </td>
			<td> true</td>
			<td> 185.25</td>
			<td> 530.35</td>
			<td> Lara1</td>
			<td> -</td>
		</tr>
		<tr>
			<td>Lara2 </td>
			<td>21/08/2003 </td>
			<td>07/07/2014 </td>
			<td> false</td>
			<td> 142.5</td>
			<td> 672.85</td>
			<td> Lara2</td>
			<td> -</td>
		</tr>
		<tr>
			<td>Albert1 </td>
			<td>22/09/2006 </td>
			<td>07/06/2019 </td>
			<td> true</td>
			<td> 120</td>
			<td> 792.85</td>
			<td> Albert1</td>
			<td> -</td>
		</tr>
		<tr>
			<td>Albert2 </td>
			<td>22/10/2006 </td>
			<td>07/06/2019 </td>
			<td> false</td>
			<td> 75</td>
			<td> 867.85</td>
			<td> Albert2</td>
			<td> -</td>
		</tr>
		<tr>
			<td>Marcel1 </td>
			<td>15/09/2006 </td>
			<td>07/06/2014 </td>
			<td> true</td>
			<td> 114</td>
			<td> 981.85</td>
			<td> Albert2</td>
			<td> -</td>
		</tr>
		<tr>
			<td>Marcel2 </td>
			<td>15/10/2006 </td>
			<td>07/06/2014 </td>
			<td> false</td>
			<td> 71.25</td>
			<td> 1053.1</td>
			<td> Albert2</td>
			<td> -</td>
		</tr>
</table>

[scroll to top](#table-of-contents)
