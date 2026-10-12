
using UnityEngine;

public class Recoil : MonoBehaviour
{
    // ==============================
    // 反動の設定
    // ==============================

    // 銃が撃った瞬間に後ろへ下がる距離
    // 数値を大きくすると、銃が大きく後ろへ動く
    public float recoilPosition = 0.08f;

    // 銃口が上を向く回転の強さ
    // 数値を大きくすると、銃が撃ったときに上へ跳ねる
    public float recoilRotation = 8f;

    // 銃が元の位置・角度に戻る速さ
    // 数値を大きくすると、元に戻るのが速くなる
    public float returnSpeed = 12f;


    // ==============================
    // 銃の初期状態を保存する変数
    // ==============================

    // ゲーム開始時の銃の位置を保存する
    // localPosition は親オブジェクトから見た位置
    private Vector3 initialPosition;

    // ゲーム開始時の銃の回転を保存する
    private Quaternion initialRotation;


    // ==============================
    // 反動の位置・回転を管理する変数
    // ==============================

    // 現在、銃に適用している位置の反動
    private Vector3 currentPosition;

    // 銃をどこまで動かしたいかを表す目標位置
    private Vector3 targetPosition;

    // 現在、銃に適用している回転の反動
    private Vector3 currentRotation;

    // 銃をどの角度まで回転させたいかを表す目標角度
    private Vector3 targetRotation;


    // ==============================
    // ゲーム開始時に1回だけ実行する処理
    // ==============================

    void Awake()
    {
        // 銃の現在位置を保存する
        // あとで反動を加えた位置から元に戻すために使う
        initialPosition = transform.localPosition;

        // 銃の現在の回転を保存する
        // 反動が終わったあとに元の角度へ戻すために使う
        initialRotation = transform.localRotation;
    }


    // ==============================
    // 毎フレーム実行する処理
    // ==============================

    void Update()
    {
        // 目標位置を少しずつゼロに近づける
        // ゼロになると、位置の反動がなくなる
        targetPosition = Vector3.Lerp(
            targetPosition,
            Vector3.zero,
            returnSpeed * Time.deltaTime
        );

        // 現在の反動位置を目標位置に近づける
        // 急に動かず、なめらかに移動するための処理
        currentPosition = Vector3.Lerp(
            currentPosition,
            targetPosition,
            returnSpeed * Time.deltaTime
        );

        // 保存しておいた初期位置に反動分の移動を足す
        // これによって銃が後ろへ動いたり元に戻ったりする
        transform.localPosition =
            initialPosition + currentPosition;


        // 目標の回転角度を少しずつゼロに近づける
        // ゼロに戻ることで、銃の回転の反動がなくなる
        targetRotation = Vector3.Lerp(
            targetRotation,
            Vector3.zero,
            returnSpeed * Time.deltaTime
        );

        // 現在の回転を目標の回転に近づける
        // 銃口が跳ね上がったあと、なめらかに戻る
        currentRotation = Vector3.Lerp(
            currentRotation,
            targetRotation,
            returnSpeed * Time.deltaTime
        );

        // 初期回転に反動の回転を加える
        // Quaternion.Euler で角度を回転情報に変換する
        transform.localRotation =
            initialRotation * Quaternion.Euler(currentRotation);
    }


    // ==============================
    // 銃を撃ったときに呼び出す処理
    // PlayerShoot.cs から実行する
    // ==============================

    public void Fire()
    {
        // Z方向の反動をマイナスする
        // 銃のローカルZ軸が前を向いている場合、
        // 銃が後ろへ下がる動きになる
        targetPosition.z -= recoilPosition;

        // X方向の回転をマイナスする
        // 銃口が上を向くように回転させる
        targetRotation.x -= recoilRotation;
    }
}
