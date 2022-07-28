using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//private - Unity cannot, others classes cannot
//public -  Unity can, other claesses can
//[SerializeField] private - Unity can, other classes cannot

public class AIAgent : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // this.transform.position;
        Vector2 directionToPlayer = player.transform.position - transform.position;

        //if you want to know the direction from A to B
        // A -----> B
        // DirAToB = B - A;
        if (directionToPlayer.magnitude > 0.1f)
        {
            directionToPlayer.Normalize();
            directionToPlayer *= speed * Time.deltaTime;
            transform.position += (Vector3)directionToPlayer;
        }
    }
}
