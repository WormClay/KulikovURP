using UnityEngine;
using System;
using System.Collections;
[RequireComponent(typeof(Animator))]
public class IKControl : MonoBehaviour
{
    protected Animator animator;
    public bool ikActive = false;
    public Transform rightHandObj = null;
    public Transform leftHandObj = null;
    public Transform lookObj = null;
    public Transform head = null;
    private float distance = 2.0f;
    [SerializeField] private float currentHeadRotation;
    [SerializeField] private float headRotationSpeed = 0.1f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    //���������� ��� ������� IK
    void OnAnimatorIK()
    {
        if (animator)
        {
            //����, �� �������� IK, ������������� ������� � ��������
            if (ikActive)
            {
                // ������������� ���� ������� ��� ������
                if (lookObj != null)
                {
                    if (Vector3.Distance(head.position, lookObj.position) < distance)
                    {
                        animator.SetLookAtWeight(currentHeadRotation);
                        animator.SetLookAtPosition(lookObj.position);
                        currentHeadRotation += Time.deltaTime * headRotationSpeed;
                        if (currentHeadRotation > 1) currentHeadRotation = 1;
                    }
                    else
                    {
                        animator.SetLookAtWeight(currentHeadRotation);
                        animator.SetLookAtPosition(head.position + head.forward);
                        currentHeadRotation -= Time.deltaTime * headRotationSpeed;
                        if (currentHeadRotation < 0) currentHeadRotation = 0;
                    }
                }
                // ������������� ���� ��� ������ ���� � ���������� � � �������
                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                }
                // ������������� ���� ��� ����� ���� � ���������� � � �������
                if (leftHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
                }
            }
            // ���� IK ���������, ������ ������� � �������� ��� � ������ � ����������� ���������
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetLookAtWeight(0);
            }
        }
    }
}

