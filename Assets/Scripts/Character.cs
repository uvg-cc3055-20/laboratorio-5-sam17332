using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour {


    Rigidbody2D rb2d;
    SpriteRenderer sr;
    Animator anim;
    private float speed = 5f;
    private float jumpForce = 250f;
    private bool facingRight = true;
    public GameObject feet;
    public LayerMask layerMask;
	public ParticleSystem dust;
 


	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
	

	void Update () {
        float move = Input.GetAxis("Horizontal");	//se puede mover el personaje
        if (move != 0) {
            rb2d.transform.Translate(new Vector3(1, 0, 0) * move * speed * Time.deltaTime);
            facingRight = move > 0;
        }

        anim.SetFloat("Speed", Mathf.Abs(move));

        sr.flipX = !facingRight;
	    if (Input.GetButtonDown("Jump"))	// sirve para que solo pueda saltar una vez.   
	    { 
		    RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, layerMask);
		    if (raycast.collider != null)
		    {
			    rb2d.AddForce(Vector2.up * jumpForce);
		    }
	    }
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("cambiar"))
		{
			SceneManager.LoadScene("Dungeon2");
		}
		if (other.gameObject.CompareTag("cambiar2"))
		{
			SceneManager.LoadScene("Dungeon3");
		}
		if (other.gameObject.CompareTag("cambiar3"))
		{
			SceneManager.LoadScene("Final");
		}
		if (other.gameObject.CompareTag("Reiniciar"))
		{
			transform.position = new Vector3(-6.919752f, -3.56f, 0);
			SceneManager.LoadScene("Dungeon1");
			dust.Play();
		}
	}
}