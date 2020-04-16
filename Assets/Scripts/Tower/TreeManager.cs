// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 杉の木の管理を行うクラス
public class TreeManager : SingletonMonoBehaviour<TreeManager>
{
    [SerializeField] private GameObject tree = default;
    [SerializeField] private GameObject tree_folder = default;
    // HPバーを表示させるためのオブジェクト
    [SerializeField] private Canvas canvas = default;
    [SerializeField] private Image hp = default;
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
        Vector3 image_pos = new Vector3(-355.0f, 630.0f, 0.0f); // hpバーの位置
        // 最初に杉を最大数出現
        for(int i = 0; i < MAX_TREE; i++)
        {
            // 木を出す位置に移動してからインスタンス
            transform.position = instance_point;
            GameObject obj = Instantiate(tree, transform);
            Tree_count++;

            // HPバーの準備
            Image image = Instantiate(hp);
            image.rectTransform.SetParent(canvas.transform);
            obj.GetComponent<PollenTree>().SetImage(image, image_pos);

            obj.transform.parent = tree_folder.transform;
            // 位置を更新
            instance_point.x += point_shift;
            image_pos.x += 35.0f;
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
