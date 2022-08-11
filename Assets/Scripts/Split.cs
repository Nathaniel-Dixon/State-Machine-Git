using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour
{
    [SerializeField] float shrinkPercent = 0.5f;
    [SerializeField] float smallestSize = 0.25f;
    // unity cant see this
    public Bullet splitByBullet = null;
    //[System.NonSerialized] public Bullet splitByBullet = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet != null)
        { //we hit a billut
            //if (bullet.isUsed) return;
            //hide if desotry bullet?
            if (bullet == splitByBullet) return;
            //  bullet.isUsed = true;

            transform.localScale *= shrinkPercent;

            if (transform.localScale.x < smallestSize)
            {
                Destroy(gameObject);
                return;
            }
            splitByBullet = bullet;
            // GameObject newGO = Instantiate(gameObject,
            Instantiate(gameObject,
                transform.position,
                transform.rotation);

            // hide both lines under nearth
            //splitByBullet = bullet;
            // newGO.GetComponent<Split>().splitByBullet = bullet;
            // un hide to destory
            // Destroy(bullet);
        }
    }
}
