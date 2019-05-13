// GENERATED AUTOMATICALLY FROM 'Assets/InputControls.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class InputControls : InputActionAssetReference
{
    public InputControls()
    {
    }
    public InputControls(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // QPortalUser
        m_QPortalUser = asset.GetActionMap("QPortalUser");
        m_QPortalUser_Movement = m_QPortalUser.GetAction("Movement");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        if (m_QPortalUserActionsCallbackInterface != null)
        {
            QPortalUser.SetCallbacks(null);
        }
        m_QPortalUser = null;
        m_QPortalUser_Movement = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        var QPortalUserCallbacks = m_QPortalUserActionsCallbackInterface;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
        QPortalUser.SetCallbacks(QPortalUserCallbacks);
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // QPortalUser
    private InputActionMap m_QPortalUser;
    private IQPortalUserActions m_QPortalUserActionsCallbackInterface;
    private InputAction m_QPortalUser_Movement;
    public struct QPortalUserActions
    {
        private InputControls m_Wrapper;
        public QPortalUserActions(InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement { get { return m_Wrapper.m_QPortalUser_Movement; } }
        public InputActionMap Get() { return m_Wrapper.m_QPortalUser; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(QPortalUserActions set) { return set.Get(); }
        public void SetCallbacks(IQPortalUserActions instance)
        {
            if (m_Wrapper.m_QPortalUserActionsCallbackInterface != null)
            {
                Movement.started -= m_Wrapper.m_QPortalUserActionsCallbackInterface.OnMovement;
                Movement.performed -= m_Wrapper.m_QPortalUserActionsCallbackInterface.OnMovement;
                Movement.cancelled -= m_Wrapper.m_QPortalUserActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_QPortalUserActionsCallbackInterface = instance;
            if (instance != null)
            {
                Movement.started += instance.OnMovement;
                Movement.performed += instance.OnMovement;
                Movement.cancelled += instance.OnMovement;
            }
        }
    }
    public QPortalUserActions @QPortalUser
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new QPortalUserActions(this);
        }
    }
}
public interface IQPortalUserActions
{
    void OnMovement(InputAction.CallbackContext context);
}
