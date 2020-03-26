// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 杉の木の管理を行うクラス
public class TreeManager : SingletonMonoBehaviour<TreeManager>
{
    [SerializeField] private GameObject tree = default;
    [SerializeField] private GameObject tree_folder = default;
    const int MAX_TREE = 20;    // とりあえず最大数は20個に
    public int Tree_count { get; set; }
    public bool debug;

    protected override void Awake()
    {
        base.Awake();

        if (debug) return;

        transform.position = new Vector3(-2.5f, 4.0f, 0.0f);    // 初期値
        Vector3 instance_point = transform.position;            // 木を生成する座標
        float point_shift = 0.25f;                              // どのくらいずらして生成するか

        // 最初に杉を最大数出現
        for(int i = 0; i < MAX_TREE; i++)
        {
            transform.position = instance_point;
            GameObject obj = Instantiate(tree, transform);
            Tree_count++;
            // 生成した杉を自分の子供にする
            obj.transform.parent = tree_folder.transform;
            instance_point.x += point_shift;
        }
    }

    void Update()
    {
        if(Tree_count <= 0)
        {
            ScreenManager.Instance.IsWin = true;
            // リザルト画面に遷移する
            Debug.Log("杉軍団全滅！");
        }
    }
}
