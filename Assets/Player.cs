using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]float speed = 1;
    [SerializeField]Text text;
    public Transform _ue;
    public Transform _sita;
    public Transform _migi;
    public Transform _hidari;
    Vector2 Vector2 = Vector2.zero;
    private int hit = 1;
    private SpriteRenderer _thisball;
    // Start is called before the first frame update
    void Start()
    {
        _thisball = gameObject.GetComponent<SpriteRenderer>();
        _thisball.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 0.4f;
            _thisball.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 1f;
            _thisball.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 = transform.position;

        if (Input.GetKey(KeyCode.UpArrow) && Vector2.y <= _ue.position.y)
        {
            Vector2.y += speed * 0.1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Vector2.y >= _sita.position.y)
        {
            Vector2.y -= speed * 0.1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Vector2.x >= _hidari.position.x)
        {
            Vector2.x -= speed * 0.1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Vector2.x <= _migi.position.x)
        {
            Vector2.x += speed * 0.1f;
        }

        transform.position = Vector2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "shoot")
        {
            text.text = hit++.ToString();
        }
        if (collision.tag == "haji1")
        {
            Vector2.x += 0.01f;
            Debug.Log("“–‚½‚Á‚Ä‚à‚½");
        }
        if (collision.tag == "haji2")
        {
            Vector2.x -= 0.01f;
            Debug.Log("“–‚½‚Á‚Ä‚à‚½");
        }
        if (collision.tag == "ue1")
        {
            Vector2.y -= 0.01f;
            Debug.Log("“–‚½‚Á‚Ä‚à‚½");
        }
        if (collision.tag == "ue2")
        {
            Vector2.x += 0.01f;
            Debug.Log("“–‚½‚Á‚Ä‚à‚½");
        }

    }
}
