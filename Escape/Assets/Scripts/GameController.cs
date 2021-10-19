using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_Text displayText; // Used to display our text to the screen.
    public InputAction[] InputActions;
    [HideInInspector] public RoomNavigation roomNavigation; // We want to be public to other scripts but not show up in the inspecter. Will show up in awake.
    [HideInInspector] public List<string> interactionDecriptionsInRoom = new List<string>(); // List of descriptions based on the room
    List<string> actionLog = new List<string>(); // List for our string log
    void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation>(); // Gets actual room navigation component from inspector
    }

    void Start()
    {
        DisplayRoomText(); // Gets description
        DisplayLoggedText(); // Takes text from log
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray()); // Converts our list of strings to a string

        displayText.text = logAsText; // Displays text to screen
    }

    public void DisplayRoomText()
    {
        // Clear old room
        ClearCollectionsForNewRoom();
        // unpack new room
        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n", interactionDecriptionsInRoom.ToArray()); // Add the descriptions to the combined text

        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions; // Displays text from Room navigation with the interaction descriptions

        LogStringWithReturn(combinedText); // sends to be added to list of strings
    }

    void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
    }

    // Clears info from the room 
    void ClearCollectionsForNewRoom()
    {
        interactionDecriptionsInRoom.Clear();
        roomNavigation.ClearExits();
    }

    // Called anytime we want to add data to our list
    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
