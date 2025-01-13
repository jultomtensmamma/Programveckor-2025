using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject[] characters; // Array to hold character GameObjects
    private int currentCharacterIndex = 0;

    void Start()
    {
        // Ensure only the first character is active at the start
        ActivateCharacter(currentCharacterIndex);
    }

    void Update()
    {
        // Check for number key presses
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchCharacter(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && characters.Length > 1)
        {
            SwitchCharacter(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && characters.Length > 2)
        {
            SwitchCharacter(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && characters.Length > 3)
        {
            SwitchCharacter(3);
        }
    }

    void SwitchCharacter(int characterIndex)
    {
        if (characterIndex != currentCharacterIndex && characterIndex < characters.Length)
        {
            // Get the current character's position and rotation
            Vector3 lastPosition = characters[currentCharacterIndex].transform.position;
            Quaternion lastRotation = characters[currentCharacterIndex].transform.rotation;

            // Deactivate current character
            characters[currentCharacterIndex].SetActive(false);

            // Activate the new character and set its position/rotation
            currentCharacterIndex = characterIndex;
            characters[currentCharacterIndex].SetActive(true);
            characters[currentCharacterIndex].transform.position = lastPosition;
            characters[currentCharacterIndex].transform.rotation = lastRotation;
        }
    }

    void ActivateCharacter(int index)
    {
        // Deactivate all characters
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == index);
        }
    }
}
