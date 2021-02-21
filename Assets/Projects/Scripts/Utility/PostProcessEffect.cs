using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NFS.Car.Movements;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessEffect : MonoBehaviour
{
    PostProcessVolume volume;
    ChromaticAberration chromatic;
    LensDistortion lensDistortion;
    GearEngine gearEngine;
    void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        gearEngine = GetComponentInParent<GearEngine>();
        volume.profile.TryGetSettings<LensDistortion>(out lensDistortion);
        volume.profile.TryGetSettings<ChromaticAberration>(out chromatic);
    }

    void Update()
    {
        float t = gearEngine.GetCurrentSpeed() / gearEngine.GetMaxSpeed();
        Debug.Log(t);
        chromatic.intensity.value = Mathf.Lerp(0, 1f, t);
        lensDistortion.intensity.value = Mathf.Lerp(0, -80, t);
    }
}
