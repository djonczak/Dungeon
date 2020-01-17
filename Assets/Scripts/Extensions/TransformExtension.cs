using UnityEngine;

public static class TransformExtension
{
   public static Transform GetChildObject(Transform parentTransform, string childName)
   {
        foreach (Transform child in parentTransform)
        {
            if (child.name == childName)
            {
                return child;
            }
            else
            {
                return null;
            }
        }
        return null;
   }

    public static float DistanceBetween(Vector3 object1, Vector3 object2)
    {
        return Vector3.Distance(object1, object2);
    }
}
