using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateInfo : MonoBehaviour
{
    public BoxCollider touchHitbox;
    public GameObject[] breakEffects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            if (CraneManagement.main != null)
            {
                CraneManagement.main.DeleteCrate(this);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void BreakCrate()
    {
        Instantiate(breakEffects[Random.Range(0,breakEffects.Length)], transform.position, transform.rotation, null);
    }
}
