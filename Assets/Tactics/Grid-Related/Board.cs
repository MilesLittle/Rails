using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Board : MonoBehaviour
{
   
List<Node> visitedNodes = new List<Node>(); //This list is used when finding the nodes that are able to be travelled by the unit whose turn it is. 
Queue<Node> nodesToCheck = new Queue<Node>();

public List<Node> traversableNodes = new List<Node>();
public Dictionary<Coordinates, Node> gameBoard = new Dictionary<Coordinates, Node>(); //This is a list of all the nodes in the map. The coordinates are the key which map to a node being the value.
public int length; 
public int width;    
Coordinates testCords = new Coordinates(0,0);
Node testNode;

public int move;

public Coordinates selectorStartPosition;

//length and width of the board





//The initializeBoard() function places nodes at each space on the board. It gives each node an x,y, and z value that can then be used later for path finding and node-searching easily.
//The maps will all be rectangular shaped so, maping nodes by length and width will always work. Even then, this function controls for "void spaces" as well, meaning, non-rectangular maps are capable of passing through the function and mapping correctly
public void initializeBoard() {
RaycastHit hit;


    for(int x= -length; x < length; x++) {
        for(int z = -width; z < width; z++) {
            
            if(Physics.Raycast(new Vector3(x, 100f, z), Vector3.down, out hit)) {
          
             
            Node newNode = new Node(x, hit.point.y,z);
            gameBoard[newNode.cords] = newNode; }else {
            Node newNode = new Node(x, -2, z);
            gameBoard[newNode.cords] = newNode;
           
            }
            
           
            
        }
    }
    

}

//This OnDrawGizmos() function is being used purely as a debugging tool and will not be used later on. It just shows me that the nodes are being mapped correctly.
private void OnDrawGizmos() {
   
     if(gameBoard.Count != 0) {
        foreach(Node tile in gameBoard.Values) {
            
            Gizmos.color = (traversableNodes.Contains(tile)) ? Color.green: Color.blue;
            Gizmos.DrawCube(new Vector3(tile.cords.x, tile.yCord ,tile.cords.z), new Vector3(.1f,1f,.1f));
            
        }
     }
}
public void wipeNodeLists() {
    nodesToCheck.Clear();
    visitedNodes.Clear();
    traversableNodes.Clear();
}
public void findTraversableNodes(Node startNode, int movementResource){ //This function finds the nodes that a unit can traverse from a starting node given a movement cost.
startNode.movementCost = 0;
wipeNodeLists();

Node nodeBeingChecked;
   if (!gameBoard.ContainsKey(startNode.cords))
    { //the starting node doesnt exist on the board so the check is invalid
        return;
    }
    startNode.movementCost = 0;
    nodesToCheck.Enqueue(startNode);
    while(nodesToCheck.Count > 0 ) {
    
        nodeBeingChecked = nodesToCheck.Peek();
        if(!visitedNodes.Contains(nodeBeingChecked) && nodeBeingChecked.movementCost <= movementResource) {
            traversableNodes.Add(nodeBeingChecked);
        checkNeighbors(nodeBeingChecked);
       
        visitedNodes.Add(nodeBeingChecked); } else {

            
            
        }
        nodesToCheck.Dequeue();
            
            
    }

foreach (Node n in traversableNodes) {
    
}

} 
private void checkNeighbors(Node node) { //This function will check the neighboring nodes of a given node 

Node nodeToAdd;
float height = node.yCord; //right now this will be only applicable to walking units and will be changed to accomodate all movement types. For now i'm keeping it basic to just walking units.
Queue<Coordinates> cordsToCheck = 1 + node.cords;

while(cordsToCheck.Count > 0 ) {
    if(gameBoard.ContainsKey(cordsToCheck.Peek())) {
        nodeToAdd = gameBoard[cordsToCheck.Peek()];

        cordsToCheck.Dequeue();
        if(Math.Abs(height - nodeToAdd.yCord) < 2) {
        nodesToCheck.Enqueue(nodeToAdd);
        nodeToAdd.movementCost = node.movementCost + nodeToAdd.moveEcon; 
        }
    }

}


}
void Awake() { //awake function, as soon as our grid gameObject gets put into the scene, this function starts and the board is initialized.
    initializeBoard();
   

  
    
    
}



}







