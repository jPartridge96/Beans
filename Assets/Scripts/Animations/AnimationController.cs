using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public List<AnimationClip> animationClips;

    private Dictionary<string, int> animationIndex = new Dictionary<string, int>();

    private void Start()
    {
        // Populate the dictionary with animation clip names and their corresponding index
        for (int i = 0; i < animationClips.Count; i++)
        {
            animationIndex.Add(animationClips[i].name, i);
        }
    }

    private void Update()
    {
        // Call animation clips based on input
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayAnimation("Idle");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayAnimation("Walk");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayAnimation("Run");
        }
    }

    // Play an animation clip by name
    public void PlayAnimation(string name)
    {
        if (animationIndex.ContainsKey(name))
        {
            animator.Play(animationClips[animationIndex[name]].name);
        }
    }

    // Add an animation clip to the list
    public void AddAnimationClip(AnimationClip clip)
    {
        if (!animationClips.Contains(clip))
        {
            animationClips.Add(clip);
            animationIndex.Add(clip.name, animationClips.Count - 1);
        }
    }

    // Remove an animation clip from the list
    public void RemoveAnimationClip(AnimationClip clip)
    {
        if (animationClips.Contains(clip))
        {
            int index = animationClips.IndexOf(clip);
            animationClips.RemoveAt(index);
            animationIndex.Remove(clip.name);
            // Rebuild the index dictionary
            for (int i = index; i < animationClips.Count; i++)
            {
                animationIndex[animationClips[i].name] = i;
            }
        }
    }
}
