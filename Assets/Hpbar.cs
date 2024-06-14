using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    // Start is called before the first frame update4
    public GameObject _square;
    Vector2 Vector3 = Vector2.zero;
    public Camera targetCamera;
    enemy _hpcount;
    Image _circle;

    void Start()
    {
        _hpcount = _square.GetComponent<enemy>();
        _circle = gameObject.GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _circle.fillAmount = _hpcount._hp / 1000f;
        this.transform.position = targetCamera.WorldToScreenPoint(_square.transform.position);
    }
}
