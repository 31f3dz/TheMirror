using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    Transform player; // プレイヤー情報
    public Vector3 offset = new Vector3(0, 3, -8); // プレイヤーとの距離感
    public float followSpeed = 5.0f; // 追従スピード

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Updateの後に処理
    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPos = player.position + offset; // そのときのプレイヤーの位置＋距離感

        // Lerp(現在地, 目的地, 進捗率(0-1))
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);

        // プレイヤーより少し上の座標を取得
        Vector3 lookTarget = player.position + new Vector3(0, 1.5f, 0);

        // 引数のTransform.positionの方を向かせる
        transform.LookAt(lookTarget);
    }
}
