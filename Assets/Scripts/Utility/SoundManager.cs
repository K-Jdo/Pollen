// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 音制御
public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    [SerializeField] private AudioClip[] clips = default;
    AudioSource source;

    public enum SoundName
    {
        bomb,           // 爆弾の効果音
        charge,         // 武器補充
        clear,          // クリア判定
        click,          // ボタン選択
        damage,         // 花粉に当たった音
        defeat,         // 敗北判定
        end,            // ゲーム終了
        area_not_used,  // 拠点使用不可
        get_pollen,     // 網を振った音
        shot,           // 爆弾を投げる音
        start           // ゲーム開始
    }

    protected override void Awake()
    {
        base.Awake();

        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// 音を鳴らす
    /// </summary>
    /// <param name="name"></param>
    public void PlaySound(SoundName name)
    {
        source.PlayOneShot(clips[(int)name]);
    }
}
