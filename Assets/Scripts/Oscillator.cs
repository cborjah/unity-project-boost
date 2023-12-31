using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    // [SerializeField] [Range(0,1)] float movementFactor;
    float movementFactor;
    // [SerializeField] float period = 4f;
    float period = 4f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position; // Current of position of object.
    }

    // Update is called once per frame
    void Update()
    {
        // When comparing two floating points, the chance of it being 0 (in this case) is not absolute.
        // Two floats can vary by a tiny amount. It's unpredictable to use == with floats.
        //* Always specify the acceptable difference.
        //* The smallest float is Mathf.Epsilon. Always compare to this rather than zero.
        // if (period == 0f) { return; }
        if (period <= Mathf.Epsilon) { return; }

        float cycles = Time.time / period; // Continually grows over time.
        const float tau = Mathf.PI * 2; // Constant value of 6.283.
        float rawSinWave = Mathf.Sin(cycles * tau); // -1 to 1

        //* If a range of -1 to 1 is used, the starting point would be the midpoint.
        // rawSinWave + 1f gives you a range of 0 - 2. Divide by 2 to get 0 - 1.
        movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
