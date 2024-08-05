using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    public bool ColliderVolumeFlg;

    public AudioClip groundHitSound;

    public AudioClip blockHitSound;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        // キューブを移動させる
        transform.Translate (this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy (gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //オブジェクトが衝突しているかどうか判断
        this.ColliderVolumeFlg = true;
        Debug.Log(this.ColliderVolumeFlg);

        // オブジェクトが地面に接触
        if (collision.gameObject.CompareTag("Ground"))
        {
            // 地面に接触したときの音を再生
            if (groundHitSound != null)
            {
                audioSource.PlayOneShot(groundHitSound);
            }
        }
        // 他のキューブと積み重なったときの音を再生
        else if (collision.gameObject.CompareTag("Cube"))
        {
            audioSource.PlayOneShot(blockHitSound);
        }
    }
}