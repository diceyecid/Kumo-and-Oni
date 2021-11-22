using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summon : MonoBehaviour
{
    public GameObject enemies, kumo, oni;
    // Start is called before the first frame update
    void Start()
    {
        enemies.GetComponent<EnemyScript>().Kumo = kumo.transform;
        enemies.GetComponent<EnemyScript>().Oni = oni.transform;
        Instantiate(enemies, this.transform.position, this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        if (this.GetComponent<SpriteRenderer>().sprite.name == "shadow_7")
        {            
            Destroy(this.gameObject);
        }
    }
}
