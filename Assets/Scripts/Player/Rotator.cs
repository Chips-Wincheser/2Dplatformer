using UnityEngine;

public class Rotator : MonoBehaviour
{
    public void Rotate(float direction)
    {
        if (direction < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (direction > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
