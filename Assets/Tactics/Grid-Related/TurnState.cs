using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnStates : MonoBehaviour
{
 //This script holds the different states that a turn can be in. It uses an enum to do so.
  public enum States {
        startPhase, 
        mainPhase,
        movementPhase,
        actionPhase, 
        mainPhase2,
        endPhase
    }
}
