using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Get inputs from new Input Manager
public class PlayerInputs : MonoBehaviour
{
   private InputMaster _controls;

   public bool jump { get; set; } = false;
   public bool crouch { get; private set; } = false;
   public bool sprint { get; private set; } = false;
   public Vector2 moveDirection { get; private set; }
   private void Awake()
   {
      _controls = new InputMaster();
      _controls.Player.Movement.performed += ctx => moveDirection = ctx.ReadValue<Vector2>();
      _controls.Player.Jump.performed += _ => jump = true;
      _controls.Player.Sprint.performed += _ => sprint = !sprint;
      _controls.Player.Crouch.performed += _ => crouch = !crouch;
   }

   private void OnEnable()
   {
      _controls.Enable();
   }

   private void OnDisable()
   {
      _controls.Disable();
   }

}
