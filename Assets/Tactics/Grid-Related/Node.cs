using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    Node prev; //This variable is used for pathfinding when moving units. It keeps track of the previous node in a sequence when so we can trace it backwards and find the shortest path.
    public Coordinates cords;
    public float yCord;
    
    public int movementCost; //this int tracks the current cost to move to a node when calculating the nodes availiable to be moved to. 
    public int moveEcon = 1; //This int holds the amount that the node will deduct from your movement resource in order to move to it. essentially this int is the difference between taking 1 cost to travel through planes and 2 cost to travel through swamp, while the other one is the accumulation of movementEcons for a specific turn.
        
    
//These keep track of the grid coordinates of each node
    public Node (int x, float y, int z) { //a constructor for making nodes when mapping nodes onto the map
        cords = new Coordinates(x, z);
        yCord = y;
    }



   
}