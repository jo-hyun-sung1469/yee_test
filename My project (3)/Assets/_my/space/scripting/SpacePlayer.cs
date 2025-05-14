using UnityEngine;
using UnityEngine.InputSystem;

public class SpacePlayer : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    public float moveSpeed = 6;
    [SerializeField] GameObject spawnPosition;

    [SerializeField] float leftLimit = -5;
    [SerializeField] float rightLimit = 5;

    Animator animator;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform.position = spawnPosition.transform.position;
    }

    // Update is called once per frame
    void Update()//프레임에 따라 호출되는 빈도수가 다름
    {
        
    }

    private void FixedUpdate()//이 함수는 기본 0.02초(50프레임)마다 1번씩 호출 단 이함수는 FPS와 같은 급작스러운 상황에 반응할려면 호출할때 필요한 프레임의 수가 적어야 하므로 이 함수를 이용하는것은 적합하지 않음
    {
        Vector2 playerPosition = transform.position;

        if (playerPosition.x > rightLimit)
        {
            playerPosition.x = rightLimit;
        }
        else if (playerPosition.x < leftLimit)
        {
            playerPosition.x = leftLimit;
        }

            transform.position = playerPosition;
    }

    public void OnMove(InputValue inputValue)
    {
        float input = inputValue.Get<Vector2>().x;

        //float a = Input.GetAxis("Horizontal");

        //Debug.Log("key : " + input);

        if(input > 0)
        {
            animator.SetBool("right",true);
            animator.SetBool("left", false);
        }
        else if(input < 0)
        {
            animator.SetBool("left",true);
            animator.SetBool("right", false);
        }

        if (Mathf.Abs(input) > 0)
        {
            rigidbody2D.linearVelocity = input * Vector2.right * moveSpeed;
        }
        else
        {
            rigidbody2D.linearVelocity = Vector2.zero;
            animator.SetBool("left", false);
            animator.SetBool("right", false);
        }

    }
}
// Mathf클래스는 수학과 관련된 내용이 담긴 클래스
// Abs메소드(함수)는 절대값을 반환하는 메소드(함수)
// private 변수들을 Inspector에 표시하는 방법:[SerializeField] 라는 것 적기
