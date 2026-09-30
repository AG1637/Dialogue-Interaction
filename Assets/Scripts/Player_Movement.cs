using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool canMove = true;
    public static Player_Movement instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (canMove)
        {
            float move = Input.GetAxis("Vertical");
            transform.position += transform.forward * move * moveSpeed * Time.deltaTime;
        }
    }
}
