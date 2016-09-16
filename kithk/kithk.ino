  char tmp;
  //char n_tmp='\0';
  String st ="";
  String cmd ="";
  String num ="";
  int at_end=0;
  int idx=0;
  int tmp2;
void setup() {
  Serial.begin(115200);
  Serial.print("st\n");

}

void loop() {

  for(;;){
    tmp = Serial.read();
    if(tmp != -1){
      st += tmp;
      if(tmp == '\n')break;
    }
  }
  Serial.print(st);
  
  idx = 0;
  for(;;){
    idx = st.indexOf("=",idx);
    if(idx==-1)break;
    cmd= st.substring(idx-2,idx);
    num= st.substring(idx+1,st.indexOf(":",idx));
    Serial.print("cmd="+cmd+" num="+num+" " );
    cmd="";
    num="";
    idx +=1;
  }
  st = "";
  
  
}
