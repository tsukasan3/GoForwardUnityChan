using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    //キューブの移動速度
    private float speed = -0.2f;

    //消滅位置
    private float deadLine = -10;

    //効果音を入れる
    public AudioClip impact;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        //効果音のコンポーネント取得
        audio = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
        //キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        //画面外に出たら破棄する
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
	}

    //トリガーモードで他のオブジェクトに接触した場合の処理
    void OnCollisionEnter2D(Collision2D other)
    {
        //地面やキューブに接触した時に効果音を発生
        if(other.gameObject.tag == "CubeTag" || other.gameObject.tag == "GroundTag")
        {
            audio.PlayOneShot(impact, 0.4f);
        }
    }
}
