using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
	//Variaveis publicas
	public float forcaPulo;
	public float velocidadeMax;
	public int jump;
	public int vida;
	public float xp;

    // Comeco do programa (executado apenas uma vez)
    void Start()
    {
    }

    // Update frame (a cada frame vai ser executado novamente)
    void Update()
    {
    	float movimento = Input.GetAxis("Horizontal");
    	Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
    	CharacterController controller = GetComponent<CharacterController>();
    	rigidbody.velocity = new Vector2(movimento*velocidadeMax, rigidbody.velocity.y);
    	//Girar o Sprite do personagem (frente/costa)
    	if (movimento < 0){
    		GetComponent<SpriteRenderer>().flipX = true;}
    	else if (movimento > 0){
    		GetComponent<SpriteRenderer>().flipX = false;}
    	//Ativar a animação de movimento caso esteja "andando". (animação=walk)
    	if (movimento > 0 || movimento < 0){
    		GetComponent<Animator>().SetBool("walk", true);}
    	else{
    		GetComponent<Animator>().SetBool("walk", false);}
    	//Quando o tecla espaço for precionado:
    	if (Input.GetKeyDown(KeyCode.Space)){
    		if (jump==1){
    			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forcaPulo));
    			GetComponent<Animator>().SetBool("jump", true);
    			jump=0;}}
    	//Quando a tecla R voltar:
    	if (Input.GetKeyUp(KeyCode.R)){
    		GetComponent<Animator>().SetBool("attack", false);}
    	//Quando a tecla R for precionado:
    	if (Input.GetKeyDown(KeyCode.R)){
    		GetComponent<Animator>().SetBool("attack", true);}
    	//Quando a tecla S for precionado:
    	if (Input.GetKeyDown(KeyCode.S)){
    		GetComponent<Animator>().SetBool("slide", true);}
    	//Quando a tecla S voltar:
    	if (Input.GetKeyUp(KeyCode.S)){
    		GetComponent<Animator>().SetBool("slide", false);}
    }


    //Quando o jogador colidir com algo:
    void OnCollisionEnter2D(Collision2D colission2d){
    	jump=1;
    }
   //Quando ele sair do colisão:	
   	void OnCollisionExit2D(Collision2D colission2d){
   		GetComponent<Animator>().SetBool("jump", false);}
   }