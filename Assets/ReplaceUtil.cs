using System.Collections.Generic;
using UnityEngine.Playables;

namespace UnityEngine.Timeline
{
    public static class ReplaceUtil
    {

        public static void ReplaceAll(PlayableDirector timeline, AnimationClip clip, Dictionary<AnimationPlayableAsset, AnimationClip> map)
        {

            foreach (var track in timeline.playableAsset.outputs)
            {
                if (!(track.sourceObject is AnimationTrack))
                    continue;


                var animationTrack = track.sourceObject as AnimationTrack;
                if (animationTrack != null)
                {
                    ReplaceAnimationTrackClips(animationTrack, clip, map);
                }
            }
        }

        public static void RestoreAsset(Dictionary<AnimationPlayableAsset, AnimationClip> animationClipMap)
        {
            if (null == animationClipMap) return;

            foreach (var entry in animationClipMap)
            {
                entry.Key.clip = entry.Value;
            }
            animationClipMap.Clear();
        }

        private static void ReplaceAnimationTrackClips(AnimationTrack track, AnimationClip newClip, Dictionary<AnimationPlayableAsset, AnimationClip> map)
        {
            foreach (var clip in track.GetClips())
            {
                var animationPlayableAsset = (AnimationPlayableAsset)clip.asset;

                map[animationPlayableAsset] = animationPlayableAsset.clip;
                animationPlayableAsset.clip = newClip;

            }
        }
        public static GameObject GetGo(Object obj)
        {
            if (null == obj) return null;
            if (obj is GameObject) return (GameObject)obj;
            if (obj is Component) return ((Component)obj).gameObject;
            return null;
        }
    }

}
