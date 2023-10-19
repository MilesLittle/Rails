using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSelector : MonoBehaviour
{
  //This script is used to select nodes for any purpose. Movement, attacking, etc. 

  public GameObject nodeSelector;
  public Board board;
  public Camera tacticsCamera;

  public float cameraHeight;

  Node currentNode;

  public int xStart;
  public int zStart;


public enum Directions {
    Up,
    Down,
    Left,
    Right,
    Neutral
}

Directions directionGoing = Directions.Neutral;

public float inputTimer;
private float lastInput = 0;

private bool takingInputs = true;


private void WaitTime(float amountOfTime) {
    takingInputs = false;
    inputTimer = amountOfTime;
}
private void moveCamera() {
tacticsCamera.transform.position = new Vector3(nodeSelector.transform.position.x, cameraHeight, nodeSelector.transform.position.z - 10);
tacticsCamera.transform.rotation = Quaternion.Euler(45, 0, 0);
}
private void moveSelector(){

Coordinates tempCords = currentNode.cords;

 
switch (directionGoing) {
case Directions.Up:
  
   
    
    tempCords.z +=  1;
   
    
   

    break;

case Directions.Down:
   
  
   
     
    tempCords.z -=  1;
 
    
    
   

   break;
case Directions.Left:
    
 
    
   tempCords.x -=  1;
 
    
   
   

   break;

   case Directions.Right:
   

   
     tempCords.x +=  1;
 
    
    
   

   break;
default: 
break;

}

if(board.gameBoard.ContainsKey(tempCords) && board.traversableNodes.Contains(board.gameBoard[tempCords])){
currentNode = board.gameBoard[tempCords];

nodeSelector.transform.position = new Vector3(currentNode.cords.x, currentNode.yCord + .5f, currentNode.cords.z ); }

moveCamera();


}

void Start() {
    
if(board.gameBoard != null && board.gameBoard.Count > 0) {
  if(board.gameBoard.ContainsKey(new Coordinates(xStart, zStart))) {
    currentNode = board.gameBoard[new Coordinates(xStart, zStart)];

  } else {
    currentNode = board.gameBoard[new Coordinates(0,0)];

  } }
  nodeSelector.transform.position = new Vector3(currentNode.cords.x, currentNode.yCord, currentNode.cords.z);
  moveCamera();
  

}

void Update() {

   if(takingInputs) {
     if (Input.GetKey(KeyCode.W))
        {
            directionGoing = Directions.Up;
            WaitTime(inputTimer);  
       
         
        }else  if (Input.GetKey(KeyCode.A))
        {
            directionGoing = Directions.Left;
            WaitTime(inputTimer);  
            
           
            
            
        }else  if (Input.GetKey(KeyCode.S))
        {
            directionGoing = Directions.Down;
            WaitTime(inputTimer);  
            
            
        } else  if (Input.GetKey(KeyCode.D))
        {
            directionGoing = Directions.Right;
            WaitTime(inputTimer);
           
            

        }  else if (Input.GetKey(KeyCode.Return))
        {
           Node startNode = currentNode;
                board.findTraversableNodes(startNode, 3);
            WaitTime(inputTimer);  
            
        }
            else{
            directionGoing = Directions.Neutral;
            takingInputs = true;
        }
  moveSelector();     
  
  
  
   
}  
if (inputTimer > lastInput) {
lastInput += Time.deltaTime;
}else {
    takingInputs = true;
    lastInput = 0;
}

 }

  
}
