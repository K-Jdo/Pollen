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
        notUsed,    // 拠点使用不可
        click,      // ボタン選択
        bomb,       // 爆発の効果音
        charge,     // 武器補充
        damage,     // 花粉に当たった音
        attack,     // 網を振る音
        shoot,      // 武器を投げる
        clear,      // クリア判定
        defeat,     // 敗北判定
        end,        // ゲーム終了
        start       // ゲーム開始
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
