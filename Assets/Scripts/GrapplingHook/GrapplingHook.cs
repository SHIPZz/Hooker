using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private HookRaycast _hookRaycast;
    [SerializeField] private HookRenderer _hookRenderer;
    [SerializeField] private Player _player;
    [SerializeField] private float _springJointDamper = 10;
    [SerializeField] private float _jointSpring = 5;

    private SpringJoint _springJoint;

    public void CreateHook()
    {
        RaycastHit hit = _hookRaycast.Raycast();

        if(hit.collider != null)
        {
            Vector3 grapplePoint = hit.point;
            _hookRenderer.DrawRope(grapplePoint);

            _springJoint = _player.gameObject.AddComponent<SpringJoint>();
            _springJoint.autoConfigureConnectedAnchor = false;
            _springJoint.connectedAnchor = grapplePoint;

            float grappleDistance = Vector3.Distance(transform.position, grapplePoint);

            _springJoint.maxDistance = grappleDistance;
            _springJoint.minDistance = grappleDistance;

            _springJoint.damper = _springJointDamper;
            _springJoint.spring = _jointSpring;
        }

    }

    public void DisableHook()
    {
        Destroy(_springJoint);
        _hookRenderer.Disable();
    }
}
