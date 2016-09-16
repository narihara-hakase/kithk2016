#include <MsTimer2.h>
char tmp;
int at_end=0;
int idx=0;
int tmp2;

boolean timeflag = false;
double s1_t=0;
double s2_t=0;
double s3_t=0;
int sence_cnt=0;

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
    
    Serial.print("sw1=");  
    Serial.println(sen.s1);
    Serial.print("sw2=");
    Serial.println(sen.s2);
    Serial.print("sw3=");
    Serial.println(sen.s3);
    Serial.print("temp=[C]");
    Serial.println(sen.temp);
    Serial.print("water=");
    Serial.println(sen.water);
    Serial.print("dist=");
    Serial.println(sen.dist);
    Serial.println(""); 
    s1_t=0;
    s2_t=0;
    s3_t=0;
    sence_cnt=0;
    timeflag = false;
  }
    s1_t += analogRead(A1);
   // Serial.println(s1_t);    
    s2_t += analogRead(A2);
    s3_t += analogRead(A3);
    sence_cnt++;
  
}
