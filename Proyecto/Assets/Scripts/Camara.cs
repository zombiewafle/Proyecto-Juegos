using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform Seguir;
    private Vector3 mover;
    // Start is called before the first frame update
    void Start()
    {
        mover = Seguir.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        mover = Seguir.transform.position;
        mover.z = transform.position.z;
        mover.y += 0f;
        transform.position = mover;



    }
}
