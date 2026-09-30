using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float move = Input.GetAxis("Vertical");
        transform.position += transform.forward * move * moveSpeed * Time.deltaTime;
    }
}
