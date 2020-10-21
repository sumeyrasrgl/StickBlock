using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedObjectController : MonoBehaviour
{
    PlayerManager playerManager;

    [SerializeField] Transform sphere;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();

        sphere = transform.GetChild(0);
        if (GetComponent<Rigidbody>()==null)
        {
            gameObject.AddComponent<Rigidbody>();

            Rigidbody rb = GetComponent<Rigidbody>();

            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            GetComponent<Renderer>().material = playerManager.collectedObjMaterial;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CollectibleObject"))
        {
            if (!playerManager.collidedList.Contains(collision.gameObject))
            {
                collision.gameObject.tag = "CollectedObject";
                collision.transform.parent = playerManager.collectedPoolTransform;
                playerManager.collidedList.Add(collision.gameObject);
                collision.gameObject.AddComponent<CollectedObjectController>();
            }
        }
    }
}
