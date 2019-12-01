# FilteredMap
Create a C# / .NET Core website that pulls parks from a public API and displays them on the page.  
Display a map with pins and an accompanying list.  
This website should be responsive.  

## Assumptions
* The map will be interactive
* the map will cover a limited section in Virginia Beach
* Because this demo is MVC, the places will come from google places api to feed the embedded map


## Comments log
* This site could have been entirely done with any javascript framework, but for the sake of the demo it will be created as a .net core MVC site
* MVC description: https://www.tutorialsteacher.com/mvc/mvc-architecture
* Google maps is the chosen data provider just because I'm more familiar with
* Bootstrap provides the required responsivenes
* This can also be done without coding using google custom maps for example :)
* The google places dataset is not comprehensive
* The demo does nor include localization, the string resources are hardcoded
