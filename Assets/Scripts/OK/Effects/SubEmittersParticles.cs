using System.Collections.Generic;
using UnityEngine;

public class SubEmittersParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _owner;
    [SerializeField] private List<ParticleSystem> _subEmitters;

    public void ChangeStartColor(Color color)
    {
        SetStartColor(_owner, color);
        
        foreach (var system in _subEmitters)
        {
            SetStartColor(system, color);
        }
    }

    private void SetStartColor(ParticleSystem particles, Color color)
    {
        var particlesMain = particles.main;
        particlesMain.startColor = color;
    }
}