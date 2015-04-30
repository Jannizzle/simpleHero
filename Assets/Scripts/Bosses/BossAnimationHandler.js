#pragma strict

public var parent : GameObject;


function Start () {

}

function Update () {

}

function setBladeTransState(){
parent.SendMessage ("setBossBlade", false);
}

function setArmTransState(){
parent.SendMessage ("setBossArm", false);
}

function setSweetTransState(){
parent.SendMessage ("setBossSweet", false);
}

function contBehave(){
parent.SendMessage("goOn");
}