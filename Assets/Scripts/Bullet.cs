using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    public bool isUsed = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector2 diretion = transform.up;
        Vector2 position = transform.position;

        diretion = diretion.normalized * _speed * Time.deltaTime;

        transform.position = position + diretion;
    }

    void Start()
    {
        StartCoroutine(DestroySelf(2f));
    }

    IEnumerator DestroySelf(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        //WaitForSeconds waitForSeconds = new WaitForSeconds(seconds);
        //yield return waitForSeconds;
        GameObject.Destroy(gameObject);
        //GameObject.Destroy(this);
    }

    //void DestroyObjectDelayed(object,float t = 2f)
    //  {
    // Kills the game object in 5 seconds after loading the object
    //      Destroy(gameObject, 2);
    //  }

}
