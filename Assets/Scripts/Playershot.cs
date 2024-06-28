using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playershot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 4;

    float time;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
        gameObject.transform.position += velocity * Time.deltaTime;
    }
}
