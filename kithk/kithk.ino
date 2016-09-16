  char tmp;
  //char n_tmp='\0';
  String st ="";
  String cmd ="";
  String num ="";
  int at_end=0;
  int idx=0;
  int tmp2;
  
  typedef struct {
    int id; 
    int temp; 
    int water; 
    int dist; 
    boolean s1;
    boolean s2;
    boolean s3;
} Sen_dt;
  Sen_dt sen;
  
void setup() {
  Serial.begin(115200);
  Serial.print("st\n");
  pinMode(7,INPUT);
  pinMode(8,INPUT);
  pinMode(9,INPUT);

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
  
  sen.s1=(digitalRead(7)==0); //(ON=0)
  sen.s2=(digitalRead(8)==0); 
  sen.s3=(digitalRead(9)==0); 
  sen.temp =analogRead(A1);
  sen.water=analogRead(A2);
  sen.dist=analogRead(A3);
  
  Serial.print("sw1=");  
  Serial.println(sen.s1);
  Serial.print("sw2=");
  Serial.println(sen.s2);
  Serial.print("sw3=");
  Serial.println(sen.s3);
  Serial.print("temp=");
  Serial.println(sen.temp);
  Serial.print("water=");
  Serial.println(sen.water);
  Serial.print("dist=");
  Serial.println(sen.dist);
  Serial.println(""); 
  delay(1000);
}
