using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1Text : MonoBehaviour
{
    [SerializeField] private GameObject[] text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            text[1].SetActive(true);
            text[0].SetActive(false);
            text[2].SetActive(true);
        }
        
    }
}
