using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeGeneratorGenerator : MonoBehaviour
{
    [SerializeField] private BladeGenerator bladePrefab;
    // Start is called before the first frame update
    void Start()
    {
        bladePrefab = Instantiate(bladePrefab, transform.position, Quaternion.identity);
        bladePrefab.setParent(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
