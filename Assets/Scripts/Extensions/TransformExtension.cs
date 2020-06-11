using UnityEngine;

public static class TransformExtension
{
   public static GameObject GetChildObject(GameObject parentTransform, string childName)
   {
        if (null == parentTransform)
            return null;

        foreach (Transform child in parentTransform.transform)
        {
            if (null == child)
                continue;

            if (child.name == childName)
            {
                return child.gameObject;
            }
            else
            {
                GetChildObject(child.gameObject, childName);
            }
        }
        return null;
    }

    public static float DistanceBetween(Vector3 object1, Vector3 object2)
    {
        return Vector3.Distance(object1, object2);
    }
}
