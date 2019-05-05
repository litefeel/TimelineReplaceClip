using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ReplaceTest : MonoBehaviour
{
    public AnimationClip clip;
    public PlayableDirector prefab;
    // Start is called before the first frame update
    void Start()
    {
        DoPlay();
    }

    private void DoPlay()
    {
        var director = GameObject.Instantiate(prefab);
        var map = new Dictionary<AnimationPlayableAsset, AnimationClip>();
        ReplaceUtil.ReplaceAll(director, clip, map);
        director.Play();
        ReplaceUtil.RestoreAsset(map);
        director.stopped += (obj) =>
        {
            GameObject.Destroy(obj.gameObject);
        };
    }
}
