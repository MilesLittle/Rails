using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsController : MonoBehaviour
{
    //This script controlls the states of the game. It will include the controller for changing turns, phases,etc. The basic architecture that I want to use for it is using a turn queue
    //The turn queue will essentially be a revolving queue of units, then the state controller will control the turn phases that the unit will go through, and once the turn has ended, it will repeat for the next unit in the queue while the unit that has gone will be re-entered at the back of the queue.


 private turnStates turnPhases;


}
