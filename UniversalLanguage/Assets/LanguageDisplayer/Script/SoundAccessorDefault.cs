﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundAccessorDefault : SoundAccessor
{
    public AudioClip m_noAudio;
    public List<AccessibleSound> m_sounds= new List<AccessibleSound>();

    [System.Serializable]
    public struct AccessibleSound {
        public string id;
        public AudioClip audio;

    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override AudioClip GetSound(string soundName)
    {
        AudioClip result = m_noAudio;
        AudioClip [] results = m_sounds.Where(k => k.id == soundName).Select(k=>k.audio).ToArray();
        if (results.Length > 0) {
            result = results[0];
        }
        return result;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}


public abstract class SoundAccessor : MonoBehaviour
{
    public abstract AudioClip GetSound(string soundName);
}
