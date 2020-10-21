using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;

    private Rigidbody rb;

    [SerializeField] bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material = playerManager.collectedObjMaterial;

        playerManager.collidedList.Add(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded();
        }
    }

    void Grounded()
    {
        isGrounded = true;
        playerManager.playerState = PlayerManager.PlayerState.Move;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        Destroy(this, 1);
    }
}
