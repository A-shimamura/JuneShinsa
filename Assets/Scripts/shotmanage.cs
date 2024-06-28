using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class shotmanage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 1;
    bool _chengeflag = false;
    [SerializeField] static int _ra;
    Vector2 enem;
    float time;
    SpriteRenderer em;
    int _mode;

    void Awake()
    {
        em = gameObject.GetComponent<SpriteRenderer>();
    }
    public void Init(int Mode)
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        time = 0;
        speed = 1;
        em.sortingOrder = _ra;
        _ra++;
        if (_ra > 1000) { _ra = 0; }
        _mode = Mode;
    }
    public void Init(int Mode,Vector2 pos)
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        time = 0;
        speed = 1;
        em.sortingOrder = _ra;
        _ra++;
        if (_ra > 1000) { _ra = 0; }
        _mode = Mode;
        enem = pos;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (_mode == 1)
        {
            Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
            gameObject.transform.position += velocity * Time.deltaTime;
            if (Vector2.Distance(gameObject.transform.position, enem) <= 0.8f)
            {
                gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            if (time >= 1.5) speed = 4f;
        }
        if(_mode == 2)
        {
            speed = 6f;
            if (Vector2.Distance(gameObject.transform.position, enem) <= 0.8f)
            {
                gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
            gameObject.transform.position += velocity * Time.deltaTime;
        }
    }
}
