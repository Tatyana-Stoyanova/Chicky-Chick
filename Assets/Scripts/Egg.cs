using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Egg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Floor" || transform.position.y == -9)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        if(other.transform.tag == "Player")
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);

        }
        
        
    }
}
