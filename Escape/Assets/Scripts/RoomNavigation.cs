using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom; // Displays what room we are currently in

    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();
    GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController>(); // Gets the game controller object
    }
    // Goes over current array of exits in the current room and passes to game controller to diplay ot screen
    public void UnpackExitsInRoom()
    {
        // We enter a room, unpack the exits, add to list of descriptions, and then get ready to send to the screen
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            // Adds the current room to the dictonart
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
            controller.interactionDecriptionsInRoom.Add(currentRoom.exits[i].exitDescription);
        }
    }

    public void AttemptToChangeRooms(string directionNoun)
    {
        // If the direction is recognized by the dictionary change rooms
        if (exitDictionary.ContainsKey(directionNoun))
        {
            currentRoom = exitDictionary[directionNoun];
            controller.LogStringWithReturn("You head off to the " + directionNoun);
            controller.DisplayRoomText();
        }
        else
        {
            controller.LogStringWithReturn("There is no paath to the " + directionNoun);
        }
    }

    // Clears our exits for the new room
    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
