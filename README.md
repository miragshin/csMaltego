# csMaltego
## Maltego C# library

Maltego Library coded in C# for developing Maltego Local transforms in C#.

## How to use

Compile code and import dll to your project.

## Code 

**1. Create a object of MaltegoTransform**

	MaltegoTransform me = new MaltegoTransform();

**2. Adding Entity**

	me.addEntity(Type, Value); 

**3. Adding property** 

For adding property you have get entity from the list by referencing index of it. 

	me.listEntities.get(i).addProperty(fieldName,displayName,matchingRule,value);

**4. Returning output.**

	me.returOutput();

Library will generate and return XML. 

## Currently available methods

### class MaltegoEntity

	addProperty(String fieldName,String displayName,String matchingRule,String value);
	setWeight(String weight); - sets weights
	setLinkColor(String color); - sets Link color
	setLinkStyle(String style); - sets style of Link
	setLinkThichkness(String thick);- sets thickness of the link 
	setBookmark(String bookmark);- sets a bookmark. Available colors are:(BOOKMARK_COLOR_NONE, BOOKMARK_COLOR_BLUE,BOOKMARK_COLOR_GREEN,BOOKMARK_COLOR_YELLOW,BOOKMARK_COLOR_ORANGE,BOOKMARK_COLOR_RED)
	setNote(String Note); - sets a note about entity
	setIconUrl(String url); - sets icon url of entity

### class MaltegoTransform 

	addEntity(String Type, String Value); - adds entity
	returnOutput(); - generates and returns XML 
	

