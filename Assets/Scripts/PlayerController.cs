using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _animatorBag;
    [SerializeField] private GameObject sickle;
    

    



    [SerializeField] private float _moveSpeed;

   
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed); // Управление через джойстик

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animator.SetBool("isRunning", true);
            _animatorBag.enabled = true;
            

        }
        else
        {
            _animator.SetBool("isRunning", false);
            _animatorBag.enabled = false;
            
        }
            

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))  // Включение серпа
        {
            sickle.SetActive(true);
            
        }
        else
            sickle.SetActive(false);

       
    }


   public void Attack() //Включение анимации атаки
    {
        _animator.SetTrigger("Attack");
        

    }


}
