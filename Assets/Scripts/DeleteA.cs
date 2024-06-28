using UnityEngine;

public class DeleteA : MonoBehaviour
{
    [SerializeField] ObjectPool _objectPool = default;
    [SerializeField] ObjectPool _pobjectPool = default;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Initialize(ObjectPool objectPool)
    {
        _objectPool = objectPool;
    }
    public void PInitialize(ObjectPool objectPool)
    {
        _pobjectPool = objectPool;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "shoot")
        {
            _objectPool.RemoveObject(collision.gameObject);
            //Destroy(collision.gameObject);
        }
        else if (collision.tag == "pshoot")
        {
            _pobjectPool.RemoveObject(collision.gameObject);
        }
    }
}
