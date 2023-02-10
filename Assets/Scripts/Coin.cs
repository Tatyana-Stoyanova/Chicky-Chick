using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Animator _animator;
    int _points = 100;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameManager.Instance.Score += _points;
            gameObject.SetActive(false);
            _animator.SetBool("isActive", false);
            Destroy(gameObject);
            
        }
    }
}
