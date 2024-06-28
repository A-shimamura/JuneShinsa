using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject _shoot;
    [SerializeField]float speed = 1;
    [SerializeField]Text text;
    [SerializeField] Text textt;
    [SerializeField] GameObject area;
    [SerializeField] GameObject enem;
    public Transform _ue;
    public Transform _sita;
    public Transform _migi;
    public Transform _hidari;
    public bool _gameoverflag = false;
    Vector2 Vector2 = Vector2.zero;
    private SpriteRenderer _thisball;
    [SerializeField] float _shotcool = 0.1f;
    private float _shottime;
    private ObjectPool _objectPool = default;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector2(0,-4);
        _objectPool = new();
        area.GetComponent<DeleteA>().PInitialize(_objectPool);
        enem.GetComponent<enemy>().Initialize(_objectPool);
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
        _shottime += Time.deltaTime;
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
        
        if(Input.GetKey(KeyCode.Z)&& Input.GetKey(KeyCode.LeftShift) && _shotcool <=_shottime)
        {
            _shottime = 0;
            var g = _objectPool.SpawnObject(_shoot);
            g.transform.position = this.transform.position;
            g.transform.rotation = Quaternion.Euler(0, 0, 90f);
            //var g = Instantiate(_shoot, this.transform.position,Quaternion.Euler(0,0,90f));
            //var g1 = Instantiate(_shoot, this.transform.position, Quaternion.Euler(0, 0, 85f));
            //var g2 = Instantiate(_shoot, this.transform.position, Quaternion.Euler(0, 0, 95f));
        }
        else if (Input.GetKey(KeyCode.Z) && _shotcool <= _shottime)
        {
            _shottime = 0;
            var g = _objectPool.SpawnObject(_shoot);
            g.transform.position = this.transform.position;
            g.transform.rotation = Quaternion.Euler(0, 0, 90f);
            var g1 = _objectPool.SpawnObject(_shoot);
            g1.transform.position = this.transform.position;
            g1.transform.rotation = Quaternion.Euler(0, 0, 85f);
            var g2 = _objectPool.SpawnObject(_shoot);
            g2.transform.position = this.transform.position;
            g2.transform.rotation = Quaternion.Euler(0, 0, 95f);
            //var g = Instantiate(_shoot, this.transform.position, Quaternion.Euler(0, 0, 90f));
            //var g1 = Instantiate(_shoot, this.transform.position, Quaternion.Euler(0, 0, 85f));
            //var g2 = Instantiate(_shoot, this.transform.position, Quaternion.Euler(0, 0, 95f));
        }

        transform.position = Vector2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "shoot")
        {
            _gameoverflag = true;
            text.text = "ƒAƒEƒg‚â‚Å";
        }
    }
}
