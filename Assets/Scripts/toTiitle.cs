using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toTiitle : MonoBehaviour
{
    // Start is called before the first frame update
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Debug.Log("After Scene is loaded and game is running");
        // �X�N���[���T�C�Y�̎w��
        Screen.SetResolution(1920, 1080,true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Initiate.Fade("title", Color.black, 4f);
        }

    }
}
