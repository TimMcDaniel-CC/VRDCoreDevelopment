using UnityEngine;

namespace Cochise.VRD
{
    public static class CameraExtensions
    {
        public static Vector3 GetFlatFacingVector(this Camera cam)
        {
            return new Vector3(0f, cam.transform.eulerAngles.y, 0f);
        }

        public static Quaternion GetFlatRotation(this Camera cam)
        {
            return Quaternion.Euler(cam.GetFlatFacingVector());
        }
    }
}
