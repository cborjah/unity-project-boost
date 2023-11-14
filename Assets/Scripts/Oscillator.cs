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
