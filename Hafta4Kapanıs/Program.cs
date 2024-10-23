using System;

class Program
{
    static void Main(string[] args)
    {
        bool devamEt = true;

        while (devamEt)
        {
            Console.WriteLine("Telefon üretmek için 1, Bilgisayar üretmek için 2'ye basınız:");
            int secim = int.Parse(Console.ReadLine());

            if (secim == 1)
            {
                Telefon telefon = TelefonBilgileriniAl();
                Console.WriteLine("\nTelefon başarıyla üretildi!");
                telefon.BilgileriYazdir();
            }
            else if (secim == 2)
            {
                Bilgisayar bilgisayar = BilgisayarBilgileriniAl();
                Console.WriteLine("\nBilgisayar başarıyla üretildi!");
                bilgisayar.BilgileriYazdir();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                continue;
            }

            Console.WriteLine("\nBaşka bir ürün üretmek istiyor musunuz? (Evet/Hayır)");
            string cevap = Console.ReadLine().ToLower();
            devamEt = (cevap == "evet");
        }

        Console.WriteLine("İyi günler dileriz!");
    }

    static Telefon TelefonBilgileriniAl()
    {
        Console.Write("Seri Numarası: ");
        string seriNo = Console.ReadLine();

        Console.Write("Ad: ");
        string ad = Console.ReadLine();

        Console.Write("Açıklama: ");
        string aciklama = Console.ReadLine();

        Console.Write("İşletim Sistemi: ");
        string isletimSistemi = Console.ReadLine();

        Console.Write("TR Lisanslı mı? (Evet/Hayır): ");
        bool trLisansli = Console.ReadLine().ToLower() == "evet";

        return new Telefon(seriNo, ad, aciklama, isletimSistemi, trLisansli);
    }

    static Bilgisayar BilgisayarBilgileriniAl()
    {
        Console.Write("Seri Numarası: ");
        string seriNo = Console.ReadLine();

        Console.Write("Ad: ");
        string ad = Console.ReadLine();

        Console.Write("Açıklama: ");
        string aciklama = Console.ReadLine();

        Console.Write("İşletim Sistemi: ");
        string isletimSistemi = Console.ReadLine();

        Console.Write("USB Giriş Sayısı (2 veya 4): ");
        int usbGirisSayisi = int.Parse(Console.ReadLine());

        Console.Write("Bluetooth Var mı? (Evet/Hayır): ");
        bool bluetooth = Console.ReadLine().ToLower() == "evet";

        return new Bilgisayar(seriNo, ad, aciklama, isletimSistemi, usbGirisSayisi, bluetooth);
    }
}

abstract class BaseMakine
{
    public string UretimTarihi { get; } = DateTime.Now.ToString("dd-MM-yyyy");
    public string SeriNumarasi { get; set; }
    public string Ad { get; set; }
    public string Aciklama { get; set; }
    public string IsletimSistemi { get; set; }

    public BaseMakine(string seriNumarasi, string ad, string aciklama, string isletimSistemi)
    {
        SeriNumarasi = seriNumarasi;
        Ad = ad;
        Aciklama = aciklama;
        IsletimSistemi = isletimSistemi;
    }

    public virtual void BilgileriYazdir()
    {
        Console.WriteLine($"Üretim Tarihi: {UretimTarihi}");
        Console.WriteLine($"Seri Numarası: {SeriNumarasi}");
        Console.WriteLine($"Ad: {Ad}");
        Console.WriteLine($"Açıklama: {Aciklama}");
        Console.WriteLine($"İşletim Sistemi: {IsletimSistemi}");
    }

    public abstract string UrunAdiGetir();
}

class Telefon : BaseMakine
{
    public bool TrLisansli { get; set; }

    public Telefon(string seriNumarasi, string ad, string aciklama, string isletimSistemi, bool trLisansli)
        : base(seriNumarasi, ad, aciklama, isletimSistemi)
    {
        TrLisansli = trLisansli;
    }

    public override void BilgileriYazdir()
    {
        base.BilgileriYazdir();
        Console.WriteLine($"TR Lisanslı: {(TrLisansli ? "Evet" : "Hayır")}");
    }

    public override string UrunAdiGetir()
    {
        return $"Telefonunuzun adı ---> {Ad}";
    }
}

class Bilgisayar : BaseMakine
{
    private int usbGirisSayisi;
    public int UsbGirisSayisi
    {
        get => usbGirisSayisi;
        set
        {
            if (value == 2 || value == 4)
                usbGirisSayisi = value;
            else
            {
                Console.WriteLine("Geçersiz USB giriş sayısı! -1 olarak atanıyor.");
                usbGirisSayisi = -1;
            }
        }
    }

    public bool Bluetooth { get; set; }

    public Bilgisayar(string seriNumarasi, string ad, string aciklama, string isletimSistemi, int usbGirisSayisi, bool bluetooth)
        : base(seriNumarasi, ad, aciklama, isletimSistemi)
    {
        UsbGirisSayisi = usbGirisSayisi;
        Bluetooth = bluetooth;
    }

    public override void BilgileriYazdir()
    {
        base.BilgileriYazdir();
        Console.WriteLine($"USB Giriş Sayısı: {UsbGirisSayisi}");
        Console.WriteLine($"Bluetooth: {(Bluetooth ? "Var" : "Yok")}");
    }

    public override string UrunAdiGetir()
    {
        return $"Bilgisayarınızın adı ---> {Ad}";
    }
}
