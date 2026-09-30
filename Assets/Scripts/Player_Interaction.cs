using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    public bool canInteract = false;
    public GameObject Etext;
    public static Player_Interaction instance;

    void Start()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable NPC"))
        {
            //Debug.Log("Player can interact");
            canInteract = true;
            Etext.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable NPC"))
        {
            //Debug.Log("Player cannot interact");
            canInteract = false;
            Etext.SetActive(false);
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Player_Movement.instance.canMove = false;
            NPC_Interaction.instance.Interact();
        }
    }
}

