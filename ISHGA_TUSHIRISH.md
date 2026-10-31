# Online AutoParking — ishga tushirish qo'llanmasi

C# (WinForms, .NET Framework 4.8) desktop ilova. Ma'lumotlar SQLite bazasida saqlanadi.

## 1. Kerakli dasturlar

| Dastur | Nima uchun | Majburiymi |
|---|---|---|
| **.NET SDK** (6 yoki undan yangi) | Kodni kompilyatsiya qilish (`dotnet` buyrug'i) | Ha, 2-A usul uchun |
| **Visual Studio 2022** (".NET desktop development" komponenti bilan) | Kodni ochish, tahrirlash, F5 bilan ishga tushirish | Yo'q, 2-B usul uchun |
| **.NET Framework 4.8** | Ilovani ishga tushirish (Windows 10/11 da o'rnatilgan bo'ladi) | Ha |
| **DB Browser for SQLite** | Bazani ko'rish | Yo'q |

SQLite'ni alohida o'rnatish shart emas: kerakli kutubxona (`Microsoft.Data.Sqlite`) NuGet orqali
build vaqtida avtomatik yuklab olinadi. Birinchi build uchun internet kerak.

## 2. Ishga tushirish

### A usul — terminal orqali

Loyiha papkasida (`PBL2_AutoParking`) PowerShell oching va quyidagilarni bajaring:

```powershell
# 1) Kompilyatsiya qilish
dotnet build OnlineAutoParking\OnlineAutoParking.sln

# 2) Ishga tushirish
.\OnlineAutoParking\OnlineAutoParking\bin\Debug\net48\OnlineAutoParking.exe
```

Build tugaganda `Build succeeded. 0 Error(s)` yozuvi chiqishi kerak.

### B usul — Visual Studio orqali

1. Visual Studio'da `OnlineAutoParking\OnlineAutoParking.sln` faylini oching.
2. Yuqoridagi menyuda **Debug** rejimi va **OnlineAutoParking** loyihasi tanlanganini tekshiring.
3. **F5** (yoki ▶ Start) tugmasini bosing.

### Tayyor `.exe` qilish (boshqa kompyuterga berish uchun)

```powershell
dotnet build OnlineAutoParking\OnlineAutoParking.sln -c Release
```

Natija `OnlineAutoParking\OnlineAutoParking\bin\Release\net48\` papkasida paydo bo'ladi.
**Butun papkani** nusxalang: `.exe` faylining o'zi SQLite DLL fayllarisiz ishlamaydi.

## 3. Ma'lumotlar bazasi

Baza fayli loyiha papkasida turadi:

```
PBL2_AutoParking\parking.db
```

Ilova `.exe` turgan papkadan boshlab yuqoriga qarab birinchi topilgan `parking.db` faylini ishlatadi.
Hech qayerda topilmasa, `.exe` yonida yangi `parking.db` yaratadi.

Bazada 2 ta jadval bor:
- `ParkingLots` — avtoturargohlar;
- `Bookings` — bronlar.

Baza yangi yaratilganda 3 ta namunaviy avtoturargoh qo'shiladi: Chilonzor, Yunusobod, Sergeli.

**DB Browser for SQLite'da ko'rish:** **Open Database** tugmasini bosing → `parking.db` faylini tanlang → **Browse Data** yorlig'iga o'ting.
DB Browser'da biror narsani o'zgartirsangiz, **Write Changes** (`Ctrl + S`) ni bosishni unutmang.
Aks holda baza qulflanib qoladi va ilova unga yoza olmaydi.

**Bazani boshidan boshlash:** ilovani yoping, `parking.db` faylini o'chiring va ilovani qayta ishga tushiring.
Yangi baza `.exe` yonida (`bin\Debug\net48\parking.db`) yaratiladi. Uni yana loyiha papkasida saqlamoqchi bo'lsangiz,
shu faylni `PBL2_AutoParking` papkasiga ko'chirib qo'ying.

## 4. Ilovadan foydalanish

1. **Bosh sahifa (MainForm)** — boshlanish va tugash vaqtini tanlang, so'ng **Bo'sh joylarni tekshirish** tugmasini bosing.
   Jadvalda har bir avtoturargohdagi bo'sh joylar soni ko'rinadi.
2. **Joy band qilish (BookingForm)** — avtoturargoh qatorini ikki marta bosing yoki **Joy band qilish** tugmasini bosing.
   Haydovchi ismi va mashina raqamini kiriting, so'ng **Bronni tasdiqlash** tugmasini bosing.
   Bron bazaga yoziladi va sizga bron raqami ko'rsatiladi.
3. **Administrator paneli (AdminForm)** — **Admin panel** tugmasi orqali ochiladi:
   - avtoturargohlar: **Qo'shish**, **Tahrirlash**, **Faolsizlantirish**;
   - barcha bronlarni ko'rish va **Bronni bekor qilish**.

## 5. Ko'p uchraydigan muammolar

| Muammo | Yechim |
|---|---|
| `dotnet` buyrug'i topilmadi | https://dotnet.microsoft.com/download sahifasidan .NET SDK'ni o'rnating |
| Build paytida NuGet xatosi | Internet ulanishini tekshiring va `dotnet restore OnlineAutoParking\OnlineAutoParking.sln` buyrug'ini bajaring |
| `database is locked` | DB Browser'da **Write Changes** yoki **Close Database** tugmasini bosing |
| "Ma'lumotlar bazasini ishga tushirib bo'lmadi" | `parking.db` fayli va u turgan papkaga yozish huquqi borligini tekshiring (fayl "Faqat o'qish uchun" bo'lmasin) |
| Build: fayl band (`file is locked by OnlineAutoParking`) | Ishlab turgan ilovani yoping, keyin qayta build qiling |
