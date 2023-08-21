using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay= 0.3f;
    bool hasPackage;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("You bumped something");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if (the thing we trigger is the package)
        // then print "package picked up" to the console
        if(collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("You picked up a package");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, destroyDelay);
        }

        if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("You delivered package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
