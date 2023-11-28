namespace EncryptedDiaryApp;

internal class Program
{
    static List<string> dairyDocuments { get; set; } = new List<string>();
    static DateTime lastDocumentDate = DateTime.MinValue;

    const string path = "C:\\Proje\\Dairy.txt";

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Yeni kayıt ekle");
            Console.WriteLine("2. Kayıtları listele");
            Console.WriteLine("3. Tüm kayıtları sil");
            Console.WriteLine("4. Çıkış");

            ConsoleKeyInfo choice = Console.ReadKey();
            Console.Clear();

            switch (choice.Key)
            {
                case ConsoleKey.D1:
                    AddNewDocument(path);
                    break;
                case ConsoleKey.D2:
                    DocumentList(path);
                    break;
                case ConsoleKey.D3:
                    DeleteAllDocuments(path);
                    break;
                case ConsoleKey.D4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void AddNewDocument(string path)
    {
        if (DateTime.Now.Date != lastDocumentDate.Date)
        {
            StreamWriter writer = new StreamWriter(path, true);
            Console.WriteLine("Günlük kaydınızı ekleyin:");
            string newDocument = $"{DateTime.Now}\n{Console.ReadLine()}";
            dairyDocuments.Add(newDocument);
            writer.WriteLine(newDocument);
            writer.Close();
            lastDocumentDate = DateTime.Now;
            Console.WriteLine("Kayıt eklendi.");
        }
        else
        {
            Console.WriteLine("Günlük kaydınız zaten mevcut olduğundan yeni kayıt eklenemez. Lütfen herhangi bir tuşa basarak ana menüye dönün");
        }
        Console.ReadLine();
    }

    static void DocumentList(string path)
    {
        if (File.Exists(path))
        {
            if (dairyDocuments.Count > 0)
            {
                foreach (var document in dairyDocuments)
                {
                    Console.WriteLine($"{dairyDocuments[dairyDocuments.Count - 1]}\n-------------");
                }
            }
            else
            {
                Console.WriteLine("Herhangi bir kayıt bulunamadı.");
            }

            Console.WriteLine("1. Kayıdı düzenle");
            Console.WriteLine("2. Kaydı sil");
            Console.WriteLine("3. Tüm kayıtları göster");
            Console.WriteLine("4. Çıkış");

            ConsoleKeyInfo choice = Console.ReadKey();
                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                        AddNewDocumentList(path);
                        break;
                    case ConsoleKey.D2:
                        DeleteAllDocuments(path);
                        break;
                    case ConsoleKey.D3:
                        AllDocumentList(path);
                        break;
                    case ConsoleKey.D4:
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                        break;
                }
                Console.ReadLine();
            }
    }

    static void DeleteAllDocuments(string path)
        {
            Console.WriteLine("Kaydı silmek istediğinize emin misiniz? (E/H)");

            if (Console.ReadLine().ToUpper() == "E")
            {

                File.Delete(path);
                Console.WriteLine("Tüm kayıtlar silindi.");
                lastDocumentDate = DateTime.MinValue;
            }
            else
            {
                Console.WriteLine("İşlem iptal edildi.");
            }

            Console.ReadLine();
        }
    static void AllDocumentList(string path)
    {
        if (File.Exists(path))
        {
            Console.WriteLine("Tüm Günlük Kayıtlar:\n");

            string[] documents = File.ReadAllLines(path);

            foreach (var document in documents)
            {
                Console.WriteLine($"{document}\n-------------");
            }
        }
        else
        {
            Console.WriteLine("Herhangi bir kayıt bulunamadı.");
        }

        Console.ReadLine();
    }
    static void AddNewDocumentList(string path)
    {
        StreamWriter writer = new StreamWriter(path, true);
        Console.WriteLine("Günlük kaydınızı düzenleyin:");
        string newDocument = $"{DateTime.Now}\n{Console.ReadLine()}";
        dairyDocuments.Add(newDocument);
        writer.WriteLine(newDocument);
        writer.Close();
        Console.WriteLine("Kayıt düzenlendi.");
        Console.ReadLine();
    }
}
    
