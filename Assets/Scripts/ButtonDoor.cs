using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
	public button btn;
	public Door door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if( btn.pressed )
	   {
		   door.openDoor();
	   }
	   else
	   {
		   door.closeDoor();
	   }
    }
}
