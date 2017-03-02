using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody playerRigidbody;
    private int count;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody>();
        count = 0;
        RefreshCountText();
        winText.text = string.Empty;
	}
	
	// Update is called once per frame
	void Update () {
        // Record input from our player.
        float moreHorizontal = Input.GetAxis("Horizontal");
        float moreVertical = Input.GetAxis("Vertical");

        // Use the input we get to move the rigid body.
        Vector3 movement = new Vector3(moreHorizontal, 0.0f, moreVertical);
        // Make a smooth movement by multiplying by Time.deltaTime.
        // Adjust our 'movement' vector by 'speed' to make game playable.
        playerRigidbody.AddForce(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if our object collides with a pickup object.
        if (other.gameObject.tag == "PickUp Type 1")
        {
            HandleObjectCollision(other.gameObject, 1);
        }
        else if (other.gameObject.tag == "PickUp Type 2")
        {
            HandleObjectCollision(other.gameObject, 4);
        }
    }

    private void RefreshCountText()
    {
        countText.text = "Score: " + count.ToString();
    }

    private void HandleObjectCollision(GameObject currentGameObject, short addToCount)
    {
        currentGameObject.SetActive(false);
        count += addToCount;
        RefreshCountText();
        if (count >= 9)
        {
            winText.text = "Congratulations, you've won!";
        }
    }
}
