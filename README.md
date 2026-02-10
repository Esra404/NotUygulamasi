# Console Tabanlı Not Uygulaması (C#)

Bu proje, C# ve backend mantığını öğrenmek amacıyla geliştirilmiş
console tabanlı bir not uygulamasıdır.

Amaç; sadece çalışan bir uygulama yapmak değil,
aynı zamanda veritabanı, CRUD ve API’ye geçiş altyapısını
mantıksal olarak kavramaktır.

---

## 🚀 Projenin Özellikleri

- Kullanıcı kayıt ve giriş sistemi
- Kullanıcıya özel notlar
- Not ekleme
- Not listeleme
- Not güncelleme
- Not silme
- JSON dosyası ile kalıcı veri saklama
- CRUD mantığının tamamı uygulanmıştır

---

## 🧠 Kullanılan Teknolojiler

- C#
- .NET 8
- Console Application
- System.Text.Json (JSON işlemleri)

---

## 📂 Proje Yapısı

- Program.cs  
  Uygulamanın ana menüsü ve akış kontrolü

- Models  
  - User  
  - Note  

Tasarım, ileride ASP.NET Web API ve Entity Framework’e
geçiş yapılabilecek şekilde düşünülmüştür.

---

## 🔐 Uygulama Akışı

1. Program açılır
2. Kullanıcı kayıt olabilir
3. Kullanıcı giriş yapar
4. <img width="326" height="219" alt="image" src="https://github.com/user-attachments/assets/6478d5b7-0955-4267-b333-455ba05c4603" />

5. Giriş yapan kullanıcı:
   - Not ekleyebilir
   - Kendi notlarını listeleyebilir
   - Not güncelleyebilir
   - Not silebilir
   - <img width="512" height="299" alt="image" src="https://github.com/user-attachments/assets/69d77097-1a7d-4e5b-99a6-bb5251e04bc4" />

6. Notlar JSON dosyasına kaydedilir ve program kapansa bile korunur
<img width="469" height="312" alt="image" src="https://github.com/user-attachments/assets/b301f504-803e-4208-b980-6fd25b4fa31a" />


---

## 📌 Neden Console Application?

Bu proje görsel arayüzden bilinçli olarak uzak tutulmuştur.
Amaç; UI karmaşasına girmeden backend mantığını,
veri ilişkilerini ve iş kurallarını net şekilde öğrenmektir.

Console sadece bir arayüzdür.
Aynı iş mantığı ileride Web API içinde birebir kullanılabilir.

---

## 🔄 Gelecek Geliştirmeler

- User–Note ilişkisinin UserId üzerinden düzenlenmesi
- Entity Framework Core entegrasyonu
- SQLite veya SQL Server kullanımı
- ASP.NET Web API’ye dönüştürme
- JWT ile kimlik doğrulama

---

## ✍️ Not

Bu proje öğrenme amaçlıdır.
Kodun mükemmel olması değil,
mantığın doğru kurulması hedeflenmiştir.

Bitmiş proje, mükemmel hayalden iyidir.

---

👨‍💻 Geliştirici: Esra
