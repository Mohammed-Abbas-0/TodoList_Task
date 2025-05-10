# ✅ TodoList Task API

API لإدارة مهام الـ To-Do List باستخدام ASP.NET Core، بتطبيق نظيف ومرتب باستخدام **Clean Architecture**، مع دعم **CQRS** و **MediatR** و **Entity Framework Core**.

---

## 📦 مكونات المشروع

ToDoList_Task/
├── Application ← يحتوي على CQRS Handlers (Commands & Queries)
├── Domain ← يحتوي على الكيانات (Entities) والواجهات (Interfaces)
├── Infrastructure ← يحتوي على DbContext، Repositories
├── Interface ← يحتوي على DTOs و Filters
├── WebAPI ← نقطة تشغيل الـ API و Controllers و Dependency Injection

yaml
Copy
Edit

---

## 🚀 إزاي تشغل المشروع

### 1. 🧬 كلون الريبو

```bash
git clone https://github.com/Mohammed-Abbas-0/TodoList_Task.git
cd ToDoList_Task
2. ⚙️ تعديل الاتصال بقاعدة البيانات
افتح الملف WebAPI/appsettings.json وعدل الـ Connection String:

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=TodoDb;Trusted_Connection=True;"
}
💡 لو بتستخدم SQL Server Express، خليه كده:
"Server=.\\SQLEXPRESS;Database=TodoDb;Trusted_Connection=True;"

3. 🧱 تنفيذ المايجريشن وإنشاء قاعدة البيانات
bash
Copy
Edit
cd WebAPI
dotnet ef database update
💡 لو لسه ما ثبتتش EF CLI:
dotnet tool install --global dotnet-ef

4. ▶️ شغل المشروع
bash
Copy
Edit
dotnet run
5. 🌐 افتح الـ Swagger
بعد ما تشغل المشروع، افتح المتصفح على:

bash
Copy
Edit
https://localhost:<your-port>/swagger
هتلاقي كل الـ endpoints شغالة من خلال واجهة Swagger UI.

🎯 المميزات
CRUD كامل للمهام

فلترة بالـ:

العنوان

الحالة (Pending, InProgress, Completed)

الأولوية (Low, Medium, High)

تاريخ التسليم

دعم الـ Pagination

DDD + CQRS + MediatR

بنية نظيفة وقابلة للتوسيع

🧠 التكنولوجيات المستخدمة
ASP.NET Core 8

EF Core

MediatR

AutoMapper

SQL Server

👨‍💻 المطور
Mohammed Abbas
GitHub Profile

لو المشروع عجبك، ما تنساش تعمل ⭐ على الريبو! 😉