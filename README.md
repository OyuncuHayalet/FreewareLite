# FreewareLite
SonOyuncu clientside xray koruması kapatmak için lib methodu kullanan basit bir yazılım

lwjgl-2.9.4-nightly-20150209.jar kütüphane dosyasını içerisindeki org/lwjgl/opengl/GL11 classındaki glMultMatrix methodu onMotionUpdate ile benzer şekilde kullanılabilir.

Anlık olarak titanyumda clientside korumanın yanında serverside xray koruması da aktiftir.
Bu projenin tek amacı bu saçma methodun yayılarak fixlenmesini sağlamaktır. Sunucu taraflı koruma yüzünden xray çalışmayacaktır.

![image](https://user-images.githubusercontent.com/82592303/180977673-9fe556e6-5f40-4ff7-8b33-1fa5c3147bc1.png)

Programın launcherde oyun açılmadan önce çalıştırılması gerekmektedir; çalışma mantığı kısaca,
1) Editlenmiş lib dosyası değiştirilir
2) Oyna butonuna tıklanır ve değişikliği algılayan launcher orijinal dosyayı indirir.

![image](https://user-images.githubusercontent.com/82592303/180978695-bd566fff-81be-4aed-ad1b-76b454047708.png)

3) Bu dosyanın kontrolu tamamlandığı için artık istediğimiz gibi değiştirebiliriz, bu sırada editlenmiş dosya indirilir.
4) Ve oyun açıldığında lib dosyası değişmiştir
