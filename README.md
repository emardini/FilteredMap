# Requirements
* Create a C# / .NET Core website that pulls parks from a public API and displays them on the page.  
* Display a map with pins and an accompanying list.  
* This website should be responsive.  

## Assumptions
* The map will be interactive
* the map will cover Virginia Beach
* Because this demo is MVC, the places will come from google places api to feed the embedded map
* Any error will result in the default error page showing up, no special handling will be done


## Comments log
* This site could have been entirely done with any javascript framework, but for the sake of the demo it will be created as a .net core MVC site
* MVC description: https://www.tutorialsteacher.com/mvc/mvc-architecture
* Google maps is the chosen data provider just because I'm more familiar with
* Bootstrap provides the required responsivenes
* This can also be done without coding using google custom maps for example :)
* The google places dataset is not comprehensive
* The demo does not include localization, the string resources are hardcoded
* There is no meaninngful business logic that requires unit testing, the code is mainly plumbing
* The search function could be made generic to accept place types other than parks and a different locality (city or zip code), but given there is no user input I decided not to add that capability

## Structure
* DTO classes in infrastructure are internal to ensure the solution uses the core entities to move the data between layers
* The core layer consists on interfaces and entities used as contracts between layers
* The website is deployed at https://filteredmap.azurewebsites.net/
