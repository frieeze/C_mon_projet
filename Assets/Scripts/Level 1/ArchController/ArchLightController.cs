using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchLightController : MonoBehaviour
{

    [SerializeField] private Light archLight;
    // Start is called before the first frame update
    void Start()
    {
      archLight.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        archLight.enabled = true;
    }
}
