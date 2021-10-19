using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates an asset for input action
[CreateAssetMenu(menuName = "TextAdventure/InputActions/Go")]
public class Go : InputAction
{
    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        // using verb now grammer
        // Second word is going to be the keyword for the room according to our grammer, pass to change rooms
        controller.roomNavigation.AttemptToChangeRooms(seperatedInputWords[1]);
    }
}
