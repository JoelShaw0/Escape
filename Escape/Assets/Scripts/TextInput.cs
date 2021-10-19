using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextInput : MonoBehaviour
{
    public TMP_InputField inputField; // 
    GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController>();
        inputField.onEndEdit.AddListener(AcceptStringInput); // Call AcceptStringInput when onEndEdit is raised aka when someone stops editing the field or hits return
    }
    void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower(); // like pythons to lower function, makes user input the same for upper and lowercase
        controller.LogStringWithReturn(userInput); // shows input to user

        // The chars that we are looking for to seperate our words are spaces
        char[] delimiterCharacters = { ' ' };
        // Take what the character has typed and seperate into an array of words
        string[] separatedInputWords = userInput.Split(delimiterCharacters);

        for (int i = 0; i < controller.InputActions.Length; i++)
        {
            InputAction inputAction = controller.InputActions[i];
            // Check if the first word in our array is an input action
            if (inputAction.keyWord == separatedInputWords[0])
            {
                // We respond to input
                inputAction.RespondToInput(controller, separatedInputWords);
            }
        }

        InputComplete();
    }

    // We are done and want new input
    void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField(); // Returns focus to the field
        inputField.text = null; // clears field
    }
}
