# 🚀 Product Image Cleaner Service

Modern, katmanlı mimari ile geliştirilmiş, production-ready bir Windows Worker Service uygulamasıdır.
Bu servis, veri tabanındaki silinmiş ürünlere ait resimleri otomatik olarak kontrol eder ve veri tutarlılığını sağlar.

---

## 🧩 Proje Amacı

Bu proje, veri bütünlüğünü korumak amacıyla geliştirilmiştir.
Sistem, **silinmiş ürünleri (Silindi = true)** tespit eder ve bu ürünlere ait resimlerin durumunu kontrol eder.

Eğer ürün silinmiş ancak resimleri hâlâ aktif ise:

* Resim kayıtları otomatik olarak **Silindi = true** yapılır.

Bu sayede:

* Veri tutarsızlıkları önlenir
* Gereksiz dosya/record birikimi engellenir
* Sistem performansı korunur

---

## 🏗️ Kullanılan Mimari

Proje, **Clean Architecture / Katmanlı Mimari** prensiplerine uygun olarak geliştirilmiştir:

* **Core** → Entity ve ortak modeller
* **Data** → Repository ve veri erişim katmanı (ADO.NET)
* **Business** → İş kuralları ve servisler
* **Infrastructure** → Database bağlantı yönetimi
* **Worker Service** → Arka plan çalışan servis (scheduler)

---

## ⚙️ Kullanılan Teknolojiler

* .NET 8 / .NET Worker Service
* ADO.NET
* SQL Server (Stored Procedure)
* Dependency Injection
* Options Pattern (IOptions)
* Serilog (Logging)
* Polly (Retry mekanizması)
* Windows Service entegrasyonu

---

## 🔄 Çalışma Mantığı

1. Belirli aralıklarla (configurable interval) çalışır
2. Veritabanından silinmiş ürünleri çeker
3. Ürünlere ait resimleri kontrol eder
4. Silinmemiş resimleri otomatik olarak günceller
5. Tüm işlemleri loglar

---

## 📁 Konfigürasyon

Tüm ayarlar `appsettings.json` üzerinden yönetilir:

```json
"WorkerSettings": {
  "IntervalMinutes": 5,
  "RetryCount": 3
}
```

---

## 📊 Loglama

Uygulama, Serilog kullanarak logları dosyaya yazar:

```plaintext
logs/log-YYYY-MM-DD.txt
```

---

## 🛡️ Dayanıklılık (Resilience)

* Polly ile retry mekanizması uygulanmıştır
* Geçici DB hatalarında otomatik tekrar deneme yapılır
* Hatalar detaylı şekilde loglanır

---

## 🖥️ Windows Service

Uygulama, Windows Service olarak çalışacak şekilde tasarlanmıştır.
Arka planda sürekli çalışarak manuel müdahale gerektirmez.

---

## 🎯 Neden Bu Proje?

Bu proje, aşağıdaki konularda yetkinliğimi göstermektedir:

* Katmanlı mimari tasarımı
* Clean Code prensipleri
* Background service geliştirme
* Dependency Injection kullanımı
* Logging ve hata yönetimi
* Performans ve veri tutarlılığı

---

<p align="center">
  <img src="MyWorkerService/Ekran_Alıntısı_20.PNG" width="600"/>
</p>

## 📌 Not

Bu proje, portföy amaçlı geliştirilmiş olup gerçek dünya senaryolarına uygun şekilde tasarlanmıştır.
Kolayca genişletilebilir ve farklı sistemlere entegre edilebilir.

---

## 👨‍💻 Geliştirici

Bu proje, yazılım mimarisi ve backend geliştirme konularında yetkinliğimi göstermek amacıyla hazırlanmıştır.
