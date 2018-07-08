using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //マウス左クリック、スペースキー、Aボタン、ジャンプボタンを押した場合
        //if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space") || Input.GetButtonDown("Action1") || Input.GetButtonDown("Jump")) {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) {
            SceneManager.LoadScene("GameScene");
        }

    }

    public void SceneLoad () {
        SceneManager.LoadScene("GameScene");
    }
}