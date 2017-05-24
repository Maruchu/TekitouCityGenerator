//	=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//
//	常に任意の回転を加えるスクリプト
//
//	Copyright(C)2015 Maruchu
//	http://maruchu.nobody.jp/
//
//	=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
using UnityEngine;
using System.Collections;




///	<summary>
///	常に任意の回転を加えるクラス
///	</summary>
public class AddRotation : MonoBehaviour {



	public		Vector3			rotationSpeedPerSecond	= new Vector3(   0,  60,   0);			//毎秒かかる回転の量(360度で一回転)
	private		Vector3			rotationNow				= Vector3.zero;							//現在の回転の値



	///	<summary>
	///	初期化時
	///	</summary>
	private	void Start() {
		//角度を取得
		rotationNow		= transform.eulerAngles;
	}

	///	<summary>
	///	毎フレーム呼び出される関数
	///	</summary>
	private	void Update() {
		//経過時間分の回転を加える
		rotationNow		+= (rotationSpeedPerSecond	*Time.deltaTime);
		//Transformを更新して角度を反映
		transform.rotation		= Quaternion.Euler( rotationNow);
	}

}
