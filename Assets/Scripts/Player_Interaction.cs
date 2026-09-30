using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    private bool canInteract = false;
    public GameObject Etext;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable NPC"))
        {
            Debug.Log("player can interact");
            canInteract = true;
            Etext.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable NPC"))
        {
            Debug.Log("player cannot interact");
            canInteract = false;
            Etext.SetActive(false);
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            canInteract = false;
            Player_Movement.instance.canMove = false;
            NPC_Interaction.instance.Interact();
        }
    }
}

