using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotmanage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]float speed = 1;
    float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
        gameObject.transform.position += velocity * Time.deltaTime;
        if (time >= 2) speed = 5f;
        if (time >= 5) Destroy(this.gameObject);
    }
}
