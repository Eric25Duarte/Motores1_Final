using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject bladePrefab;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float rotationSpeed = 90f; // degrees per second

    // Start is called before the first frame update
    public void setParent(GameObject part)
    {
        parent = part;
    }
    void Start()
    {
        int bladeCount = 8;
        for (int i = 0; i < bladeCount; i++)
        {
            float angle = i * Mathf.PI * 2f / bladeCount;
            Vector3 position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            float angleDeg = angle * Mathf.Rad2Deg;
            // Swords point down, so rotate +90 to align 'down' with outward
            Quaternion rotation = Quaternion.Euler(0, 0, angleDeg + 90f);
            Instantiate(bladePrefab, transform.position + position, rotation, gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (parent == null)
        {
            Destroy(gameObject);
            return;
        }
		transform.position = parent.transform.position;
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
