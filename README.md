<div dir="rtl" align="center">

# ♻️ Waste_Management | سامانه مدیریت پسماند


---

</div>

<div dir="rtl">

## 🖥️ معرفی پروژه

<pre style="font-family: monospace; background: #0D1117; color: #00FF88; padding: 12px; border-radius: 8px; border: 1px solid #30363d;">
┌─────────────────────────────────────────────────────────────┐
│  نام پروژه: Waste_Management                                 │
│  نوع: سامانه مدیریت پسماند شهری                               │
│  معماری: سه لایه (Data, WebApi) + لایه ترجمه فارسی            │
│  الگوها: Repository, Unit of Work, DTO, AutoMapper          │
│  هدف: مدیریت غرفه‌ها، پیمانکاران، غرفه‌داران، شهرداری‌ها و ناظران │
└─────────────────────────────────────────────────────────────┘
</pre>

**Waste_Management** یک سامانه‌ی جامع برای مدیریت پسماند شهری است که با معماری لایه‌بندی شده و استفاده از الگوهای حرفه‌ای توسعه داده شده است. این پروژه قابلیت مدیریت موجودیت‌های زیر را دارد:

- **Booth** (غرفه‌ها)
- **Contractor** (پیمانکاران)
- **Exhibitor** (غرفه‌داران)
- **Municipality** (شهرداری‌ها)
- **Supervisor** (ناظران)
- **User** (کاربران)

---

## 🛠️ تکنولوژی‌های استفاده شده

<div align="center">

| دسته | ابزارها |
| :--- | :--- |
| **زبان اصلی** | ![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white) |
| **فریمورک** | ![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-5C2D91?style=flat-square&logo=.net&logoColor=white) ![.NET Core](https://img.shields.io/badge/.NET_Core-5C2D91?style=flat-square&logo=.net&logoColor=white) |
| **ORM** | ![Entity Framework Core](https://img.shields.io/badge/EF_Core-5C2D91?style=flat-square&logo=.net&logoColor=white) |
| **مپینگ اشیاء** | ![AutoMapper](https://img.shields.io/badge/AutoMapper-5C2D91?style=flat-square&logo=.net&logoColor=white) |
| **مستندسازی API** | ![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=flat-square&logo=swagger&logoColor=black) |
| **بین‌المللی‌سازی** | ![PersianTranslation](https://img.shields.io/badge/PersianTranslation-0088CC?style=flat-square&logo=translate&logoColor=white) |

</div>

---

## 🗂️ ساختار پروژه

<pre style="font-family: monospace; background: #0D1117; color: #FFFFFF; padding: 12px; border-radius: 8px; border: 1px solid #30363d;">
Waste_Management/
├── Waste_Management.Data/           # لایه داده (مدل‌ها، DbContext، ریپازیتوری‌ها)
│   ├── Entities/                    # موجودیت‌های اصلی (Booth, Contractor, ...)
│   └── (Repository, UnitOfWork)
├── Waste_Management.WebApi/         # لایه API (کنترلرها، DTOها، سرویس‌ها)
│   ├── Controllers/                 # مدیریت درخواست‌ها
│   ├── DTOs/                        # مدل‌های انتقال داده
│   ├── Services/                    # منطق کسب و کار
│   ├── Profiles/                    # پروفایل‌های AutoMapper
│   └── Contracts/                   # قراردادهای سرویس‌ها
├── Waste_Management.PersianTranslation/  # لایه ترجمه و پشتیبانی از زبان فارسی
└── Waste_Management.sln             # فایل Solution
</pre>

---

## 🚀 ویژگی‌های کلیدی

<pre style="font-family: monospace; background: #0D1117; color: #00FF88; padding: 12px; border-radius: 8px; border: 1px solid #30363d;">
✓ معماری لایه‌بندی شده (Separation of Concerns)
✓ استفاده از الگوی Repository و Unit of Work برای مدیریت دیتابیس
✓ استفاده از DTOها برای انتقال امن و بهینه داده
✓ استفاده از AutoMapper برای نگاشت خودکار Entity ↔ DTO
✓ پشتیبانی از زبان فارسی از طریق لایه اختصاصی PersianTranslation
✓ قابلیت مستندسازی خودکار API با Swagger
✓ قابلیت توسعه به سمت میکروسرویس‌ها
</pre>

---


## 📫 ارتباط با توسعه‌دهنده

<div align="center">

[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/abolfazlmo006)
[![ایمیل اصلی](https://img.shields.io/badge/abolfazlmohamadi690@gmail.com-D14836?style=for-the-badge&logo=gmail&logoColor=white)](mailto:abolfazlmohamadi690@gmail.com)

</div>

---

<div align="center">
  
</div>

</div>
