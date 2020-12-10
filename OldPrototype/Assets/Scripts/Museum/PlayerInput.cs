using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool ForwardInput { get; set; }
    public bool BackInput { get; set; }
    public bool LeftInput { get; set; }
    public bool RightInput { get; set; }
    public bool InteractionInput { get; set; }
    public bool ExitInput { get; set; }
    public bool UpArrow { get; set; }
    public bool DownArrow { get; set; }
    public bool RightArrow { get; set; }
    public bool LeftArrow { get; set; }
    public bool PlusInput { get; set; }
    public bool MinusInput { get; set; }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) ForwardInput = true;
        else ForwardInput = false;
        if (Input.GetKey(KeyCode.S)) BackInput = true;
        else BackInput = false;
        if (Input.GetKey(KeyCode.A)) LeftInput = true;
        else LeftInput = false;
        if (Input.GetKey(KeyCode.D)) RightInput = true;
        else RightInput = false;
        if (Input.GetKey(KeyCode.E)) InteractionInput = true;
        else InteractionInput = false;
        if (Input.GetKey(KeyCode.Escape)) ExitInput = true;
        else ExitInput = false;
        if (Input.GetKey(KeyCode.UpArrow)) UpArrow = true;
        else UpArrow = false;
        if (Input.GetKey(KeyCode.DownArrow)) DownArrow = true;
        else DownArrow = false;
        if (Input.GetKey(KeyCode.RightArrow)) RightArrow = true;
        else RightArrow = false;
        if (Input.GetKey(KeyCode.LeftArrow)) LeftArrow = true;
        else LeftArrow = false;
        if (Input.GetKey(KeyCode.KeypadPlus)) PlusInput = true;
        else PlusInput = false;
        if (Input.GetKey(KeyCode.KeypadMinus)) MinusInput = true;
        else MinusInput = false;
    }
}
