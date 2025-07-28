using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Tower"))
        {
            other.gameObject.GetComponent<Tower>().TakeDamage(10);

            StartCoroutine(Explode());
        }
    }
    
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
