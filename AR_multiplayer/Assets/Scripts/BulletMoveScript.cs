using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveScript : MonoBehaviour {
    public int speed;

    public float Lifetime = 2f;

    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Die", Lifetime);
    }

    void Die(){
        CancelInvoke();
        gameObject.SetActive(false);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}
}
