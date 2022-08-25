using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [Header("スコア")]
    [SerializeField]
    public int Score;

    [Header("最大HP")]
    [SerializeField]
    public int Player_HPMax;

    [Header("現在のHP")]
    [SerializeField]
    public int Player_HP;

    [Header("ジャンプする高さ")]
    [SerializeField]
    float Jump_Max;

    [Header("ジャンプするスピード")]
    [SerializeField]
    float Jump_Speed;

    [Header("重力")]
    [SerializeField]
    float GravityScale;

    [Header("被弾後の無敵時間")]
    [SerializeField]
    float Muteki_Time_Max;

    [Header("無敵時の点滅速度")]
    [SerializeField]
    float Sprite_Speed;

    [Header("参照用")]
    [SerializeField]
    public bool Frieze;
    public Text Score_Text;
    public bool Muteking;
    public bool Player_Clear, Player_Deth;

    [System.NonSerialized]
    float Vertical;
    float Jump_Keep;
    float Gravity_P;
    float Damage_Time;
    float Muteki_Time;
    SpriteRenderer Sprite_R;

    [System.NonSerialized]
    public bool Not_Gravity, IsGround, Jumoing, Player_Dash, Damageing;
    string Sprite_UD;

    Rigidbody2D Rb;

    private Vector2 Size;//大きさを保存

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Gravity_P = GravityScale;//重力を取得

        Size = transform.localScale;//大きさを保存

        //ステータスを反映
        Player_HP = Player_HPMax;
        Muteki_Time = Muteki_Time_Max;

        Sprite_R = GetComponent<SpriteRenderer>();

        Player_Clear = Player_Dash = false;
    }

    void Update()
    {
        if (Frieze == false)
        {
            //入力受付
            Vertical = Input.GetAxis("Vertical");
        }
        else
        {
            Rb.velocity = new Vector2(0, 0);
        }

        //接地している時
        if (IsGround == true)
        {
            //重力の影響を無くす(下に引っ張らないようにする)
            Not_Gravity = true;

            //ジャンプ入力
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //飛べる高さを計算(今の高さからJump_Keepまで飛べる)
                Jump_Keep = transform.position.y + Jump_Max;

                Jumoing = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Jumoing = false;
            Not_Gravity = false;
        }


        if (Player_HP <= 0)
        {
            Player_Deth = true;
        }
    }

    private void FixedUpdate()
    {
        if (Frieze == false)
        {
            Gravity();
            Jump();
        }

        GameOver();
        Muteki();
        DamageMove();
    }

    void Jump()
    {
        //ジャンプボタンが押された&高さが飛べる限界に達していないとき
        if (Jumoing == true && transform.position.y < Jump_Keep)
        {
            //飛び続ける
            Rb.velocity = new Vector2(Rb.velocity.x, Jump_Speed);
        }
        else
        {
            Jumoing = false;
            Not_Gravity = false;
        }
    }

    void Gravity()
    {
        if (Not_Gravity == false)
        {
            //現在の高さから重力加速度を差し引いた分の座標に置き換える
            float Gravity_total = transform.position.y - Gravity_P;

            Rb.velocity = new Vector2(Rb.velocity.x, Gravity_total);
        }
        else
        {
            Rb.velocity = new Vector2(Rb.velocity.x, 0);
        }
    }

    public void AddScore()
    {
        Score += 1;

        Score_Text.text = "Score:" + Score + "/10";
    }

    //被弾した時の処理
    public void DamageMove()
    {
        //被弾の処理
        if (Damageing == true)
        {
            //無敵をオンにする
            Muteking = true;

            if (Damage_Time > 0)
            {
                //プレイヤーを停止
                Frieze = true;

                Damage_Time -= Time.deltaTime;
            }
            else
            {
                //フラグ解除
                Frieze = false;
                Damageing = false;
            }
        }
    }

    //無敵時の処理
    void Muteki()
    {
        if (Muteking == true)
        {
            Muteki_Time -= Time.deltaTime;

            //点滅処理
            if (Sprite_R.color.a >= 1)
            {
                Sprite_UD = "Down";
            }
            else if (Sprite_R.color.a <= 0)
            {
                Sprite_UD = "Up";
            }

            if (Sprite_UD == "Down")
            {
                float Alpha = Sprite_R.color.a - Sprite_Speed;
                Sprite_R.color = new Color(1f, 1f, 1f, Alpha);
            }
            else if (Sprite_UD == "Up")
            {
                float Alpha = Sprite_R.color.a + Sprite_Speed;
                Sprite_R.color = new Color(1f, 1f, 1f, Alpha);
            }
        }
        if (Muteki_Time <= 0)
        {
            //フラグリセット
            Muteking = false;
            Muteking = false;
            Muteki_Time = Muteki_Time_Max;
            Sprite_R.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    void GameOver()
    {
        if (Player_Clear == true)
        {
            //動きを止める
            Frieze = true;
        }
        else if (Player_Deth == true)
        {
            //動きを止める
            Frieze = true;
        }
    }
}