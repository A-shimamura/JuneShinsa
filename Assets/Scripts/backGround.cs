using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class backGround : MonoBehaviour
{
    [SerializeField] GameObject bg1;
    [SerializeField] GameObject bg2;
    Vector2 _pos1,_pos2;
    // Start is called before the first frame update
    void Start()
    {
        bg1.transform.position = new Vector2(0, 0);
        bg2.transform.position = new Vector2(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        _pos1 = bg1.transform.position;
        _pos2 = bg2.transform.position;
        _pos1.y -= 2 * Time.deltaTime;
        _pos2.y -= 2 * Time.deltaTime;
        if (_pos1.y < -10)
        {
            _pos1.y = 10;
        }
        if (_pos2.y < -10)
        {
            _pos2.y = 10;
        }
        bg1.transform.position = _pos1;
        bg2.transform.position = _pos2;
    }
}
