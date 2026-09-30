using UnityEngine;

public class NPC_Interaction : MonoBehaviour
{
    public static NPC_Interaction instance;
    public GameObject dialogueBox;
    public GameObject canvas;

    private void Start()
    {
        instance = this;
    }

    public void Interact()
    {
        Debug.Log("Interacting with NPC");
    }

}
