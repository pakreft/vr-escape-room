using System;
using Autohand;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Input;

namespace LNPEscapeRoom {

    [HelpURL("https://app.gitbook.com/s/5zKO0EvOjzUDeT2aiFk3/auto-hand/controller-input")]
    public class OpenXRHandControllerLink : HandControllerLink {
        public InputActionProperty grabAxis;
        public InputActionProperty squeezeAxis;
        public InputActionProperty grabAction;
        public InputActionProperty releaseAction;
        public InputActionProperty squeezeAction;
        public InputActionProperty stopSqueezeAction;
        public InputActionProperty hapticAction;
        public InputActionProperty triggerPressedAction;
        public InputActionProperty testAction;


        private bool squeezing;
        private bool grabbing;
        private void Start() {
            if(hand.left)
                handLeft = this;
            else
                handRight = this;
        }

        [SerializeField] UnityEvent OnReceiveTriggerInputAction = new UnityEvent();

        public event EventHandler OnTriggerPressed;
        public event EventHandler OnTest;

        public static OpenXRHandControllerLink Instance { get; private set; }

        private void Awake() {
            Instance = this;
        }

        public void OnEnable(){
            if (grabAction == squeezeAction){
                Debug.LogError("AUTOHAND: You are using the same button for grab and squeeze on HAND CONTROLLER LINK, this will create conflict or errors", this);
            }

            if(grabAxis.action != null) grabAxis.action.Enable();
            if(squeezeAxis.action != null) squeezeAxis.action.Enable();
            if(hapticAction.action != null) hapticAction.action.Enable();
            if(grabAction.action != null) grabAction.action.performed += Grab;
            if (grabAction.action != null) grabAction.action.Enable();
            if (grabAction.action != null) grabAction.action.performed += Grab;
            if (releaseAction.action != null) releaseAction.action.Enable();
            if (releaseAction.action != null) releaseAction.action.performed += Release;
            if (squeezeAction.action != null) squeezeAction.action.Enable();
            if (squeezeAction.action != null) squeezeAction.action.performed += Squeeze;
            if (stopSqueezeAction.action != null) stopSqueezeAction.action.Enable();
            if (stopSqueezeAction.action != null) stopSqueezeAction.action.performed += StopSqueeze;
            if (triggerPressedAction.action != null) triggerPressedAction.action.Enable();
            if (triggerPressedAction.action != null) triggerPressedAction.action.performed += TriggerPressed;
            if (testAction.action != null) testAction.action.Enable();
            if (testAction.action != null) testAction.action.performed += Test;

        }

        

        private void OnDisable(){

            if (grabAction.action != null) grabAction.action.performed -= Grab;
            if (releaseAction.action != null) releaseAction.action.performed -= Release;
            if (squeezeAction.action != null) squeezeAction.action.performed -= Squeeze;
            if (stopSqueezeAction.action != null) stopSqueezeAction.action.performed -= StopSqueeze;
        }


        private void Update() {
            hand.SetGrip(grabAxis.action.ReadValue<float>(), squeezeAxis.action.ReadValue<float>());
        }

        private void Grab(InputAction.CallbackContext grab){
            if (!grabbing){
                hand.Grab();
                grabbing = true;
            }
        }
        
        private void Release(InputAction.CallbackContext grab){
            if (grabbing){
                hand.Release();
                grabbing = false;
            }
        }

        private void Squeeze(InputAction.CallbackContext grab){
            if (!squeezing){
                hand.Squeeze();
                squeezing = true;
            }
        }
        
        private void StopSqueeze(InputAction.CallbackContext grab){
            if (squeezing){
                hand.Unsqueeze();
                squeezing = false;
            }

        }

        private void TriggerPressed(InputAction.CallbackContext obj) {
            OnTriggerPressed?.Invoke(this, EventArgs.Empty);
            Debug.Log("Trigger");
            OnReceiveTriggerInputAction.Invoke();
        }

        private void Test(InputAction.CallbackContext obj) {
            OnTest?.Invoke(this, EventArgs.Empty);
        }

        public override void TryHapticImpulse(float duration, float amp, float freq = 10)
        {
            OpenXRInput.SendHapticImpulse(hapticAction.action, amp, duration, hand.left ? UnityEngine.InputSystem.XR.XRController.leftHand : UnityEngine.InputSystem.XR.XRController.rightHand);

            base.TryHapticImpulse(duration, amp, freq);
        }

    }
}
