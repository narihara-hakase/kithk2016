#include <MsTimer2.h>
#include <SPI.h>
#include <Ethernet.h>
#include "ThingSpeak.h"

unsigned long SecletBase1 = 159403;
const char * SecletBase1_Key = "SQJBG2FRDCX3GBTC";
byte mac[] = { 0x90, 0xA2, 0xDA, 0x00, 0xE5, 0xF1 };
EthernetClient client;
char tmp;
int at_end=0;
int idx=0;
int tmp2;
boolean timeflag = false;
double s1_t=0;
double s2_t=0;
double s3_t=0;
int sence_cnt=0;
int time_cnt=0;

typedef struct {
  const int id=1; 
  int temp; 
  int water; 
  int dist; 
  boolean s1;
  boolean s2;
  boolean s3;
} Sen_dt;

Sen_dt sen;

void flag() {
  timeflag = true;        
}

void setup() {
  Serial.begin(115200);
  startEthernet();
  ThingSpeak.begin(client);
  Serial.print("st\n");
  pinMode(7,INPUT);
  pinMode(8,INPUT);
  pinMode(9,INPUT);
  
  MsTimer2::set(1000, flag);      // 1秒ごとにtimeflag関数を呼び出す設定
  MsTimer2::start();              // タイマー割り込み開始

}

void loop() {
/*
  for(;;){
    tmp = Serial.read();
    if(tmp != -1){
      st += tmp;
      if(tmp == '\n')break;
    }
  }
  Serial.print(st);
  st = "";*/
    if(timeflag == true){          
      sen.s1=(digitalRead(7)==0); //(ON=0)
      sen.s2=(digitalRead(8)==0); 
      sen.s3=(digitalRead(9)==0); 
      sen.temp = map((s1_t/sence_cnt), 0, 1023, 0,5000 );//電圧変換
      sen.temp = map(sen.temp,300+950,1600+950,-30,100);
      sen.water=(s2_t/sence_cnt);
      sen.dist=(s3_t/sence_cnt);
    
//      Serial.print("sw1=");  
//      Serial.println(sen.s1);
//      Serial.print("sw2=");
//      Serial.println(sen.s2);
//      Serial.print("sw3=");
//      Serial.println(sen.s3);
//      Serial.print("temp=[C]");
//      Serial.println(sen.temp);
//      Serial.print("water=");
//      Serial.println(sen.water);
//      Serial.print("dist=");
//      Serial.println(sen.dist);
//      Serial.println(""); 
      s1_t=0;
      s2_t=0;
      s3_t=0;
      sence_cnt=0;
      timeflag = false;
      
      time_cnt++;
    }
    
    if(time_cnt == 16){
      dataPush();
    }
    
    s1_t += analogRead(A1);
   // Serial.println(s1_t);    
    s2_t += analogRead(A2);
    s3_t += analogRead(A3);
    sence_cnt++;
}

void dataPush()
{
  int flagCount = 3 - (sen.s1 + sen.s2 + sen.s3);
  Serial.println(flagCount);
  ThingSpeak.writeField(SecletBase1, 1, sen.temp, SecletBase1_Key);  // 温度
  ThingSpeak.writeField(SecletBase1, 2, sen.water, SecletBase1_Key);  // 土壌
  ThingSpeak.writeField(SecletBase1, 3, 30, SecletBase1_Key);  // 距離
  ThingSpeak.writeField(SecletBase1, 4, flagCount, SecletBase1_Key);  // スイッチ
  time_cnt = 0;
  Serial.print("push!");
}

void startEthernet()
{
  client.stop();
  Serial.println("Connecting Arduino to network...");
  delay(1000);
  
  // Connect to network amd obtain an IP address using DHCP
  if (Ethernet.begin(mac) == 0)
  {
    Serial.println("DHCP Failed, reset Arduino to try again");
  }
  else
  {
    Serial.println("Arduino connected to network using DHCP");
  }
 
  delay(1000);
}
