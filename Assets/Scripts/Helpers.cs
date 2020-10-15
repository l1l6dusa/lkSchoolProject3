using UnityEngine;



public static class Helpers
{
    public static bool Vector2InBounds(Vector2 a, Vector2 b, Vector2 bounds)
    {
        
        if (Mathf.Abs(a.x - b.x) > Mathf.Abs(bounds.x))
        {
            return true;
        }
        else if(Mathf.Abs(a.y - b.y) > Mathf.Abs(bounds.y))
        {
            return true;
        }
        
        return false;
    } 
}
