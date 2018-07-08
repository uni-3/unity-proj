using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour {
    // トリガーとの接触時に呼ばれる
	// hitには接触対象情報が含まれている
	void OnTriggerEnter (Collider hit) {
		// Playerタグをもたせる対象オブジェクトに対してinspectorで設定する
		if (hit.CompareTag("Player")) {
			Destroy(gameObject);
		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
