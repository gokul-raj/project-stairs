using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	Rigidbody2D rb;
	public float moveSpeed=5f;
	private bool ifClicked;
	private int stairsPassed=1;
	
	// Use this for initialization
	void Start() 
	{
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(moveSpeed, 0);
	}
	
	void OnTriggerEnter2D(Collider2D cols)
	{
		if(cols.gameObject.tag == "Edge" && ifClicked == true)
		{
			Debug.Log("Turn!");
			GameObject.Find("Stair (" + stairsPassed + ")").GetComponent<EdgeCollider2D>().enabled = false;
			moveSpeed = -Mathf.Abs(moveSpeed);
			Debug.Log(moveSpeed);
			rb.velocity = new Vector2(moveSpeed, 0);
			stairsPassed++;
		}
	}
	
	IEnumerator OnMouseDown()
	{
		Debug.Log("Clicked!");
		ifClicked = true;
		yield return new WaitForSeconds(1f);
		ifClicked = false;
	}
}
