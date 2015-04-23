//	=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//
//	適当な街並みを作成するスクリプト
//
//	Copyright(C)2015 Maruchu
//	http://maruchu.nobody.jp/
//
//	=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
using UnityEngine;
using System.Collections;




/*
	<summary>
	適当な街並みを作成するクラス
	</summary>
 */
public class TekitouCityGenerator : MonoBehaviour {



	//作成するGameObject
	public		GameObject		fieldObject				= null;									//フィールドのオブジェクト
	public		GameObject[]	buildingObject			= new GameObject[ 1];					//ビルのオブジェクト(複数指定したらランダムに選ばれる)


	//配置するビルの情報
	public		int				building_Count			= 3000;									//ビルを作成する数

	public		Vector3			building_Pos_Min		= new Vector3( -100,    0, -100);		//ビルを作成する位置 最小
	public		Vector3			building_Pos_Max		= new Vector3(  100,    0,  100);		//ビルを作成する位置 最大

	public		Vector3			building_Rot_Min		= new Vector3(    0, -180,    0);		//ビルを作成する角度 最小(-360～360)
	public		Vector3			building_Rot_Max		= new Vector3(    0,  180,    0);		//ビルを作成する角度 最大(-360～360)

	public		Vector3			building_Scale_Min		= new Vector3(    1,    5,    1);		//ビルを作成するスケール 最小
	public		Vector3			building_Scale_Max		= new Vector3(    2,   10,    2);		//ビルを作成するスケール 最大



	/*
		<summary>
		初期化時
		</summary>
	 */
	private	void Start() {
		//フィールド作成
		CreateObject_Field();

		//ビル作成
		int	i;
		for( i=0; i<building_Count; i++) {
			//指定された個数のビルを作成
			CreateObject_Building();
		}
	}



	/*
		<summary>
		フィールドを作成
		</summary>
	 */
	private	void CreateObject_Field() {
		//無ければ無視
		if( null==fieldObject) {
			//無視
			return;
		}

		//フィールドを作成
		GameObject	temp			= Instantiate( fieldObject)		as GameObject;		//オリジナルのデータそのままで作成
		//自分の子供にする
		temp.transform.parent		= transform;
	}

	/*
		<summary>
		ビルを作成
		</summary>
	 */
	private	void CreateObject_Building() {
		//無ければ無視
		if( (null==buildingObject) || (buildingObject.Length <= 0)) {
			//無視
			return;
		}

		//作成するオブジェクトの番号をランダムに選ぶ
		int	index	= Random.Range( 0, buildingObject.Length);
		//配列の中身はnull？
		if( null==buildingObject[ index]) {
			//無視
			return;
		}

		//作成する場所
		Vector3	pos		= new Vector3(
							Random.Range( building_Pos_Min.x, building_Pos_Max.x),
							Random.Range( building_Pos_Min.y, building_Pos_Max.y),
							Random.Range( building_Pos_Min.z, building_Pos_Max.z));
		//作成する時の角度(0～360度で指定)
		Vector3	rot		= new Vector3(
							Random.Range( building_Rot_Min.x, building_Rot_Max.x),
							Random.Range( building_Rot_Min.y, building_Rot_Max.y),
							Random.Range( building_Rot_Min.z, building_Rot_Max.z));
		//ローカルスケール
		Vector3	scale	= new Vector3(
							Random.Range( building_Scale_Min.x, building_Scale_Max.x),
							Random.Range( building_Scale_Min.y, building_Scale_Max.y),
							Random.Range( building_Scale_Min.z, building_Scale_Max.z));

		//ビルを作成
		GameObject	temp			= Instantiate( buildingObject[ index], pos, Quaternion.Euler( rot))		as GameObject;
		//スケールを入れる
		temp.transform.localScale	= scale;
		//自分の子供にする
		temp.transform.parent		= transform;
	}

}
