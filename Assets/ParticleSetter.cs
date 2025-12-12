using UnityEngine;

public class ParticleSetter : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    void Awake()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();

        if (_particleSystem != null)
        {
            Debug.Log("particle system found = " + _particleSystem);
        }
        else
        {
            _particleSystem = GetComponentInChildren<ParticleSystem>();
        }
    }

    public void ParticlesOn()
    {
        _particleSystem.Play();
    }

    public void ParticlesOff()
    {
        _particleSystem.Stop();
        Debug.Log("particles stopped");
    }
}
