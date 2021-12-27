using UnityEngine;

public class RaycastService
{
    /// <summary>
    /// Check if theres another object of given type in the given direction
    /// </summary>
    /// <typeparam name="T">Object Type</typeparam>
    /// <param name="raycastOriginPoint">Start point to create raycast</param>
    /// <param name="direction">Direction to draw raycast</param>
    /// <returns></returns>
    public static bool IsThereAnotherObjectOfTypeInDirection<T>(Transform raycastOriginPoint, Vector2 direction)
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(raycastOriginPoint.position, direction);

        if (!hit)
            return false;

        T hitObject = hit.transform.gameObject.GetComponent<T>();
        if (hitObject != null)
            return true;

        return false;
    }
}