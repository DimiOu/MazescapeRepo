using UnityEngine;
using System.Collections;

public class Ghost : Player
{
    [SerializeField] private float ghostRadius = 1;
    void Update()
    {
        Move();
        performAbility();
    }

    public override void performAbility()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        Collider[] colliders = Physics.OverlapSphere(transform.position,ghostRadius);
        foreach(Collider nearbyObj in colliders)
        {
            if (nearbyObj.tag == "StoneWall")
            {
                nearbyObj.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(ResetCollider(nearbyObj));
            }    
        }
    }

    IEnumerator ResetCollider(Collider collider)
    {
        yield return new WaitForSeconds(0.5f);
        collider.GetComponent<BoxCollider>().enabled = true;
    }
}
