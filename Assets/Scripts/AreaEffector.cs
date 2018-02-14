using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaEffector : MonoBehaviour {

	public float time = 0;
	public bool active = true;
	public GameObject child;
	
	// Update is called once per frame
	void Update ()
	{
		time += Time.deltaTime;	//la variable tiempo va a ser igual al tiempo que ha transcurrido en el juego 
		
		if (time >= 3f)	//cada 3 segundos se van a prender/apagar las "luces"
		{
			active = !active;
			child.gameObject.SetActive(active);
			time = 0;
		}
	}
}

