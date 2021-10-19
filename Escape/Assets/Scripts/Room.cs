using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "TextAdventure/Room")] // Allows us to create access instances of scriptable object
public class Room : ScriptableObject
{
    [TextArea]
    public string description; // Description of the Room
    public string roomName; // Name of Room
    public Exit[] exits; // Our array of Exit objects
}
