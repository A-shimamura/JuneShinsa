using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotmanage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 1;
    bool _chengeflag = false;

    float time;
    void Start()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
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
        if (time <= 0.7)
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
        else if (!_chengeflag)
        {
            gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            _chengeflag = true;
        }
        if (time >= 1.5) speed = 4f;
    }
}
