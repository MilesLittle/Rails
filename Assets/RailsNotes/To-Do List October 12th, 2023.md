-Make a button that allows the player to move
    -The first selection of the button will call the findtraversablenodes() function and show the nodes that the player can move to.
    -That function will return a list of nodes and then I will have to write a script that allows the player to select which node to move too.
    -After selecting, the game will run the findtraversablenodes() script again from the newly selected tile. 
-This should be find for now as all that will need to be changed later is moving the unit to the selected tile. Essentially changing the select script to change the tile of the unit rather than the tile of the starting place. 

- implement a turn queue
    -Essentially the units will have their turns decided by a turn queue, right 
        it will be random who gets entered, but later on, some formula that's
        done every check of the turn queue will determine who gets entered and 
        in what order
    
- Implement other player units
    - After implementing the turn queue, next will be adding more units to the 
        game. We will add all 6 of the player's playable units as well as a few 
        test enemey units that won't really do anything for now. 
    - After implementing both enemy and ally units, this is when we will decide
        on how units get entered into the turn queue and make it work
- Make a "Beastiary"
    -The Beastiary will simply hold all of the enemy units in the game. (Later 
        on, some check will be made to determine how that units presents in game (statwise, ability wise and stuff) Each map will be hand crafted so there will be no randomness in terms of how the units are)
    -There will be a base abstract class for enemies, and each inherited class will hold the stats of the unit as well as a bunch of different functions that will fill in the correct stats and abilities for the unit based on the stage that its on)

-Make a way to create map data
    -Create a way for the devs to create maps in the editor. Essentially the ability to define the size of the map as well as placing units at specific nodes that are spawned in at the start of the stage. Allow this ability to be saved somewhere and read in by the initiaiteMap() function and load in the correct map data. 
