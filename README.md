# VirtualPet
A serializable virtual pet program based on Tamagotchi toys.

To execute program, double click VirtualPetApplication in TamagotchiUserInterface Folder.

This project initializes with three different virtual pets which the player must keep alive by feeding, playing and 
putting to sleep. 

The solution contains three separate projects: Games, Tamagotchis and TamagotchiUserInterface

The Games Solution contains a GameBoard class and a Games class. This solution provides the functionality for the dodgeball 
game that the player must play to keep their pet alive. The Games solution is used as a library (.dll) in the TamagotchiUserInterface project. 

The Tamagotchis solution contains a Tamagotchi class and a Dino class. These provide the functionality for different types of pets in the TamagotchiUserInterface project. This is used as a library as well in the TamagotchiUserInterface project.

The project executes as a wpf program created in Visual Studio.
