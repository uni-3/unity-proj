using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var body = gameObject.GetComponent<Rigidbody2D>();

        // 親オブジェクト canvas
		var canvas = GetComponentInParent<Canvas>();

		// 大きさが1になるように指定
		var direction = new Vector2(Random.value, 1).normalized;
		// 1なので、640を掛ける
		body.velocity = direction * 640 * canvas.transform.localScale.x;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
